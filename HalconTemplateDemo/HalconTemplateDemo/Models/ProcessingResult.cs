//-----------------------------------------------------------------------
// <copyright file="ProcessingResult.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.Models
{
     using System.Collections.Generic;
     using HalconDotNet;

     /// <summary>
     /// This class encapsulates the results from a generic process.
     /// </summary>
     public class ProcessingResult : ProcessingResultsBase<ProcessingErrorCode>
     {
          #region Private Fields

          /// <summary>
          /// Stores a value indicating whether the class has been disposed.
          /// </summary>
          private bool isDisposed = false;

          /// <summary>
          /// Stores a dictionary of results.
          /// </summary>
          private Dictionary<string, object> resultsCollection = new Dictionary<string, object>();

          #endregion Private Fields

          #region Public Constructors

          /// <summary>
          /// Initializes a new instance of the ProcessingResult class.
          /// </summary>
          public ProcessingResult()
          {
               this.StatusCode = ProcessingErrorCode.NoError;
          }

          #endregion Public Constructors

          #region Private Destructors

          #endregion Private Destructors

          #region Public Properties

          /// <summary>
          /// Gets or sets a dictionary of results.
          /// </summary>
          public Dictionary<string, object> ResultsCollection
          {
               get => this.resultsCollection;

               set => this.resultsCollection = value;
          }

          #endregion Public Properties

          #region Public Methods

          #endregion Public Methods

          #region Protected Methods

          /// <summary>
          /// Overrides the Dispose method of IDisposable that actually disposes of managed resources.
          /// </summary>
          /// <param name="disposing">A boolean value indicating whether the class is being disposed.</param>
          protected override void Dispose(bool disposing)
          {
               if (!this.isDisposed)
               {
                    if (disposing)
                    {
                         //// Dispose of managed resources here.
                    }

                    foreach (var item in this.ResultsCollection)
                    {
                         if (item.Value is HObject)
                         {
                              ((HObject)item.Value).Dispose();
                         }
                    }

                    this.ResultsCollection.Clear();

                    //// Dispose of unmanaged resources here.

                    this.isDisposed = true;
               }

               // Call base.Dispose, passing parameter.
               base.Dispose(disposing);
          }

          #endregion Protected Methods
     }
}