//-----------------------------------------------------------------------
// <copyright file="CameraCalibrationSetupParameters.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.Models
{
     public class CameraCalibrationSetupParameters
     {
          /// <summary>
          /// Stores the calibrated scale.
          /// </summary>
          private double calibratedScale = 0.5;

          /// <summary>
          /// Stores the camera type.
          /// </summary>
          private string cameraType = "area_scan_division";

          /// <summary>
          /// Stores a value indicating whether the Z rotation in the world pose 
          /// should be canceled.
          /// </summary>
          private bool cancelZRotation = false;

          /// <summary>
          /// Stores the focal length.
          /// </summary>
          private double focalLength = 0.016;

          /// <summary>
          /// Stores the name of the halcon calibration plate.
          /// </summary>
          private string halconCalibrationPlateName = "calplate_320mm.cpd";

          /// <summary>
          /// Stores the image height.
          /// </summary>
          private int imageHeight = 480;

          /// <summary>
          /// Stores a factor for additional scaling of a calibration map.
          /// </summary>
          private double imageScaling = 1;

          /// <summary>
          /// Stores the image width.
          /// </summary>
          private int imageWidth = 640;

          /// <summary>
          /// Stores a value indicating whether to lock the aspect ratio 
          /// of the rectified width and height.
          /// </summary>
          private bool lockAspectRatio = true;

          /// <summary>
          /// Stores a value indicating whether the calibration map should preserve the original
          /// image resolution.
          /// </summary>
          private bool preserveResolution = false;

          /// <summary>
          /// Stores the rectified image height.
          /// </summary>
          private int rectifiedImageHeight = 525;

          /// <summary>
          /// Stores the rectified image width.
          /// </summary>
          private int rectifiedImageWidth = 700;

          /// <summary>
          /// Stores the sensor size in the X direction.
          /// </summary>
          private double sensorSizeX = 0.005;

          /// <summary>
          /// Stores the sensor size in the Y direction.
          /// </summary>
          private double sensorSizeY = 0.005;

          /// <summary>
          /// Stores the index into the poses in the camera parameters to use as the world pose.
          /// </summary>
          private int worldPoseIndex = 0;

          /// <summary>
          /// Initializes a new instance of the CameraCalibrationSetupParameters class.
          /// </summary>
          public CameraCalibrationSetupParameters()
          {
          }

          /// <summary>
          /// Gets or sets the calibrated scale.
          /// </summary>
          public double CalibratedScale
          {
               get => this.calibratedScale;

               set => this.calibratedScale = value;
          }

          /// <summary>
          /// Gets or sets the camera type.
          /// </summary>
          public string CameraType
          {
               get => this.cameraType;

               set => this.cameraType = value;
          }

          /// <summary>
          /// Gets or sets a value indicating whether the Z rotation in the world pose 
          /// should be canceled.
          /// </summary>
          public bool CancelZRotation
          {
               get => this.cancelZRotation;
               set => this.cancelZRotation = value;
          }

          /// <summary>
          /// Gets or sets the focal length.
          /// </summary>
          public double FocalLength
          {
               get => this.focalLength;

               set => this.focalLength = value;
          }

          /// <summary>
          /// Gets or sets the name of the halcon calibration plate.
          /// </summary>
          public string HalconCalibrationPlateName
          {
               get => this.halconCalibrationPlateName;

               set => this.halconCalibrationPlateName = value;
          }

          /// <summary>
          /// Gets or sets the image height.
          /// </summary>
          public int ImageHeight
          {
               get => this.imageHeight;

               set => this.imageHeight = value;
          }

          /// <summary>
          /// Gets or sets a factor for additional scaling of a calibration map.
          /// </summary>
          public double ImageScaling
          {
               get => this.imageScaling;
               set => this.imageScaling = value;
          }

          /// <summary>
          /// Gets or sets the image width.
          /// </summary>
          public int ImageWidth
          {
               get => this.imageWidth;

               set => this.imageWidth = value;
          }

          /// <summary>
          /// Gets or sets a value indicating whether to lock the aspect ratio 
          /// of the rectified width and height.
          /// </summary>
          public bool LockAspectRatio
          {
               get => this.lockAspectRatio;

               set => this.lockAspectRatio = value;
          }

          /// <summary>
          /// Gets or sets a value indicating whether the calibration map should preserve the 
          /// original image resolution.
          /// </summary>
          public bool PreserveResolution
          {
               get => this.preserveResolution;
               set => this.preserveResolution = value;
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
          /// Gets or sets the sensor size in the X direction.
          /// </summary>
          public double SensorSizeX
          {
               get => this.sensorSizeX;

               set => this.sensorSizeX = value;
          }

          /// <summary>
          /// Gets or sets the sensor size in the Y direction.
          /// </summary>
          public double SensorSizeY
          {
               get => this.sensorSizeY;

               set => this.sensorSizeY = value;
          }

          /// <summary>
          /// Gets or sets the index into the poses in the camera parameters to use as the world pose.
          /// </summary>
          public int WorldPoseIndex
          {
               get => this.worldPoseIndex;

               set => this.worldPoseIndex = value;
          }
     }
}
