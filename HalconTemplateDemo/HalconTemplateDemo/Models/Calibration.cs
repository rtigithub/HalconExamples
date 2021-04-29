//-----------------------------------------------------------------------
// <copyright file="Calibration.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.Models
{
     using System;

     /// <summary>
     /// Storage class for calibrations.
     /// </summary>
     public class Calibration : IEquatable<Calibration>
     {
          #region Private Declarations

          /// <summary>
          /// Stores an instance of a class containing a set of calibration parameters.
          /// </summary>
          private CameraCalibrationSetupParameters calibrationSetupParameters = new CameraCalibrationSetupParameters();

          /// <summary>
          /// Stores a value indicating whether new images should be corrected.
          /// </summary>
          private bool correctNewImages = true;

          /// <summary>
          /// Stores the calibration map data.
          /// </summary>
          private CalibrationMapData mapData = new CalibrationMapData();

          /// <summary>
          /// Stores the calibration name.
          /// </summary>
          private string name = string.Empty;

          /// <summary>
          /// Stores the unit text.
          /// </summary>
          private string unitText = "mm";

          #endregion Private Declarations

          #region Constructors

          /// <summary>
          /// Initializes a new instance of the Calibration class.
          /// </summary>
          public Calibration()
          {
          }

          #endregion Constructors

          #region Public Properties

          /// <summary>
          /// Gets or sets an instance of a class containing a set of calibration parameters.
          /// </summary>
          public CameraCalibrationSetupParameters CalibrationSetupParameters
          {
               get => this.calibrationSetupParameters;

               set => this.calibrationSetupParameters = value;
          }

          /// <summary>
          /// Gets or sets a value indicating whether new images should be corrected.
          /// </summary>
          public bool CorrectNewImages
          {
               get => this.correctNewImages;

               set => this.correctNewImages = value;
          }

          /// <summary>
          /// Gets or sets the calibration map data.
          /// </summary>
          public CalibrationMapData MapData
          {
               get => this.mapData;

               set => this.mapData = value;
          }

          /// <summary>
          /// Gets or sets the calibration name.
          /// </summary>
          public string Name
          {
               get => this.name;
               set => this.name = value;
          }

          /// <summary>
          /// Gets or sets the unit text.
          /// </summary>
          public string UnitText
          {
               get => this.unitText;
               set => this.unitText = value;
          }

          /// <summary>
          /// Overrides IEquatable Equals(object obj) method.
          /// </summary>
          /// <param name="obj">The object to check.</param>
          /// <returns>&gt;True if the calibration matches.</returns>
          public override bool Equals(object obj)
          {
               if (!(obj is Calibration otherObject))
               {
                    return false;
               }
               else
               {
                    return Equals(otherObject);
               }
          }

          /// <summary>
          /// Implementation of Equals method for IEquatable interface.
          /// </summary>
          /// <param name="other">The Calibration to check.</param>
          /// <returns>True if the calibration matches.</returns>
          public bool Equals(Calibration other)
          {
               return (this.Name == other.Name) &&
                      (this.UnitText == other.UnitText) &&
                      (this.CorrectNewImages == other.CorrectNewImages) &&
                      (this.CalibrationSetupParameters == other.CalibrationSetupParameters);
          }

          /// <summary>
          /// Overrides IEquatable GetHashCode method.
          /// </summary>
          /// <returns>An integer representing the hash code for selected Calibration fields.</returns>
          public override int GetHashCode()
          {
               return this.Name.GetHashCode() +
                    this.UnitText.GetHashCode() +
                    this.CalibrationSetupParameters.GetHashCode() +
                    this.CalibrationSetupParameters.GetHashCode();
          }

          #endregion Public Properties

          #region Public Methods

          #endregion Public Methods
     }
}
