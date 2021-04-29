//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo
{
     using System;
     using System.Security.Permissions;
     using System.Windows;

     /// <summary>
     /// Interaction logic for App.xaml
     /// </summary>
     public partial class App : Application
     {
          /// <summary>
          /// Initializes a new instance of the App class.
          /// </summary>        
          public App()
          {
               IDisposable disposableViewModel = null;

               // Create and show window while storing data context
               this.Startup += (sender, args) =>
               {
                    MainWindow = new MainWindow();
                    disposableViewModel = MainWindow.DataContext as IDisposable;

                    SplashScreen splashScreen = new SplashScreen("rti_logo.jpg");
                    splashScreen.Show(true, !System.Diagnostics.Debugger.IsAttached);
                    MainWindow.Show();
               };

               // Dispose on unhandled exception
               this.DispatcherUnhandledException += (sender, args) =>
               {
                    if (disposableViewModel != null)
                    {
                         disposableViewModel.Dispose();
                    }
               };

               // Dispose on exit
               this.Exit += (sender, args) =>
               {
                    if (disposableViewModel != null)
                    {
                         disposableViewModel.Dispose();
                    }
               };
          }

     }
}
