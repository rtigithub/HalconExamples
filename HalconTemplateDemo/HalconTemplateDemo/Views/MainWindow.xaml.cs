//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo
{
     using System;
     using System.IO;
     using System.Linq;
     using System.Reactive.Linq;
     using System.Threading.Tasks;
     using System.Windows;
     using System.Windows.Controls;
     using System.Windows.Data;
     using System.Windows.Markup;
     using System.Xml;
     using HalconDotNet;
     using Microsoft.Win32;
     using ReactiveUI;
     using Rti.ViewROIManager;
     using Utilities;

     using ViewModel = ViewModels.MainViewModel;

     /// <summary>
     /// Interaction logic for MainWindow.
     /// </summary>
     public sealed partial class MainWindow : Window, ReactiveUI.IViewFor<ViewModel>, IDisposable
     {
          #region Public Static Fields

          /// <summary>
          /// The DependencyProperty for the ViewModel.
          /// </summary>
          public static readonly DependencyProperty ViewModelProperty =
          DependencyProperty.Register("MainViewModel", typeof(ViewModel), typeof(MainWindow), new PropertyMetadata(null));

          #endregion Public Static Fields

          #region Private Fields

          /// <summary>
          /// Stores a value indicating whether ViewROIManager can react to zoom changes.
          /// </summary>
          private bool canReactToZoom = true;

          /// <summary>
          /// Stores the data template for the context menu.
          /// </summary>
          private DataTemplate contextMenuDataTemplate;

          /// <summary>
          /// Stores the items panel template for the context menu.
          /// </summary>
          private ItemsPanelTemplate contextMenuItemsPanelTemplate;

          /// <summary>
          /// Stores the CompositeDisposable that holds all subscription disposables.
          /// </summary>
          private System.Reactive.Disposables.CompositeDisposable disposeCollection =
              new System.Reactive.Disposables.CompositeDisposable();

          /// <summary>
          /// Stores a boolean value indicating whether the class is disposed.
          /// </summary>
          private bool isDisposed = false;

          /// <summary>
          /// Stores an instance of the UtilityLibrary class.
          /// </summary>
          private UtilityLibrary utilities = new UtilityLibrary();

          /// <summary>
          /// Stores the instance of the ViewROIManager.
          /// </summary>
          private ViewROIManager viewROIManager = new ViewROIManager();

          #endregion Private Fields

          #region Public Constructors

          /// <summary>
          /// Initializes a new instance of the MainWindow class.
          /// </summary>
          public MainWindow()
          {
               this.InitializeComponent();
               this.DataContext = this;
          }

          #endregion Public Constructors

          #region Private Destructors

          /// <summary>
          /// Finalizes an instance of the MainWindow class.
          /// </summary>
          ~MainWindow() => this.Dispose(false);

          #endregion Private Destructors

          #region Public Properties

          /// <summary>
          /// Gets the context menu data template.
          /// </summary>
          public DataTemplate ContextMenuDataTemplate => this.contextMenuDataTemplate;

          /// <summary>
          /// Gets the context menu items panel template.
          /// </summary>
          public ItemsPanelTemplate ContextMenuItemsPanelTemplate => this.contextMenuItemsPanelTemplate;

          /// <summary>
          /// Gets the disposeCollection.
          /// </summary>
          public System.Reactive.Disposables.CompositeDisposable DisposeCollection => this.disposeCollection;

          /// <summary>
          /// Gets or sets the ViewModel through the ViewModelProperty.
          /// </summary>
          public ViewModel MainViewModel
          {
               get => (ViewModel)GetValue(ViewModelProperty);

               set => this.SetValue(ViewModelProperty, value);
          }

          #endregion Public Properties

          #region Interface Member Properties

          /// <summary>
          /// Gets or sets the ViewModel as an object. Needed for RxUI binding.
          /// </summary>
          object IViewFor.ViewModel
          {
               get => this.MainViewModel;

               set => this.MainViewModel = (ViewModel)value;
          }

          /// <summary>
          /// Gets or sets the ViewModel.
          /// </summary>
          ViewModel IViewFor<ViewModel>.ViewModel
          {
               get => this.MainViewModel;

               set => this.MainViewModel = value;
          }

          #endregion Interface Member Properties

          #region Public Methods

          #region IDisposable Members

          /// <summary>
          /// Implements the Dispose method of IDisposable.
          /// </summary>
          public void Dispose()
          {
               this.Dispose(true);
               GC.SuppressFinalize(this);
          }

          #endregion IDisposable Members

          #endregion Public Methods

          #region Protected Methods

          #endregion Protected Methods

          #region Private Methods

          /// <summary>
          /// The internal method to convert a zoom string to a zoom scale.
          /// </summary>
          /// <param name="item">The zoom string.</param>
          /// <returns>The zoom scale.</returns>
          private static double GetZoomScaleFromString(string item)
          {
               double scale = 1.0;

               switch (item)
               {
                    case "6400%":
                         scale = 100.0 / 3200.0;
                         break;

                    case "3200%":
                         scale = 100.0 / 3200.0;
                         break;

                    case "1600%":
                         scale = 100.0 / 1600.0;
                         break;

                    case "800%":
                         scale = 100.0 / 800.0;
                         break;

                    case "400%":
                         scale = 100.0 / 400.0;
                         break;

                    case "200%":
                         scale = 100.0 / 200.0;
                         break;

                    case "100%":
                         scale = 1.0;
                         break;

                    case "75%":
                         scale = 100.0 / 75.0;
                         break;

                    case "50%":
                         scale = 100.0 / 50.0;
                         break;

                    case "33%":
                         scale = 100.0 / 33.3;
                         break;

                    case "Fit":
                         scale = 0;
                         break;

                    default:
                         scale = 1.0;
                         break;
               }

               return scale;
          }

          /// <summary>
          /// Create a DataTemplate for parsing the menu objects.
          /// </summary>
          /// <returns>the DataTemplate.</returns>
          private DataTemplate CreateDataTemplate()
          {
               StringReader stringReader = new StringReader(
                   @"<DataTemplate
                    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
                    <MenuItem Header=""{Binding DisplayName }"" Command=""{Binding MenuCommand}""/>
                </DataTemplate>");
               XmlReader xmlReader = XmlReader.Create(stringReader);
               return XamlReader.Load(xmlReader) as DataTemplate;
          }

          /// <summary>
          /// Create an ItemsPanelTemplate for parsing the menu objects.
          /// </summary>
          /// <returns>the ItemsPanelTemplate.</returns>
          private ItemsPanelTemplate CreateItemsPanelTemplate()
          {
               StringReader stringReader = new StringReader(
                   @"<ItemsPanelTemplate
                    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
                        <StackPanel Margin=""-38,0,-55,0"" Background=""White""/>
                   </ItemsPanelTemplate>");
               XmlReader xmlReader = XmlReader.Create(stringReader);
               return XamlReader.Load(xmlReader) as ItemsPanelTemplate;
          }

          /// <summary>
          /// Implements the Dispose method of IDisposable that actually disposes of managed resources.
          /// </summary>
          /// <param name="disposing">A boolean value indicating whether the class is being disposed.</param>
          private void Dispose(bool disposing)
          {
               if (!this.isDisposed)
               {
                    if (disposing)
                    {
                         // Code to dispose the managed resources held by the class
                         this.disposeCollection?.Dispose();

                         this.utilities?.Dispose();

                         this.MainViewModel?.Dispose();
                    }

                    //// Dispose of unmanaged resources.
               }

               this.isDisposed = true;
          }

          /// <summary>
          /// Handles the ExitItem_Click event.
          /// </summary>
          /// <param name="sender">The calling object.</param>
          /// <param name="e">The RoutedEventArgs.</param>
          private void ExitItem_Click(object sender, RoutedEventArgs e) => this.Close();

          /// <summary>
          /// Handles the MainItem_Click event.
          /// </summary>
          /// <param name="sender">The calling object.</param>
          /// <param name="e">The RoutedEventArgs.</param>
          private void MainItem_Click(object sender, RoutedEventArgs e) => this.Frame1.Visibility = Visibility.Hidden;

          /// <summary>
          /// Performs all initialization of added modules and creation of reactive bindings and
          /// associated actions.
          /// </summary>
          private void ReactiveSetup()
          {
               this.MainViewModel = new ViewModel();
               this.DataContext = this.MainViewModel;

               this.RibbonControl1.IsMinimized = true;
               this.Frame1.Visibility = Visibility.Hidden;

               this.MainViewModel.LoadImageVM.GetFileName.RegisterHandler(
                    async interaction =>
                    {
                         string filename = await this.utilities.GetFileName();
                         interaction.SetOutput(filename);
                    });

               //// Call additional Initialize<Name>Module() methods for each new module.
               //// Note: For ROIModules, the Initialize<Name>Module() methods must be called after
               //// the BindHalconWindow call for the ViewROIManager being passed. See below.  

               // Bind hWindowControlWPF1 to the ViewRoiManager.
               BindingUtilities.BindHalconWindow(
                   this.viewROIManager,
                   this.hWindowControlWPF1,
                   nameof(this.ImageBorder),
                   nameof(this.MainViewModel.LoadImageVM),
                   this);

               //// Note: For ROIModules, call the Initialize<Name>Module() methods here, after 
               //// the ViewROIManager being passed is initialized. 

               // Uncomment this line to bind the Process button to the command of a new
               // ProcessViewModel created in MainViewModel.cs. Change "ProcessVM" to the name of the
               // new ProcessViewModel.
               ////this.BindCommand(this.MainViewModel, vm => vm.ProcessVM.Command, x => x.ProcessButton);
               this.BindCommand(this.MainViewModel, vm => vm.LoadImageVM.Command, x => x.buttonLoadImage);

               //// Note: To use radio buttons bound to an enumeration it is necessary to create the radio button group,
               //// add new values to the RadioButtonSelection enumeration (in Model.Enums.cs), bind the property
               //// of the Enum type in a view model, and to bind each radio button with a call to BindingUtilites.SetRadioButtonBinding.
               //// Template: BindingUtilities.SetRadioButtonBinding(this.Option1Button, this.MainViewModel.SelectChannelVM, "SelectedOptionProperty", "Option1");

               //// Note: To create complete bindings for combo boxes call BindingUtilities.BindComboBox. Use nameof to get the strings more conveniently.
               //// Template: BindingUtilities.BindComboBox<Type of bound parameter, type of view model>
               ////      nameof(this.ComboBoxName),
               ////      nameof(this.MainViewModel.ViewModelName),
               ////      nameof(this.MainViewModel.ViewModelName.BoundPropertyName),
               ////      nameof(this.MainViewModel.ViewModelName.ItemPropertyName),
               ////      this);

               this.dataGrid1.ItemsSource = this.MainViewModel.ProcessingResultsDataSet.Tables[0].DefaultView;

               // Create the data template for the context menu.
               this.contextMenuDataTemplate = this.CreateDataTemplate();

               // Create the ItemsPanelTemplate for the context menu.
               this.contextMenuItemsPanelTemplate = this.CreateItemsPanelTemplate();

               this.disposeCollection.Add(Observable.FromEventPattern<SelectionChangedEventArgs>(this.comboboxZoom, "SelectionChanged")
                   .Where(_ => this.canReactToZoom)
                   .Select(ev => ev.EventArgs.AddedItems.Cast<object>().FirstOrDefault())
                   .Select(s => (string)((ComboBoxItem)s).Content)
                   .Select(v => GetZoomScaleFromString(v))
                   .ObserveOn(RxApp.MainThreadScheduler)
                   .BindTo(this.viewROIManager, vm => vm.ZoomScale));

               // Reset the zoom combo box to "Fit" for a new image, but prevent redisplay of the image.
               this.disposeCollection.Add(this.WhenAnyValue(x => x.MainViewModel.LoadImageVM.Display)
                  .Where(x => x.DisplayList.Count > 0)
                  .ObserveOn(RxApp.MainThreadScheduler)
                  .Subscribe(_ =>
                  {
                       this.canReactToZoom = false;
                       this.comboboxZoom.SelectedIndex = 10;
                       this.canReactToZoom = true;
                  }));

               // Displays
               this.disposeCollection.Add(this.WhenAnyValue(x => x.MainViewModel.LoadImageVM.Display)
                   .Where(x => x.DisplayList.Count > 0)
                   .ObserveOn(RxApp.MainThreadScheduler)
                   .Subscribe(x =>
                   {
                        this.viewROIManager.ShowDisplayCollection(x);
                   }));

               //// Add manually created subscriptions to display collections here by duplicating the above code and changing the ViewModel.
               //// Processing modules added with the templates will handle the main display bindings automatically.

               // Debug Displays
               this.disposeCollection.Add(this.WhenAnyValue(x => x.MainViewModel.LoadImageVM.DebugDisplay)
                   .Where(x => x.DisplayList.Count > 0)
                   .ObserveOn(RxApp.MainThreadScheduler)
                   .Subscribe(x => this.viewROIManager.ShowDisplayCollection(x)));

               //// Add manually created subscriptions to debug display collections here by duplicating the above code and changing the ViewModel.
               //// Processing modules added with the templates will handle the main display bindings automatically.

               // Save settings on closing.
               this.disposeCollection.Add(this.Events().Closing
                   .Subscribe(_ => this.MainViewModel.SettingsVM.SaveSettings()));
          }

          /// <summary>
          /// Handles the Loaded method.
          /// </summary>
          /// <param name="sender">The calling object.</param>
          /// <param name="e">The RoutedEventArgs.</param>
          private void WindowLoaded(object sender, RoutedEventArgs e)
          {
               this.ReactiveSetup();
          }

          #endregion Private Methods
     }
}