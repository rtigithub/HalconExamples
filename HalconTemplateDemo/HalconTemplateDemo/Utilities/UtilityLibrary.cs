//-----------------------------------------------------------------------
// <copyright file="UtilitiesMethods.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName",
    Justification = "Allow the name of the file to be used.")]

namespace HalconTemplateDemo.Utilities
{
     using System;
     using System.Collections.Generic;
     using System.IO;
     using System.Linq;
     using System.Text;
     using System.Threading.Tasks;
     using HalconDotNet;
     using Microsoft.Win32;

     public class UtilityLibrary : IDisposable
     {
          #region private fields

          /// <summary>
          /// Dialog for selecting a folder.
          /// </summary>
          private readonly System.Windows.Forms.FolderBrowserDialog folderDialog =
               new System.Windows.Forms.FolderBrowserDialog();

          /// <summary>
          /// A boolean value indicating whether the class is disposed.
          /// </summary>
          private bool isDisposed = false;

          /// <summary>
          /// Dialog for opening image files for load operations.
          /// </summary>
          private readonly OpenFileDialog openFileDialog = new OpenFileDialog();

          /// <summary>
          /// Dialog for getting a file name for save operations.
          /// </summary>
          private readonly SaveFileDialog saveFileDialog = new SaveFileDialog();

          #endregion private fields

          #region Public Constructors

          public UtilityLibrary()
          {
          }

          #endregion Public Constructors

          #region Private Destructors

          /// <summary>
          /// Finalizes an instance of the MainWindow class.
          /// </summary>
          ~UtilityLibrary() => this.Dispose(false);

          #endregion Private Destructors

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
          /// Returns an HTuple with only unique elements.
          /// </summary>
          /// <param name="input">The input HTuple.</param>
          /// <returns>The output HTuple.</returns>
          public static HTuple Unique(HTuple input)
          {
               HTuple output = new HTuple();
               int count = input.Length;

               if (input.Length > 0)
               {
                    output = output.TupleConcat(input[0]);

                    for (int i = 0; i < count; i++)
                    {
                         if (output.TupleFind(input[i]) == -1)
                         {
                              output = output.TupleConcat(input[i]);
                         }
                    }
               }

               return output;
          }

          /// <summary>
          /// Gets a file name through a dialog.
          /// </summary>
          /// <returns>The filename in a Task.</returns>
          public Task<string> GetCalibrationMapFileNameToSave()
          {
               SaveFileDialog saveFileDialog = new SaveFileDialog()
               {
                    DefaultExt = "tif",
                    FileName = "*.tif",
                    Filter =
                   "Image files (*.jpg,*.jpeg,*.bmp,*.gif,*.png,*.tif)|*.BMP;*.PNG;*.JPG;*.JPEG;*.PNG;*.TIF"
               };

               string file = string.Empty;

               bool? result = saveFileDialog.ShowDialog();

               if (result == true)
               {
                    file = saveFileDialog.FileName;

                    if (!file.EndsWith("tif"))
                    {
                         file = Path.GetFileNameWithoutExtension(file) + "tif";
                    }

                    return Task.FromResult(file);
               }
               else
               {
                    return Task.FromResult(string.Empty);
               }
          }

          /// <summary>
          /// Gets a file name through a dialog.
          /// </summary>
          /// <returns>The filename in a Task.</returns>
          public Task<string> GetFileName()
          {
               this.openFileDialog.DefaultExt = "png";
               this.openFileDialog.Filter =
                    "Image files (*.jpg,*.jpeg,*.bmp,*.gif,*.png,*.tif,*.seq)|*.BMP;*.PNG;*.JPG;*.JPEG;*.PNG;*.TIF;*.SEQ";

               bool? result = this.openFileDialog.ShowDialog();

               if (result == true)
               {
                    return Task.FromResult(this.openFileDialog.FileName);
               }
               else
               {
                    return Task.FromResult(string.Empty);
               }
          }

          /// <summary>
          /// Gets a file name through a dialog.
          /// </summary>
          /// <returns>The filename in a Task.</returns>
          public Task<string> GetFileNameToSave()
          {
               this.saveFileDialog.DefaultExt = "png";
               this.saveFileDialog.Filter =
                   "Image files (*.jpg,*.jpeg,*.bmp,*.gif,*.png,*.tif)|*.BMP;*.PNG;*.JPG;*.JPEG;*.PNG;*.TIF";

               bool? result = this.saveFileDialog.ShowDialog();

               if (result == true)
               {
                    return Task.FromResult(this.saveFileDialog.FileName);
               }
               else
               {
                    return Task.FromResult(string.Empty);
               }
          }

          /// <summary>
          /// Gets a folder name through a dialog.
          /// </summary>
          /// <returns>The folder in a Task.</returns>
          public Task<string> GetFolder()
          {
               if (this.folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                    return Task.FromResult(this.folderDialog.SelectedPath);
               }
               else
               {
                    return Task.FromResult(string.Empty);
               }
          }

          /// <summary>
          /// Gets a file name through a dialog.
          /// </summary>
          /// <returns>The filename in a Task.</returns>
          public Task<string> GetPngFileNameToSave()
          {
               this.openFileDialog.DefaultExt = "png";
               this.openFileDialog.Filter =
                    "Image files (*.png|*.PNG";
               string file;

               bool? result = this.saveFileDialog.ShowDialog();

               if (result == true)
               {
                    file = this.saveFileDialog.FileName;

                    if (!file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                         file = Path.ChangeExtension(file, ".png");
                    }

                    return Task.FromResult(this.saveFileDialog.FileName);
               }
               else
               {
                    return Task.FromResult(string.Empty);
               }
          }

          #endregion Public Methods

          #region Private Methods

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
                    }

                    //// Dispose of unmanaged resources.
               }

               this.isDisposed = true;
          }

          #endregion Private Methods
     }
}