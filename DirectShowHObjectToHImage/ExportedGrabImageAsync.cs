// ***********************************************************************
// Assembly         : DirectShowHObjectToHImage
// Author           : Bob Voigt
// Created          : 06-10-2016
//
// Last Modified By : Bob Voigt
// Last Modified On : 06-14-2016
// ***********************************************************************
// <copyright file="ExportedGrabImageAsync.cs" company="Resolution Technology, Inc.">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

// Wrap exported code with the DirectShowHObjectToHImage namespace.
namespace DirectShowHObjectToHImage
{
    using HalconDotNet;

    /// <summary>
    /// Class Form1.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1
    {
        #region Private Fields

        /// <summary>
        /// The Halcon image as HObject
        /// </summary>
        private HObject ho_Image = new HObject();

        /// <summary>
        ///
        /// </summary>
        private HTuple hv_AcqHandle;

        #endregion Private Fields

        #region Private Enums

        /// <summary>
        /// Enumeration of image types
        /// </summary>
        private enum imageType
        {
            /// <summary>
            /// A monochrome image
            /// </summary>
            monoImage = 1,

            /// <summary>
            /// An RGB image
            /// </summary>
            rgbImage = 3
        }

        #endregion Private Enums

        #region Public Properties

        /// <summary>
        /// Enum imageType
        /// </summary>
        /// <value>The Halcon image as HObject.</value>
        public HImage HalconImage
        {
            get
            {
                return HobjectToHimage(ho_Image);
            }

            set
            {
                this.ho_Image = value;
            }
        }

        /// <summary>
        /// Gets or sets the Halcon acquisition handle.
        /// </summary>
        /// <value>The Halcon acquisition handle.</value>
        public HTuple Hv_AcqHandle
        {
            get
            {
                return hv_AcqHandle;
            }

            set
            {
                this.hv_AcqHandle = value;
            }
        }

        #endregion Public Properties

#if !(NO_EXPORT_MAIN || NO_EXPORT_APP_MAIN)
        public HDevelopExport()
        {
            // Default settings used in HDevelop
            HOperatorSet.SetSystem("width", 512);
            HOperatorSet.SetSystem("height", 512);
            if (HalconAPI.isWindows)
                HOperatorSet.SetSystem("use_window_thread", "true");
            action();
        }
#endif

#if !NO_EXPORT_MAIN

        #region Private Methods

        /// <summary>
        /// Shuts down halcon.
        /// </summary>
        /// <param name="ho_Image">The ho_ image.</param>
        /// <param name="hv_AcqHandle">The HV_ acq handle.</param>
        private static void ShutDownHalcon(HObject ho_Image, HTuple hv_AcqHandle)
        {
            HOperatorSet.CloseFramegrabber(hv_AcqHandle);
            ho_Image.Dispose();
        }

        /// <summary>
        /// Actions this instance.
        /// </summary>
        private void action()
        {
            // Local iconic variables
            ho_Image = null;

            // Local control variables
            Hv_AcqHandle = null;

            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_Image);
            InitializeFramegrabber();
            while ((int)(1) != 0)
            {
                GrabImage();

                //Image Acquisition 01: Do something
            }

            ShutDownHalcon(HalconImage, Hv_AcqHandle);
        }

        // Main procedure
        /// <summary>
        /// Grabs the image.
        /// </summary>
        private void GrabImage()
        {
            HOperatorSet.GrabImageAsync(out ho_Image, Hv_AcqHandle, -1);
        }

        /// <summary>
        /// Hobjects to himage.
        /// </summary>
        /// <param name="_ho_Image">The _ho_ image.</param>
        /// <returns>HImage.</returns>
        private HImage HobjectToHimage(HObject _ho_Image)
        {
            HImage resultHImage = new HImage();
            if (_ho_Image.GetObjClass() == "image")
            {
                HTuple pointer = new HTuple(), type, width, height, channelCount;
                HTuple information = ho_Image.GetChannelInfo("type", 1);
                HOperatorSet.CountChannels(_ho_Image, out channelCount);
                switch (channelCount.I)
                {
                    case (int)imageType.monoImage:
                        lock (_ho_Image)
                        {
                            // for a monochrome image
                            HOperatorSet.GetImagePointer1(_ho_Image, out pointer, out type, out width, out height);
                            resultHImage = new HImage(type, width, height, pointer);
                        }

                        break;

                    case (int)imageType.rgbImage:
                        lock (_ho_Image)
                        {
                            // for an rgb image
                            HTuple pointerR, pointerG, pointerB;
                            HOperatorSet.GetImagePointer3(_ho_Image, out pointerR, out pointerG, out pointerB, out type, out width, out height);
                            HImage redImage = new HImage(),
                                greenImage = new HImage(),
                                blueImage = new HImage();
                            try
                            {
                                redImage = new HImage(type, width, height, pointerR);
                                greenImage = new HImage(type, width, height, pointerG);
                                blueImage = new HImage(type, width, height, pointerB);
                                resultHImage = redImage.Compose3(greenImage, blueImage);
                            }
                            finally
                            {
                                redImage.Dispose();
                                greenImage.Dispose();
                                blueImage.Dispose();
                            }
                        }

                        break;
                }
            }

            return resultHImage;
        }

        /// <summary>
        /// Initializes the framegrabber.
        /// </summary>
        private void InitializeFramegrabber()
        {
            //Image Acquisition 01: Code generated by Image Acquisition 01
            HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb",
                -1, "false", "default", "[0] Integrated Camera", 0, -1, out hv_AcqHandle);
            HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
        }

        #endregion Private Methods

#endif
    }

#if !(NO_EXPORT_MAIN || NO_EXPORT_APP_MAIN)
    public class HDevelopExportApp
    {
        /// <summary>
        /// The mono image
        /// </summary>
        static void Main(string[] args)

        /// <summary>
        /// The RGB image
        /// </summary>
        {
            new HDevelopExport();
        }
    }
#endif
}