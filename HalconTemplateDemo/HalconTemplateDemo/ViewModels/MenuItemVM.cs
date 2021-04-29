//-----------------------------------------------------------------------
// <copyright file="MenuItemVM.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.ViewModels
{
     using System.Reactive;
     using Models;
     using ReactiveUI;

     /// <summary>
     /// MenuItemVM is a small class that stores the objects needed for a context menu item.
     /// </summary>
     public class MenuItemVM
     {
          /// <summary>
          /// Initializes a new instance of the MenuItemVM class.
          /// </summary>
          /// <param name="name">The display name for the menu item.</param>
          /// <param name="command">The menu command.</param>
          public MenuItemVM(string name, ReactiveCommand<Unit, ProcessingResult> command)
          {
               this.DisplayName = name;
               this.MenuCommand = command;
          }

          /// <summary>
          /// Gets or sets the display name.
          /// </summary>
          public string DisplayName { get; set; }

          /// <summary>
          /// Gets or sets the command to be bound to the menu item.
          /// </summary>
          public ReactiveCommand<Unit, ProcessingResult> MenuCommand { get; protected set; }
     }
}