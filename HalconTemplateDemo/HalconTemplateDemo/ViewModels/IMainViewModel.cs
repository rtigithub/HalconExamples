//-----------------------------------------------------------------------
// <copyright file="IMainViewModel.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.ViewModels
{
     using System;

     /// <summary>
     /// Interface for the main view model classes.
     /// </summary>
     public interface IMainViewModel
     {
          /// <summary>
          /// Gets or sets the app state.
          /// </summary>
          int AppState { get; set; }

          /// <summary>
          /// Gets the CompositeDisposable object.
          /// </summary>
          System.Reactive.Disposables.CompositeDisposable DisposeCollection { get; }

          /// <summary>
          /// Gets or sets the reactive list of Menu Item view models.
          /// </summary>
          ReactiveUI.ReactiveList<MenuItemVM> MenuItems { get; set; }

          /// <summary>
          /// Gets or sets the DataSet that stores the processing result.
          /// </summary>
          System.Data.DataSet ProcessingResultsDataSet { get; set; }

          /// <summary>
          /// Gets or sets the status text.
          /// </summary>
          string StatusText { get; set; }

          /// <summary>
          /// Implements the Dispose method of IDisposable.
          /// </summary>
          void Dispose();
     }
}