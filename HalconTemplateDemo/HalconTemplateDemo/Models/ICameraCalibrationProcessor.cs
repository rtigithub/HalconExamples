// *********************************************************************** 
// Assembly : HalconTemplateDemo Author : Resolution Technology, Inc. 
// Created : 06-15-2017 
// Last Modified On : 06-15-2017 
// ***********************************************************************
// <copyright file="ICameraCalibrationProcessor.cs" company="Resolution Technology, Inc.">
//     Copyright © 2016, 2017
// </copyright>
// <summary>
// </summary>
// ***********************************************************************

using HalconDotNet;

namespace HalconTemplateDemo.Models
{
     /// <summary>
     /// Interface ICameraCalibrationProcessor
     /// </summary>
     public interface ICameraCalibrationProcessor
     {
          /// <summary>
          /// Gets or sets a value indicating whether calibration images set.
          /// </summary>
          /// <value><c>true</c> if calibration images set; otherwise, <c>false</c>.</value>
          bool AreCalibrationImagesSet { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether calibration parameters set.
          /// </summary>
          /// <value><c>true</c> if calibration parameters set; otherwise, <c>false</c>.</value>
          bool AreCalibrationParametersSet { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether calibration is done.
          /// </summary>
          /// <value><c>true</c> if calibration is done; otherwise, <c>false</c>.</value>
          bool CalibrationIsDone { get; set; }

          /// <summary>
          /// Gets or sets the calibration map.
          /// </summary>
          /// <value>The calibration map.</value>
          HImage CalibrationMap { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether the calibration map is present.
          /// </summary>
          /// <value><c>true</c> if the calibration map is present; otherwise, <c>false</c>.</value>
          bool IsCalibrationMapPresent { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether a rectified test image is present.
          /// </summary>
          /// <value><c>true</c> if whether a rectified test image is present; otherwise, <c>false</c>.</value>
          bool IsRectifiedTestImagePresent { get; set; }

          /// <summary>
          /// Gets or sets the rectified test image.
          /// </summary>
          /// <value>The rectified test image.</value>
          HImage RectifiedTestImage { get; set; }

          /// <summary>
          /// Calibrates the specified image.
          /// </summary>
          /// <param name="imageWidth">Width of the image.</param>
          /// <param name="imageHeight">Height of the image.</param>
          /// <param name="rectifiedImageWidth">Width of the rectified image.</param>
          /// <param name="rectifiedImageHeight">Height of the rectified image.</param>
          /// <param name="calibratedScale">The calibrated scale.</param>
          /// <param name="imageScaling">A scaling factor applied to the rectified image size to adjust the resolution. 
          /// Also used to back-convert rectified coordinates to their rectified values.</param>
          /// <param name="preserveResolution">A boolean value indicating whether to preserve the 
          /// original image resolution in the rectified image.</param>
          /// <param name="lockAspectRatio">A boolean value indicating whether the rectified image 
          /// width and height are locked to the original aspect ratio.</param>
          /// <param name="cancelZRotation">A boolean value indicating whether the Z rotation of the 
          /// world pose should be canceled for the rectified image.</param>
          /// <param name="worldPoseIndex">Index of the world pose.</param>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult Calibrate(
               int imageWidth,
               int imageHeight,
               int rectifiedImageWidth,
               int rectifiedImageHeight,
               double calibratedScale,
               double imageScaling,
               bool preserveResolution,
               bool lockAspectRatio,
               bool cancelZRotation,
               int worldPoseIndex);

          /// <summary>
          /// Loads calibration images.
          /// </summary>
          /// <param name="folderName">Name of the folder containing the images.</param>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult LoadCalibrationImages(string folderName);

          /// <summary>
          /// Loads a calibration map.
          /// </summary>
          /// <param name="fileName">Name of the file.</param>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult LoadCalibrationMap(string fileName);

          /// <summary>
          /// The default Process method.
          /// </summary>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult Process();

          /// <summary>
          /// Processes an acquired calibration image.
          /// </summary>
          /// <param name="image">The image.</param>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult ProcessAcquiredCalibrationImage(HImage image);

          /// <summary>
          /// Rectifies an image.
          /// </summary>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult RectifyImage();

          /// <summary>
          /// Resets the calibration images.
          /// </summary>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult ResetCalibrationImages();

          /// <summary>
          /// Saves the calibration map.
          /// </summary>
          /// <param name="fileName">Name of the file into which to save the map.</param>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult SaveCalibrationMap(string fileName);

          /// <summary>
          /// Saves the rectified test image.
          /// </summary>
          /// <param name="fileName">Name of the file into which to save the rectified test image.</param>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult SaveRectifiedTestImage(string fileName);

          /// <summary>
          /// Sets the initial parameters.
          /// </summary>
          /// <param name="cameraType">Type of the camera.</param>
          /// <param name="focalLength">Focal length.</param>
          /// <param name="imageWidth">Width of the image.</param>
          /// <param name="imageHeight">Height of the image.</param>
          /// <param name="sensorSizeX">The sensor size in the x direction.</param>
          /// <param name="sensorSizeY">The sensor size in the y direction.</param>
          /// <param name="rotation">The rotation.</param>
          /// <param name="tilt">The tilt.</param>
          /// <param name="halconCalibrationPlateName">Name of the halcon calibration plate.</param>
          /// <returns>A ProcessingResult instance.</returns>
          ProcessingResult SetInitialParameters(string cameraType, double focalLength, int imageWidth, int imageHeight, double sensorSizeX, double sensorSizeY, double rotation, double tilt, string halconCalibrationPlateName);
     }
}