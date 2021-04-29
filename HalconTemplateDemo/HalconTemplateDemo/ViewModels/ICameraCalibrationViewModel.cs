//-----------------------------------------------------------------------
// <copyright file="ICameraCalibrationViewModel.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.ViewModels
{
     using System;
     using System.Reactive;
     using HalconDotNet;
     using Models;
     using ReactiveUI;
     using Rti.DisplayUtilities;

     /// <summary>
     /// Interface ICameraCalibrationViewModel
     /// </summary>
     public interface ICameraCalibrationViewModel
     {
          /// <summary>
          /// Gets the acquire calibration images command.
          /// </summary>
          /// <value>The acquire calibration images command.</value>
          ReactiveCommand<Unit, ProcessingResult> AcquireCalibrationImagesCommand { get; }

          /// <summary>
          /// Gets or sets a value indicating whether the initial parameters are valid.
          /// </summary>
          /// <value><c>true</c> if the initial parameters are valid; otherwise, <c>false</c>.</value>
          bool AreInitialParametersValid { get; set; }

          /// <summary>
          /// Gets or sets the calibrate can execute observable.
          /// </summary>
          /// <value>The calibrate can execute observable.</value>
          IObservable<bool> CalibrateCanExecute { get; set; }

          /// <summary>
          /// Gets the calibrate command.
          /// </summary>
          /// <value>The calibrate command.</value>
          ReactiveCommand<Unit, ProcessingResult> CalibrateCommand { get; }

          /// <summary>
          /// Gets or sets the calibrated scale.
          /// </summary>
          /// <value>The calibrated scale.</value>
          double CalibratedScale { get; set; }

          /// <summary>
          /// Gets or sets the name of the calibration image folder.
          /// </summary>
          /// <value>The name of the calibration image folder.</value>
          string CalibrationImageFolderName { get; set; }

          /// <summary>
          /// Gets or sets the calibration map.
          /// </summary>
          /// <value>The calibration map.</value>
          HImage CalibrationMap { get; set; }

          /// <summary>
          /// Gets or sets the name of the calibration map load file.
          /// </summary>
          /// <value>The name of the calibration map load file.</value>
          string CalibrationMapLoadFileName { get; set; }

          /// <summary>
          /// Gets or sets the name of the calibration map save file.
          /// </summary>
          /// <value>The name of the calibration map save file.</value>
          string CalibrationMapSaveFileName { get; set; }

          /// <summary>
          /// Gets or sets the calibration test image.
          /// </summary>
          /// <value>The calibration test image.</value>
          HImage CalibrationTestImage { get; set; }

          /// <summary>
          /// Gets or sets the camera type.
          /// </summary>
          /// <value>The camera type.</value>
          string CameraType { get; set; }

          /// <summary>
          /// Gets or sets the camera type parameters.
          /// </summary>
          /// <value>The camera type parameters.</value>
          HTuple CameraTypeParameters { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether new images should be corrected.
          /// </summary>
          /// <value><c>true</c> if new images should be corrected; otherwise, <c>false</c>.</value>
          bool CorrectNewImages { get; set; }

          /// <summary>
          /// Gets or sets the display.
          /// </summary>
          /// <value>The display.</value>
          DisplayCollection Display { get; set; }

          /// <summary>
          /// Gets or sets the focal length.
          /// </summary>
          /// <value>The focal length.</value>
          double FocalLength { get; set; }

          /// <summary>
          /// Gets or sets the name of the halcon calibration plate.
          /// </summary>
          /// <value>The name of the halcon calibration plate.</value>
          string HalconCalibrationPlateName { get; set; }

          /// <summary>
          /// Gets or sets the halcon calibration plate parameters.
          /// </summary>
          /// <value>The halcon calibration plate parameters.</value>
          HTuple HalconCalibrationPlateParameters { get; set; }

          /// <summary>
          /// Gets or sets the height of the image.
          /// </summary>
          /// <value>The height of the image.</value>
          int ImageHeight { get; set; }

          /// <summary>
          /// Gets or sets the width of the image.
          /// </summary>
          /// <value>The width of the image.</value>
          int ImageWidth { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether the process is busy.
          /// </summary>
          /// <value><c>true</c> if the process is busy; otherwise, <c>false</c>.</value>
          bool IsBusy { get; set; }

          /// <summary>
          /// Gets or sets the load calibration images from file can execute observable.
          /// </summary>
          /// <value>The load calibration images from file can execute observable.</value>
          IObservable<bool> LoadCalibImagesFromFileCanExecute { get; set; }

          /// <summary>
          /// Gets the load calibration images from file command.
          /// </summary>
          /// <value>The load calibration images from file command.</value>
          ReactiveCommand<Unit, ProcessingResult> LoadCalibImagesFromFileCommand { get; }

          /// <summary>
          /// Gets the load calibration map command.
          /// </summary>
          /// <value>The load calibration map command.</value>
          ReactiveCommand<Unit, ProcessingResult> LoadCalibrationMapCommand { get; }

          /// <summary>
          /// Gets or sets a value indicating whether the test image is loading.
          /// </summary>
          /// <value><c>true</c> if the test image is loading; otherwise, <c>false</c>.</value>
          bool LoadingTestImage { get; set; }

          /// <summary>
          /// Gets or sets the load test calibration image can execute observable.
          /// </summary>
          /// <value>The load test calibration image can execute observable.</value>
          IObservable<bool> LoadTestCalibrationImageCanExecute { get; set; }

          /// <summary>
          /// Gets the processing results.
          /// </summary>
          /// <value>The processing results.</value>
          ProcessingResult ProcessingResults { get; }

          /// <summary>
          /// Gets the processing results for the calibrate command.
          /// </summary>
          /// <value>The processing results for the calibrate command.</value>
          ProcessingResult ProcessingResultsCalibrate { get; }

          /// <summary>
          /// Gets or sets the height of the rectified image.
          /// </summary>
          /// <value>The height of the rectified image.</value>
          int RectifiedImageHeight { get; set; }

          /// <summary>
          /// Gets or sets the width of the rectified image.
          /// </summary>
          /// <value>The width of the rectified image.</value>
          int RectifiedImageWidth { get; set; }

          /// <summary>
          /// Gets or sets the file in which to save the rectified test image.
          /// </summary>
          /// <value>The file in which to save the rectified test image.</value>
          string RectifiedTestImageSaveName { get; set; }

          /// <summary>
          /// Gets or sets the rectify image can execute observable.
          /// </summary>
          /// <value>The rectify image can execute observable.</value>
          IObservable<bool> RectifyImageCanExecute { get; set; }

          /// <summary>
          /// Gets the rectify image command.
          /// </summary>
          /// <value>The rectify image command.</value>
          ReactiveCommand<Unit, ProcessingResult> RectifyImageCommand { get; }

          /// <summary>
          /// Gets the reset calibration images command.
          /// </summary>
          /// <value>The reset calibration images command.</value>
          ReactiveCommand<Unit, ProcessingResult> ResetCalibrationImagesCommand { get; }

          /// <summary>
          /// Gets or sets the rotation.
          /// </summary>
          /// <value>The rotation.</value>
          double Rotation { get; set; }

          /// <summary>
          /// Gets or sets the rotation in the x direction.
          /// </summary>
          /// <value>The rotation in the x direction.</value>
          double RotX { get; set; }

          /// <summary>
          /// Gets or sets the rotation in the y direction.
          /// </summary>
          /// <value>The rotation in the y direction.</value>
          double RotY { get; set; }

          /// <summary>
          /// Gets or sets the rotation in the z direction.
          /// </summary>
          /// <value>The rotation in the z direction.</value>
          double RotZ { get; set; }

          /// <summary>
          /// Gets or sets the save calibration map can execute observable.
          /// </summary>
          /// <value>The save calibration map can execute observable.</value>
          IObservable<bool> SaveCalibrationMapCanExecute { get; set; }

          /// <summary>
          /// Gets the save calibration map command.
          /// </summary>
          /// <value>The save calibration map command.</value>
          ReactiveCommand<Unit, ProcessingResult> SaveCalibrationMapCommand { get; }

          /// <summary>
          /// Gets or sets the save rectified image can execute observable.
          /// </summary>
          /// <value>The save rectified image can execute observable.</value>
          IObservable<bool> SaveRectifiedImageCanExecute { get; set; }

          /// <summary>
          /// Gets the save rectified image command.
          /// </summary>
          /// <value>The save rectified image command.</value>
          ReactiveCommand<Unit, ProcessingResult> SaveRectifiedImageCommand { get; }

          /// <summary>
          /// Gets or sets the sensor size x.
          /// </summary>
          /// <value>The sensor size x.</value>
          double SensorSizeX { get; set; }

          /// <summary>
          /// Gets or sets the sensor size y.
          /// </summary>
          /// <value>The sensor size y.</value>
          double SensorSizeY { get; set; }

          /// <summary>
          /// Gets or sets the set parameters can execute observable.
          /// </summary>
          /// <value>The set parameters can execute observable.</value>
          IObservable<bool> SetParametersCanExecute { get; set; }

          /// <summary>
          /// Gets the set parameters command.
          /// </summary>
          /// <value>The set parameters command.</value>
          ReactiveCommand<Unit, ProcessingResult> SetParametersCommand { get; }

          /// <summary>
          /// Gets or sets the tilt.
          /// </summary>
          /// <value>The tilt.</value>
          double Tilt { get; set; }

          /// <summary>
          /// Gets or sets the translation in the x direction.
          /// </summary>
          /// <value>The translation in the x direction.</value>
          double TransX { get; set; }

          /// <summary>
          /// Gets or sets the translation in the y direction.
          /// </summary>
          /// <value>The translation in the y direction.</value>
          double TransY { get; set; }

          /// <summary>
          /// Gets or sets the translation in the z direction.
          /// </summary>
          /// <value>The translation in the z direction.</value>
          double TransZ { get; set; }

          /// <summary>
          /// Gets or sets the index of the world pose.
          /// </summary>
          /// <value>The index of the world pose.</value>
          int WorldPoseIndex { get; set; }
     }
}