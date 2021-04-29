//-----------------------------------------------------------------------
// <copyright file="BindingUtilities.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName",
    Justification = "Allow the name of the file to be used.")]

namespace HalconTemplateDemo.Utilities
{
     using System;
     using System.Collections;
     using System.Linq;
     using System.Linq.Expressions;
     using System.Reactive.Linq;
     using System.Reflection;
     using System.Windows;
     using System.Windows.Controls;
     using System.Windows.Data;
     using HalconDotNet;
     using ReactiveUI;
     using Rti.ViewROIManager;

     using LExpression = System.Linq.Expressions.Expression;

     /// <summary>
     /// BindingUtilities class holds methods used in creating Reactive bindings programmatically.
     /// </summary>
     public static class BindingUtilities
     {
          /// <summary>
          /// Constant for the regex string for floating point numbers.
          /// </summary>
          private const string RegexFloat = @"^-?\d+\.?\d*$";

          /// <summary>
          /// Constant for the regex string for integers.
          /// </summary>
          private const string RegexInteger = @"^-?\d+$";

          /// <summary>
          /// BindComboBox creates reactive combo box bindings for the items source, selected item,
          /// text, and selected index.
          /// </summary>
          /// <typeparam name="TParameter">The type of the property bound to in the view model.</typeparam>
          /// <typeparam name="TTargetClass">
          /// The type of the view model that owns the bound properties.
          /// </typeparam>
          /// <param name="comboName">The name of the combo box.</param>
          /// <param name="targetClassName">The name of the view model that owns the bound properties.</param>
          /// <param name="targetPropertyName">The name of the property bound to in the view model.</param>
          /// <param name="targetItemsName">
          /// The name of the items property bound to in the view model.
          /// </param>
          /// <param name="windowClass">The main window class instance. (Pass "this")</param>
          public static void BindComboBox<TParameter, TTargetClass>(
               string comboName,
               string targetClassName,
               string targetPropertyName,
               string targetItemsName,
               MainWindow windowClass)
          {
               ComboBox control = (ComboBox)windowClass.FindName(comboName);
               ParameterExpression mainWindowParameterExp = LExpression.Parameter(typeof(MainWindow), "x");
               MemberExpression mainVMRefExp = LExpression.Property(mainWindowParameterExp, "MainViewModel");
               MemberExpression viewModelExp = LExpression.Property(mainVMRefExp, targetClassName);

               // Bind combo box Items source.
               MemberExpression itemsExp = LExpression.Property(viewModelExp, targetItemsName);
               Expression<Func<MainWindow, IEnumerable>> targetItemsParameterExp =
                    LExpression.Lambda<Func<MainWindow, IEnumerable>>(
                         itemsExp,
                         new ParameterExpression[] { mainWindowParameterExp });

               Action<ComboBox, IEnumerable> controlItemsSetterAction =
                    CreateControlPropertySetterByName<ComboBox, IEnumerable>(
                         comboName,
                         "ItemsSource");

               windowClass.DisposeCollection.Add(
                  windowClass.WhenAnyValue(targetItemsParameterExp)
                  .Subscribe(delegate (IEnumerable x)
                  {
                       controlItemsSetterAction(control, x);
                  }));

               // Bind combo box SelectedItem.
               MemberExpression controlExp = LExpression.PropertyOrField(mainWindowParameterExp, comboName);
               MemberExpression controlSelectedItemExp = LExpression.Property(controlExp, "SelectedItem");
               Expression<Func<MainWindow, object>> controlSelectedItemParameterExp =
                    LExpression.Lambda<Func<MainWindow, object>>(
                         controlSelectedItemExp,
                         new ParameterExpression[] { mainWindowParameterExp });

               PropertyInfo targetClassPropertyInfo = windowClass.MainViewModel.GetType().GetProperty(targetClassName);
               TTargetClass targetClassInstance = (TTargetClass)targetClassPropertyInfo.GetGetMethod().Invoke(windowClass.MainViewModel, null);

               ParameterExpression targetViewModelParameter = LExpression.Parameter(typeof(TTargetClass), "viewModel");
               MemberExpression targetViewModelPropertyExp = LExpression.Property(targetViewModelParameter, targetPropertyName);
               Expression<Func<TTargetClass, TParameter>> targetBindingPropertyExp =
                    LExpression.Lambda<Func<TTargetClass, TParameter>>(
                         targetViewModelPropertyExp,
                         new ParameterExpression[] { targetViewModelParameter });

               windowClass.DisposeCollection.Add(
                   windowClass.WhenAnyValue(controlSelectedItemParameterExp)
                   .Where(x => x != null)
                   .BindTo(targetClassInstance, targetBindingPropertyExp));

               // Bind the combo box text to the target property. Numeric.
               MemberExpression controlTextPropertyExp = LExpression.Property(controlExp, "Text");
               Expression<Func<MainWindow, string>> controlTextParameterExp =
                    LExpression.Lambda<Func<MainWindow, string>>(
                         controlTextPropertyExp,
                         new ParameterExpression[] { mainWindowParameterExp });

               // Get the appropriate Regex string from the parameter type.
               string regexTest = string.Empty;
               if (targetViewModelPropertyExp.Type == typeof(double))
               {
                    regexTest = RegexFloat;
               }
               else if (targetViewModelPropertyExp.Type == typeof(int))
               {
                    regexTest = RegexInteger;
               }

               windowClass.DisposeCollection.Add(
                   windowClass.WhenAnyValue(controlTextParameterExp)
                   .Where(x => System.Text.RegularExpressions.Regex.IsMatch(x, regexTest) == true)
                   .BindTo(targetClassInstance, targetBindingPropertyExp));

               // Bind the combo box selected index to the target property.
               MemberExpression targetPropertyExp = LExpression.Property(viewModelExp, targetPropertyName);
               Expression<Func<MainWindow, TParameter>> targetParameterExp =
                   LExpression.Lambda<Func<MainWindow, TParameter>>(
                        targetPropertyExp,
                        new ParameterExpression[] { mainWindowParameterExp });

               Action<ComboBox, int> controlIndexSetterAction =
                    CreateControlPropertySetterByName<ComboBox, int>(
                         comboName,
                         "SelectedIndex");

               windowClass.DisposeCollection.Add(
                  windowClass.WhenAnyValue(targetParameterExp)
                  .Subscribe(delegate (TParameter x)
                  {
                       controlIndexSetterAction(control, control.Items.IndexOf(x));
                  }));
          }

          /// <summary>
          /// BindComboBox creates reactive combo box bindings for the items source, selected item,
          /// text, and selected index.
          /// </summary>
          /// <typeparam name="TParameter">The type of the property bound to in the view model.</typeparam>
          /// <typeparam name="TTargetClass">          
          /// The type of the view model that owns the bound properties.
          /// </typeparam>
          /// <typeparam name="TPage">The type of the page the control is on.</typeparam>
          /// <param name="comboName">The name of the combo box.</param>
          /// <param name="targetClassName">The name of the view model that owns the bound properties.</param>
          /// <param name="targetPropertyName">The name of the property bound to in the view model.</param>
          /// <param name="targetItemsName">
          /// The name of the items property bound to in the view model.
          /// </param>
          /// <param name="targetPage">The page that the control is on.</param>
          /// <param name="windowClass">The main window class instance. (Pass "this")</param>
          public static void BindComboBox<TParameter, TTargetClass, TPage>(
               string comboName,
               string targetClassName,
               string targetPropertyName,
               string targetItemsName,
               Page targetPage,
               MainWindow windowClass)
          {
               ComboBox control = (ComboBox)targetPage.FindName(comboName);
               ParameterExpression mainWindowParameterExp = LExpression.Parameter(typeof(MainWindow), "x");
               MemberExpression mainVMRefExp = LExpression.Property(mainWindowParameterExp, "MainViewModel");
               MemberExpression viewModelExp = LExpression.Property(mainVMRefExp, targetClassName);

               // Bind combo box Items source.
               MemberExpression itemsExp = LExpression.Property(viewModelExp, targetItemsName);
               Expression<Func<MainWindow, IEnumerable>> targetItemsParameterExp =
                    LExpression.Lambda<Func<MainWindow, IEnumerable>>(
                         itemsExp,
                         new ParameterExpression[] { mainWindowParameterExp });

               Action<ComboBox, IEnumerable> controlItemsSetterAction =
                    CreatePageControlPropertySetterByName<ComboBox, IEnumerable, TPage>(
                         comboName,
                         "ItemsSource");

               windowClass.DisposeCollection.Add(
                  windowClass.WhenAnyValue(targetItemsParameterExp)
                  .Subscribe(delegate (IEnumerable x)
                  {
                       controlItemsSetterAction(control, x);
                  }));

               // Bind combo box SelectedItem.
               MemberExpression pageExp = LExpression.PropertyOrField(mainWindowParameterExp, targetPage.Name);
               MemberExpression controlExp = LExpression.PropertyOrField(pageExp, comboName);
               MemberExpression controlSelectedItemExp = LExpression.Property(controlExp, "SelectedItem");

               Expression<Func<MainWindow, object>> controlSelectedItemParameterExp =
                    LExpression.Lambda<Func<MainWindow, object>>(
                         controlSelectedItemExp,
                         new ParameterExpression[] { mainWindowParameterExp });

               PropertyInfo targetClassPropertyInfo = windowClass.MainViewModel.GetType().GetProperty(targetClassName);
               TTargetClass targetClassInstance = (TTargetClass)targetClassPropertyInfo.GetGetMethod().Invoke(windowClass.MainViewModel, null);

               ParameterExpression targetViewModelParameter = LExpression.Parameter(typeof(TTargetClass), "viewModel");
               MemberExpression targetViewModelPropertyExp = LExpression.Property(targetViewModelParameter, targetPropertyName);
               Expression<Func<TTargetClass, TParameter>> targetBindingPropertyExp =
                    LExpression.Lambda<Func<TTargetClass, TParameter>>(
                         targetViewModelPropertyExp,
                         new ParameterExpression[] { targetViewModelParameter });

               windowClass.DisposeCollection.Add(
                   windowClass.WhenAnyValue(controlSelectedItemParameterExp)
                   .Where(x => x != null)
                   .BindTo(targetClassInstance, targetBindingPropertyExp));

               // Bind the combo box text to the target property. Numeric.
               MemberExpression controlTextPropertyExp = LExpression.Property(controlExp, "Text");
               Expression<Func<MainWindow, string>> controlTextParameterExp =
                    LExpression.Lambda<Func<MainWindow, string>>(
                         controlTextPropertyExp,
                         new ParameterExpression[] { mainWindowParameterExp });

               // Get the appropriate Regex string from the parameter type.
               string regexTest = string.Empty;
               if (targetViewModelPropertyExp.Type == typeof(double))
               {
                    regexTest = RegexFloat;
               }
               else if (targetViewModelPropertyExp.Type == typeof(int))
               {
                    regexTest = RegexInteger;
               }

               windowClass.DisposeCollection.Add(
                   windowClass.WhenAnyValue(controlTextParameterExp)
                   .Where(x => System.Text.RegularExpressions.Regex.IsMatch(x, regexTest) == true)
                   .BindTo(targetClassInstance, targetBindingPropertyExp));

               // Bind the combo box selected index to the target property.
               MemberExpression targetPropertyExp = LExpression.Property(viewModelExp, targetPropertyName);
               Expression<Func<MainWindow, TParameter>> targetParameterExp =
                   LExpression.Lambda<Func<MainWindow, TParameter>>(
                        targetPropertyExp,
                        new ParameterExpression[] { mainWindowParameterExp });

               Action<ComboBox, int> controlIndexSetterAction =
                    CreatePageControlPropertySetterByName<ComboBox, int, TPage>(
                         comboName,
                         "SelectedIndex");

               windowClass.DisposeCollection.Add(
                  windowClass.WhenAnyValue(targetParameterExp)
                  .Subscribe(delegate (TParameter x)
                  {
                       controlIndexSetterAction(control, control.Items.IndexOf(x));
                  }));
          }

          /// <summary>
          /// Binds a Halcon window to a View Roi Manager.
          /// </summary>
          /// <param name="manager">The View Roi Manager.</param>
          /// <param name="halconWindow">The Halcon window.</param>
          /// <param name="imageBorderName">
          /// The name of the Border Control containing the Halcon window control.
          /// </param>
          /// <param name="loadImageViewModelName">The name of the load image view model to use.</param>
          /// <param name="windowClass">The main window class instance. (Pass "this")</param>
          public static void BindHalconWindow(
               ViewROIManager manager,
               HSmartWindowControlWPF halconWindow,
               string imageBorderName,
               string loadImageViewModelName,
               MainWindow windowClass)
          {
               windowClass.DisposeCollection.Add(windowClass.Events().ContentRendered.Subscribe(_ =>
               {
                    // At initialization, the HSmartWindowWPF sometimes shows Width and Height = NaN 
                    // until reset with second image or a zoom.
                    // This code sets them to actual size before the first use. 
                    halconWindow.Width = halconWindow.ActualWidth;
                    halconWindow.Height = halconWindow.ActualHeight;

                    manager.LocHWindowControl = halconWindow;
                    manager.LocHWindowControl.HZoomContent = HSmartWindowControlWPF.ZoomContent.Off;

                    manager.LocHWindowControl.ContextMenu.ItemsSource = windowClass.MainViewModel.MenuItems;

                    // Set the data template.
                    manager.LocHWindowControl.ContextMenu.ItemTemplate = windowClass.ContextMenuDataTemplate;

                    // Set the ItemsPanelTemplate.
                    manager.LocHWindowControl.ContextMenu.ItemsPanel = windowClass.ContextMenuItemsPanelTemplate;

                    windowClass.DisposeCollection.Add(Observable.FromEventPattern<HSmartWindowControlWPF.HMouseEventArgsWPF>(manager.LocHWindowControl, "HMouseDoubleClick")
                    .Subscribe(a =>
                    {
                         manager.ZoomScale = 0;
                         windowClass.comboboxZoom.SelectedIndex =
                              windowClass.comboboxZoom.Items.IndexOf(
                                   windowClass.comboboxZoom.Items.OfType<ComboBoxItem>()
                                   .FirstOrDefault(x => x.Content.ToString() == "Fit"));
                    }));
               }));

               windowClass.DisposeCollection.Add(windowClass.MainViewModel.MenuItems.ItemsAdded
                   .Where(_ => manager.LocHWindowControl != null)
                   .Subscribe(
                    _ =>
                    {
                         manager.LocHWindowControl.ContextMenu.ItemsSource = windowClass.MainViewModel.MenuItems;

                         // Set the data template.
                         manager.LocHWindowControl.ContextMenu.ItemTemplate = windowClass.ContextMenuDataTemplate;

                         // Set the ItemsPanelTemplate.
                         manager.LocHWindowControl.ContextMenu.ItemsPanel = windowClass.ContextMenuItemsPanelTemplate;
                    }));

               windowClass.DisposeCollection.Add(windowClass.Events().LayoutUpdated
                    .Select(_ => System.Reactive.Unit.Default)
                    .InvokeCommand(manager.AdjustAspectCommand));

               ParameterExpression targetParameter = LExpression.Parameter(typeof(MainWindow), "x");
               MemberExpression mainVMExp = LExpression.Property(targetParameter, "MainViewModel");
               MemberExpression viewModelExp = LExpression.Property(mainVMExp, loadImageViewModelName);
               MemberExpression imageHeightExp = LExpression.Property(viewModelExp, "ImageHeight");
               MemberExpression imageWidthExp = LExpression.Property(viewModelExp, "ImageWidth");
               Expression<Func<MainWindow, int>> imageHeightTargetExp = LExpression.Lambda<Func<MainWindow, int>>(imageHeightExp, new ParameterExpression[] { targetParameter });
               Expression<Func<MainWindow, int>> imageWidthTargetExp = LExpression.Lambda<Func<MainWindow, int>>(imageWidthExp, new ParameterExpression[] { targetParameter });

               // Using Subscribe here because BindTo sets up a two-way binding which is not wanted.
               windowClass.DisposeCollection.Add(windowClass.WhenAnyValue(imageHeightTargetExp)
                   .Subscribe(x => manager.ImageHeight = x));
               windowClass.DisposeCollection.Add(windowClass.WhenAnyValue(imageWidthTargetExp)
                   .Subscribe(x => manager.ImageWidth = x));

               MemberExpression borderExp = LExpression.PropertyOrField(targetParameter, imageBorderName);
               MemberExpression actualHeightExp = LExpression.Property(borderExp, "ActualHeight");
               MemberExpression actualWidthExp = LExpression.Property(borderExp, "ActualWidth");
               Expression<Func<MainWindow, double>> actualHeightTargetExp = LExpression.Lambda<Func<MainWindow, double>>(actualHeightExp, new ParameterExpression[] { targetParameter });
               Expression<Func<MainWindow, double>> actualWidthTargetExp = LExpression.Lambda<Func<MainWindow, double>>(actualWidthExp, new ParameterExpression[] { targetParameter });

               windowClass.DisposeCollection.Add(windowClass.WhenAnyValue(actualHeightTargetExp)
                   .Subscribe(x => manager.ContainerHeight = x));
               windowClass.DisposeCollection.Add(windowClass.WhenAnyValue(actualWidthTargetExp)
                   .Subscribe(x => manager.ContainerWidth = x));
          }

          /// <summary>
          /// Creates two-way binding between a property in the target processor view model class and
          /// its represented property in the settings manager.
          /// </summary>
          /// <typeparam name="TParameter">The type of the property parameter.</typeparam>
          /// <typeparam name="TTargetClass">The type of the target class.</typeparam>
          /// <param name="targetClassName">The name of the target class.</param>
          /// <param name="targetPropertyName">The name of the property.</param>
          /// <param name="settingsManager">The calling instance of the SettingsManager class.</param>
          public static void BindSettingsProperty<TParameter, TTargetClass>(
               string targetClassName,
               string targetPropertyName,
               SettingsManager settingsManager)
          {
               var propertyInfo = typeof(ViewModels.MainViewModel).GetProperty(targetClassName);
               var targetClassInstance = (TTargetClass)propertyInfo.GetGetMethod().Invoke(settingsManager.MainViewModelRef, null);

               ParameterExpression targetParameter = LExpression.Parameter(typeof(SettingsManager), "x");
               MemberExpression mainVMRefExp = LExpression.Property(targetParameter, "MainViewModelRef");
               MemberExpression viewModelExp = LExpression.Property(mainVMRefExp, targetClassName);
               MemberExpression targetPropertyExp = LExpression.Property(viewModelExp, targetPropertyName);
               Expression<Func<SettingsManager, TParameter>> targetExp = LExpression.Lambda<Func<SettingsManager, TParameter>>(targetPropertyExp, new ParameterExpression[] { targetParameter });

               Action<SettingsManager, TParameter> targetSetterAction = CreateSetterByName<SettingsManager, TParameter>(targetPropertyName);

               settingsManager.DisposeCollection.Add(
                   settingsManager.WhenAnyValue(targetExp)
                   .Where(_ => !settingsManager.IsLoading)
                   .Subscribe(delegate (TParameter x)
                   {
                        targetSetterAction(settingsManager, x);
                   }));

               MemberExpression settingsPropertyExp = LExpression.Property(targetParameter, targetPropertyName);
               Expression<Func<SettingsManager, TParameter>> settingsExp = LExpression.Lambda<Func<SettingsManager, TParameter>>(settingsPropertyExp, new ParameterExpression[] { targetParameter });
               Action<TTargetClass, TParameter> settingsSetterAction = CreateSetterByName<TTargetClass, TParameter>(targetPropertyName);

               settingsManager.DisposeCollection.Add(
                  settingsManager.WhenAnyValue(settingsExp)
                  .Subscribe(delegate (TParameter x)
                  {
                       settingsSetterAction(targetClassInstance, x);
                  }));
          }

          /// <summary>
          /// Creates an action to set the named control property.
          /// </summary>
          /// <typeparam name="TEntity">The type of the class owning the property.</typeparam>
          /// <typeparam name="TProperty">The type of the property.</typeparam>
          /// <param name="controlName">The control name.</param>
          /// <param name="propertyName">The property name.</param>
          /// <returns>A setter Action for the control property.</returns>
          public static Action<TEntity, TProperty> CreateControlPropertySetterByName<TEntity, TProperty>(string controlName, string propertyName)
          {
               ParameterExpression targetParameter = LExpression.Parameter(typeof(MainWindow), "x");
               var controlExp = LExpression.PropertyOrField(targetParameter, controlName);
               MemberExpression targetPropertyExp = LExpression.Property(controlExp, propertyName);

               ParameterExpression paramExp = LExpression.Parameter(typeof(TEntity), "y");
               var targetExp = LExpression.Lambda<Func<TEntity, TProperty>>(targetPropertyExp, new ParameterExpression[] { paramExp });
               PropertyInfo propertyInfo = GetProperty(targetExp);

               ParameterExpression instance = LExpression.Parameter(typeof(TEntity), "instance");
               ParameterExpression parameter = LExpression.Parameter(typeof(TProperty), "parameter");

               var body = LExpression.Call(instance, propertyInfo.GetSetMethod(), parameter);
               var parameters = new ParameterExpression[] { instance, parameter };

               return LExpression.Lambda<Action<TEntity, TProperty>>(body, parameters).Compile();
          }

          /// <summary>
          /// Creates an action to set the named control property on a page.
          /// </summary>
          /// <typeparam name="TEntity">The type of the class owning the property.</typeparam>
          /// <typeparam name="TProperty">The type of the property.</typeparam>
          /// <typeparam name="TPage">The type of the Page the control is on.</typeparam>
          /// <param name="controlName">The control name.</param>
          /// <param name="propertyName">The property name.</param>
          /// <returns>A setter Action for the control property.</returns>
          public static Action<TEntity, TProperty> CreatePageControlPropertySetterByName<TEntity, TProperty, TPage>(string controlName, string propertyName)
          {
               ParameterExpression targetParameter = LExpression.Parameter(typeof(TPage), "x");
               var controlExp = LExpression.PropertyOrField(targetParameter, controlName);
               MemberExpression targetPropertyExp = LExpression.Property(controlExp, propertyName);

               ParameterExpression paramExp = LExpression.Parameter(typeof(TEntity), "y");
               var targetExp = LExpression.Lambda<Func<TEntity, TProperty>>(targetPropertyExp, new ParameterExpression[] { paramExp });
               PropertyInfo propertyInfo = GetProperty(targetExp);

               ParameterExpression instance = LExpression.Parameter(typeof(TEntity), "instance");
               ParameterExpression parameter = LExpression.Parameter(typeof(TProperty), "parameter");

               var body = LExpression.Call(instance, propertyInfo.GetSetMethod(), parameter);
               var parameters = new ParameterExpression[] { instance, parameter };

               return LExpression.Lambda<Action<TEntity, TProperty>>(body, parameters).Compile();
          }

          /// <summary>
          /// Creates an Action to set the named property.
          /// </summary>
          /// <typeparam name="TEntity">The type of the class owning the property.</typeparam>
          /// <typeparam name="TProperty">The type of the property.</typeparam>
          /// <param name="propertyName">The property name.</param>
          /// <returns>A setter Action for the property.</returns>
          public static Action<TEntity, TProperty> CreateSetterByName<TEntity, TProperty>(string propertyName)
          {
               ParameterExpression targetParameter = LExpression.Parameter(typeof(TEntity), "x");
               var targetPropertyExp = LExpression.Property(targetParameter, propertyName);
               var targetExp = LExpression.Lambda<Func<TEntity, TProperty>>(targetPropertyExp, new ParameterExpression[] { targetParameter });
               PropertyInfo propertyInfo = GetProperty(targetExp);

               ParameterExpression instance = LExpression.Parameter(typeof(TEntity), "instance");
               ParameterExpression parameter = LExpression.Parameter(typeof(TProperty), "parameter");

               var body = LExpression.Call(instance, propertyInfo.GetSetMethod(), parameter);
               var parameters = new ParameterExpression[] { instance, parameter };

               return LExpression.Lambda<Action<TEntity, TProperty>>(body, parameters).Compile();
          }

          /// <summary>
          /// Gets the member expression of the property in the passed expression.
          /// </summary>
          /// <typeparam name="TEntity">The type of the class owning the property.</typeparam>
          /// <typeparam name="TProperty">The type of the property.</typeparam>
          /// <param name="expression">The expression containing the property.</param>
          /// <returns>The member expression of the property.</returns>
          public static MemberExpression GetMemberExpression<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> expression)
          {
               MemberExpression memberExpression = null;
               if (expression.Body.NodeType == ExpressionType.Convert)
               {
                    var body = (UnaryExpression)expression.Body;
                    memberExpression = body.Operand as MemberExpression;
               }
               else if (expression.Body.NodeType == ExpressionType.MemberAccess)
               {
                    memberExpression = expression.Body as MemberExpression;
               }

               if (memberExpression == null)
               {
                    throw new ArgumentException("Not a member access", "expression");
               }

               return memberExpression;
          }

          /// <summary>
          /// Gets the property information from an expression.
          /// </summary>
          /// <typeparam name="TEntity">The type of the class owning the property.</typeparam>
          /// <typeparam name="TProperty">The type of the property.</typeparam>
          /// <param name="expression">The expression containing the property.</param>
          /// <returns>The property information.</returns>
          public static PropertyInfo GetProperty<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> expression)
          {
               var member = GetMemberExpression(expression).Member;
               var property = member as PropertyInfo;
               if (property == null)
               {
                    throw new InvalidOperationException(string.Format("Member with Name '{0}' is not a property.", member.Name));
               }

               return property;
          }

          /// <summary>
          /// Sets binding for a RadioButton that uses a converter to an enumeration of values.
          /// </summary>
          /// <param name="control">The UI control to bind.</param>
          /// <param name="viewModel">The view model to set as the data source.</param>
          /// <param name="pathString">
          /// The name of the property of the view model to which to bind data.
          /// </param>
          /// <param name="parameter">The converter parameter.</param>
          /// <remarks>
          /// Ensure that the enumeration value is present in RadioButtonSelection, otherwise a red
          /// outline will appear when the control is selected and conversion will not function.
          /// </remarks>
          public static void SetRadioButtonBinding(Control control, object viewModel, string pathString, string parameter)
          {
               Binding bind = new Binding()
               {
                    Source = viewModel,
                    Path = new System.Windows.PropertyPath(pathString),
                    Mode = BindingMode.TwoWay,
                    Converter = new View.RadioButtonCheckedToEnumConverter()
               };

               if (Enum.IsDefined(typeof(Models.RadioButtonSelection), parameter))
               {
                    // cast does not seem to be needed. 
                    bind.ConverterParameter = Enum.Parse(typeof(Models.RadioButtonSelection), parameter);
               }

              ((RadioButton)control).SetBinding(RadioButton.IsCheckedProperty, bind);
          }


          /// <summary>
          /// Sets binding for a RadioButton that uses a converter to a specified enumeration of values.
          /// </summary>
          /// <param name="control">The UI control to bind.</param>
          /// <param name="viewModel">The view model to set as the data source.</param>
          /// <param name="pathString">
          /// The name of the property of the view model to which to bind data.
          /// </param>
          /// <param name="parameter">The converter parameter.</param>
          /// <param name="enumType">The type of the enumeration to use.</param>
          /// <remarks>
          /// Ensure that the enumeration value is present in RadioButtonSelection, otherwise a red
          /// outline will appear when the control is selected and conversion will not function.
          /// </remarks>
          public static void SetRadioButtonBinding(Control control, object viewModel, string pathString, string parameter, Type enumType)
          {
               Binding bind = new Binding()
               {
                    Source = viewModel,
                    Path = new System.Windows.PropertyPath(pathString),
                    Mode = BindingMode.TwoWay,
                    Converter = new View.RadioButtonCheckedToEnumConverter()
               };

               if (Enum.IsDefined(enumType, parameter))
               {
                    bind.ConverterParameter = Enum.Parse(enumType, parameter);
               }

              ((RadioButton)control).SetBinding(RadioButton.IsCheckedProperty, bind);
          }
     }
}