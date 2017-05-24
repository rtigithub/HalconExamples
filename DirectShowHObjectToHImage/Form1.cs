// ***********************************************************************
// Assembly         : DirectShowHObjectToHImage
// Author           : Resolution Technology, Inc.
// Created          : 09-07-2016
// Last Modified On : 05-24-2017
// ***********************************************************************
// <copyright file="Form1.cs" company="Resolution Technology, Inc.">
//     Copyright ©  2016, 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace DirectShowHObjectToHImage
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class Form1.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1 : Form
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Handles the Click event of the buttonGrabImage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void buttonGrabImage_Click(object sender, EventArgs e)
        {
            GrabImage();
            HalconImage.DispObj(hWindowControl1.HalconWindow);
        }

        /// <summary>
        /// Handles the FormClosing event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs" /> instance containing the event data.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShutDownHalcon(ho_Image, hv_AcqHandle);
        }

        /// <summary>
        /// Handles the Shown event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            InitializeFramegrabber();
        }

        #endregion Private Methods
    }
}