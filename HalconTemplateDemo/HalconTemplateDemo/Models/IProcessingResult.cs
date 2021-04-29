//-----------------------------------------------------------------------
// <copyright file="IProcessingResult.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.Models
{
     /// <summary>
     /// Interface for ProcessingResult
     /// </summary>
     public interface IProcessingResult<ErrorCodeT>
     {
          /// <summary>
          /// Gets or sets the error message.
          /// </summary>
          string ErrorMessage
          {
               get;
               set;
          }

          /// <summary>
          /// Gets or sets the error code.
          /// </summary>
          ErrorCodeT StatusCode
          {
               get;
               set;
          }

          /// <summary>
          /// Implements the Dispose method of IDisposable.
          /// </summary>
          void Dispose();
     }
}