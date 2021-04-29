//-----------------------------------------------------------------------
// <copyright file="SettingsManagerBase.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.Utilities
{
     using System;
     using System.Xml.Serialization;
     using ReactiveUI;
     using ViewModels;

     /// <summary>
     /// SettingsManagerBase is the base class for the Settings manager class. It supports access to
     /// the main view model.
     /// </summary>
     /// <typeparam name="MainVMClass">The main view model class.</typeparam>
     public abstract class SettingsManagerBase<MainVMClass> : ReactiveObject, IDisposable
         where MainVMClass : IMainViewModel
     {
          #region Private Fields

          /// <summary>
          /// Stores the CompositeDisposable that holds all subscription disposables.
          /// </summary>
          private readonly System.Reactive.Disposables.CompositeDisposable disposeCollection =
              new System.Reactive.Disposables.CompositeDisposable();

          /// <summary>
          /// Stores a value indicating whether the class has been disposed.
          /// </summary>
          private bool isDisposed = false;

          /// <summary>
          /// Stores a value indicating whether the class is loading settings.
          /// </summary>
          private bool isLoading = false;

          /// <summary>
          /// Stores a reference to the Main View Model.
          /// </summary>
          private MainVMClass mainViewModelRef;

          #endregion Private Fields

          #region Public Constructors

          /// <summary>
          /// Initializes a new instance of the SettingsManagerBase class in the derived class.
          /// </summary>
          /// <param name="mainVM">A reference to the main view model.</param>
          public SettingsManagerBase(IMainViewModel mainVM)
          {
               this.MainViewModelRef = (MainVMClass)mainVM;
          }

          /// <summary>
          /// Initializes a new instance of the SettingsManagerBase class.
          /// </summary>
          /// <remarks>This is the no-parameters overload needed for deserialization.</remarks>
          public SettingsManagerBase()
          {
          }

          #endregion Public Constructors

          #region Private Destructors

          /// <summary>
          /// Finalizes an instance of the SettingsManagerBase class.
          /// </summary>
          ~SettingsManagerBase() => this.Dispose(false);

          #endregion Private Destructors

          #region Public Properties

          /// <summary>
          /// Gets the disposeCollection.
          /// </summary>
          [XmlIgnore]
          public System.Reactive.Disposables.CompositeDisposable DisposeCollection =>
               this.disposeCollection;

          /// <summary>
          /// Gets or sets a value indicating whether the class is loading settings.
          /// </summary>
          [XmlIgnore]
          public bool IsLoading
          {
               get => this.isLoading;

               set => this.isLoading = value;
          }

          /// <summary>
          /// Gets or sets a reference to the MainViewModel.
          /// </summary>
          [XmlIgnore]
          public MainVMClass MainViewModelRef
          {
               get => this.mainViewModelRef;

               set
               {
                    this.mainViewModelRef = value;
                    this.IsLoading = true;
                    this.SetBindings();
               }
          }

          /// <summary>
          /// Gets a dynamic reference to the MainViewModel.
          /// </summary>
          [XmlIgnore]
          public dynamic MainViewModelRefDynamic => this.MainViewModelRef;

          #endregion Public Properties

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

          /// <summary>
          /// Abstract declaration of method to save the settings.
          /// </summary>
          public abstract void SaveSettings();

          /// <summary>
          /// Abstract declaration of method to set the bindings.
          /// </summary>
          public abstract void SetBindings();

          #endregion Public Methods

          #region Protected Methods

          /// <summary>
          /// Implements the Dispose method of IDisposable that actually disposes of managed resources.
          /// </summary>
          /// <param name="disposing">A boolean value indicating whether the class is being disposed.</param>
          protected virtual void Dispose(bool disposing)
          {
               if (!this.isDisposed)
               {
                    if (disposing)
                    {
                         // Code to dispose the managed resources held by the class.
                         if (this.disposeCollection != null)
                         {
                              this.disposeCollection.Dispose();
                         }
                    }

                    //// Dispose of unmanaged resources here.
               }

               this.isDisposed = true;
          }

          #endregion Protected Methods
     }
}