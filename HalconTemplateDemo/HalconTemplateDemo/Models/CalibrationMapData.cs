//-----------------------------------------------------------------------
// <copyright file="CalibrationMapData.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.Models
{
     using System;
     using HalconDotNet;
     using System.Xml.Serialization;

     /// <summary>
     /// Storage class for Calibration Map Data.
     /// </summary>
     [Serializable]
     public class CalibrationMapData
     {
          #region Private Declarations

          /// <summary>
          /// Stores the calibrated scale.
          /// </summary>
          private double calibratedScale = 0.5;

          /// <summary>
          /// Stores the final camera parameters.
          /// </summary>
          private HCamPar cameraParameters = new HCamPar();

          /// <summary>
          /// Stores the rectified image height.
          /// </summary>
          private int rectifiedImageHeight = 525;

          /// <summary>
          /// Stores the rectified image width.
          /// </summary>
          private int rectifiedImageWidth = 700;

          /// <summary>
          /// Stores the world pose.
          /// </summary>
          private HPose worldPose = new HPose();

          #endregion Private Declarations

          #region Constructors

          /// <summary>
          /// Initializes a new instance of the CalibrationMapData class.
          /// </summary>
          public CalibrationMapData()
          {
          }

          #endregion Constructors

          #region Public Properties

          /// <summary>
          /// Gets or sets the calibrated scale.
          /// </summary>
          public double CalibratedScale
          {
               get => this.calibratedScale;
               set => this.calibratedScale = value;
          }

          /// <summary>
          /// Gets or sets the final camera parameters.
          /// </summary>
          [XmlIgnore]
          public HCamPar CameraParameters
          {
               get => this.cameraParameters;
               set => this.cameraParameters = value;
          }

          /// <summary>
          /// Gets or sets a digital transfer property for the final camera parameters.
          /// </summary>
          public byte[] CameraParametersBuffer
          {
               get
               {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                         if (this.CameraParameters.RawData.Length == 9)
                         {
                              this.CameraParameters.Serialize(ms);
                              return ms.ToArray();
                         }
                         else
                         {
                              return new byte[0];
                         }
                    }
               }

               set
               {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(value))
                    {
                         if (value.Length > 0)
                         {
                              this.CameraParameters = HCamPar.Deserialize(ms);
                         }
                    }
               }
          }

          /// <summary>
          /// Gets or sets the rectified image height.
          /// </summary>
          public int RectifiedImageHeight
          {
               get => this.rectifiedImageHeight;
               set => this.rectifiedImageHeight = value;
          }

          /// <summary>
          /// Gets or sets the rectified image width.
          /// </summary>
          public int RectifiedImageWidth
          {
               get => this.rectifiedImageWidth;
               set => this.rectifiedImageWidth = value;
          }

          /// <summary>
          /// Gets or sets the world pose.
          /// </summary>
          [XmlIgnore]
          public HPose WorldPose
          {
               get => this.worldPose;
               set => this.worldPose = value;
          }

          /// <summary>
          /// Gets or sets a digital transfer property for world pose.
          /// </summary>
          [XmlAttribute]
          public byte[] WorldPoseBuffer
          {
               get
               {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                         if (this.WorldPose.RawData.Length == 7)
                         {
                              this.WorldPose.Serialize(ms);
                              return ms.ToArray();
                         }
                         else
                         {
                              return new byte[0];
                         }
                    }
               }

               set
               {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(value))
                    {
                         if (value.Length > 0)
                         {
                              this.WorldPose = HPose.Deserialize(ms);
                         }
                    }
               }
          }

          #endregion Public Properties
     }
}