// ***********************************************************************
// Assembly         : HSmartWindowControlExample
// Author           : Resolution Technology, Inc.
// Created          : 05-24-2017
// Last Modified On : 05-24-2017
// ***********************************************************************
// <copyright file="Form1.cs" company="Resolution Technology, Inc.">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Windows.Forms;
using HalconDotNet;
using Rti.Halcon;

namespace HSmartWindowControlExample
{
    /// <summary>
    /// Class Form1.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1 : Form
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Handles the Click event of the ButtonLoadImageHWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonLoadImageHWindow_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetEnvironmentVariable(@"HALCONEXAMPLES") + @"\images";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                HImage halconImage = new HImage(openFileDialog1.FileName);

                hSmartWindowControl1.HalconWindow.DispImage(halconImage);
            }
        }

        /// <summary>
        /// Handles the Click event of the ButtonLoadImagePictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonLoadImagePictureBox_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetEnvironmentVariable(@"HALCONEXAMPLES") + @"\images";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.LoadAsync(openFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Handles the Load event of the HSmartWindowControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HSmartWindowControl1_Load(object sender, EventArgs e)
        {
            this.MouseWheel += (sender as HSmartWindowControl).HSmartWindowControl_MouseWheel;
        }

        /// <summary>
        /// Handles the LoadCompleted event of the PictureBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.AsyncCompletedEventArgs"/> instance containing the event data.</param>
        private void PictureBox1_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            HImage halconImage = (pictureBox1.Image as Bitmap).ToHimage();

            hSmartWindowControl1.HalconWindow.DispImage(halconImage);
        }

        #endregion Private Methods
    }
}