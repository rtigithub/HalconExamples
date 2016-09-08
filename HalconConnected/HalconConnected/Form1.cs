// ***********************************************************************
// Assembly         : WindowsFormsApplication1
// Created          : 09-07-2016
//
// Last Modified By : Bob Voigt
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="Form1.cs" company="Resolution Technology, Inc.">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WindowsFormsApplication1
{
    using System;
    using System.Windows.Forms;
    using HalconDotNet;

    /// <summary>
    /// Class Form1.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1 : Form
    {
      #region Private Fields

        /// <summary>
        /// The halcon window1.
        /// </summary>
        private HWindow HalconWindow1;

        /// <summary>
        /// The halcon window2.
        /// </summary>
        private HWindow HalconWindow2;

      #endregion Private Fields

      #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

      #endregion Public Constructors

      #region Public Methods

        /// <summary>
        /// Initializes the halcon display.
        /// </summary>
        public void InitializeHalconDisplay()
        {
            // Setting default settings here means that you do not have to specify when creating new HImage
            HOperatorSet.SetSystem("width", 512);
            HOperatorSet.SetSystem("height", 512);

            if (HalconAPI.isWindows)
            HOperatorSet.SetSystem("use_window_thread", "true");
            HalconWindow1 = HalconWindowControl1.HalconWindow;
            HalconWindow2 = HalconWindowControl2.HalconWindow;
            HalconWindow1.SetColored(6);
            HalconWindow2.SetColored(6);
        }

      #endregion Public Methods

      #region Private Methods

        /// <summary>
        /// Actions this instance.
        /// </summary>
        private void action()
        {
            // Local iconic variables
            HObject ho_ImageGrayRamp, ho_RegionLines, ho_RegionComplement;
            HObject ho_ConnectedRegions;

            // Local control variables
            HTuple hv_Number = null;

            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_ImageGrayRamp);
            HOperatorSet.GenEmptyObj(out ho_RegionLines);
            HOperatorSet.GenEmptyObj(out ho_RegionComplement);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            ho_ImageGrayRamp.Dispose();
            HOperatorSet.GenImageGrayRamp(out ho_ImageGrayRamp, 0, 0, 128, 256, 256, 512, 512);

            // Cast using as operator
            (ho_ImageGrayRamp as HImage).DispImage(HalconWindow1);

            // Traditional cast
            ((HImage)ho_ImageGrayRamp).DispImage(HalconWindow2);

            ho_RegionLines.Dispose();
            HOperatorSet.GenRegionLine(out ho_RegionLines, 100, -1, 150, 512);

            (ho_RegionLines as HRegion).DispRegion(HalconWindow1);
            ((HRegion)ho_RegionLines).DispRegion(HalconWindow2);

            ho_RegionComplement.Dispose();
            HOperatorSet.Complement(ho_RegionLines, out ho_RegionComplement);

            HOperatorSet.SetSystem("neighborhood", 4);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionComplement, out ho_ConnectedRegions);
            (ho_ConnectedRegions as HRegion).DispRegion(HalconWindow1);

            // Should be two objects
            HOperatorSet.CountObj(ho_ConnectedRegions, out hv_Number);
            label1.Text = "Number of objects 4-connected:" + hv_Number.ToString();

            HOperatorSet.SetSystem("neighborhood", 8);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionComplement, out ho_ConnectedRegions);
            ((HRegion)ho_ConnectedRegions).DispRegion(HalconWindow2);

            // Should be a single object
            HOperatorSet.CountObj(ho_ConnectedRegions, out hv_Number);
            label1.Text = "Number of objects 4-connected:" + hv_Number.ToString();

            ho_ImageGrayRamp.Dispose();
            ho_RegionLines.Dispose();
            ho_RegionComplement.Dispose();
            ho_ConnectedRegions.Dispose();
        }

        /// <summary>
        /// Handles the Shown event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            InitializeHalconDisplay();
            NeighborhoodTest();
        }

        /// <summary>
        /// Neighborhoods the test.
        /// </summary>
        private void NeighborhoodTest()
        {
            HImage image = new HImage("byte", 512, 512);
            HRegion regionLine = new HRegion();
            HRegion regionComplement = new HRegion();
            HRegion regionConnected = new HRegion();
            HTuple hv_DefWindow = new HTuple();
            HWindow HalconWindow1 = HalconWindowControl1.HalconWindow;
            HWindow HalconWindow2 = HalconWindowControl2.HalconWindow;

            try
            {
                HalconWindow1.SetColored(6);
                HalconWindow2.SetColored(6);
                int numObjects;

                image.GenImageGrayRamp(0, 0, 128, 256, 256, 512, 512);

                // Display code
                image.DispImage(HalconWindow1);
                image.DispImage(HalconWindow2);

                regionLine.GenRegionLine(100, -1, 150, 512);
                regionComplement = regionLine.Complement();

                HOperatorSet.SetSystem("neighborhood", 4);
                regionConnected = regionComplement.Connection();
                image.DispImage(HalconWindow1);
                regionConnected.DispRegion(HalconWindow1);

                numObjects = regionConnected.CountObj();
                label1.Text = "Number of objects 4-connected:" + numObjects.ToString();

                regionConnected.Dispose();
                HOperatorSet.SetSystem("neighborhood", 8);
                regionConnected = regionComplement.Connection();
                image.DispImage(HalconWindow2);
                regionConnected.DispRegion(HalconWindow2);

                numObjects = regionConnected.CountObj();
                label2.Text = "Number of objects 8-connected:" + numObjects.ToString();

                HOperatorSet.CloseWindow(HDevWindowStack.Pop());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                image.Dispose();
                regionLine.Dispose();
                regionConnected.Dispose();
                regionComplement.Dispose();
            }
        }

      #endregion Private Methods
    }
}