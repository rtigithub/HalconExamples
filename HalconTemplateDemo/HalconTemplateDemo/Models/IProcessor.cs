//-----------------------------------------------------------------------
// <copyright file="IProcessor.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.Models
{
     using Rti.DisplayUtilities;

     /// <summary>
     /// Interface for the processor classes.
     /// </summary>
     public interface IProcessor
     {
          /// <summary>
          /// Gets or sets the debug DisplayCollection.
          /// </summary>
          DisplayCollection DebugDisplay
          {
               get;
               set;
          }

          /// <summary>
          /// Gets or sets the CompositeDisposable object.
          /// </summary>
          System.Reactive.Disposables.CompositeDisposable DisposeCollection
          {
               get;
               set;
          }

          /// <summary>
          /// Gets or sets the error code.
          /// </summary>
          ProcessingErrorCode ErrorCode
          {
               get;
               set;
          }

          /// <summary>
          /// Gets or sets the error message.
          /// </summary>
          string ErrorMessage
          {
               get;
               set;
          }

          /// <summary>
          /// Implements the Dispose method of IDisposable.
          /// </summary>
          void Dispose();

          /// <summary>
          /// Performs the process for this class.
          /// </summary>
          /// <returns>A structure containing the processing results and error information.</returns>
          ProcessingResult Process();
     }
}