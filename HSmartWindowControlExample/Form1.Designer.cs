namespace HSmartWindowControlExample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hSmartWindowControl1 = new HalconDotNet.HSmartWindowControl();
            this.buttonLoadImageHWindow = new System.Windows.Forms.Button();
            this.buttonLoadImagePictureBox = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.hSmartWindowControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonLoadImageHWindow, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonLoadImagePictureBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // hSmartWindowControl1
            // 
            this.hSmartWindowControl1.AutoSize = true;
            this.hSmartWindowControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hSmartWindowControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.hSmartWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hSmartWindowControl1.HDoubleClickToFitContent = true;
            this.hSmartWindowControl1.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.hSmartWindowControl1.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hSmartWindowControl1.HKeepAspectRatio = true;
            this.hSmartWindowControl1.HMoveContent = true;
            this.hSmartWindowControl1.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.hSmartWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.hSmartWindowControl1.Margin = new System.Windows.Forms.Padding(0);
            this.hSmartWindowControl1.Name = "hSmartWindowControl1";
            this.hSmartWindowControl1.Size = new System.Drawing.Size(230, 220);
            this.hSmartWindowControl1.TabIndex = 0;
            this.hSmartWindowControl1.WindowSize = new System.Drawing.Size(230, 220);
            this.hSmartWindowControl1.Load += new System.EventHandler(this.HSmartWindowControl1_Load);
            // 
            // buttonLoadImageHWindow
            // 
            this.buttonLoadImageHWindow.AutoSize = true;
            this.buttonLoadImageHWindow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLoadImageHWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoadImageHWindow.Location = new System.Drawing.Point(3, 223);
            this.buttonLoadImageHWindow.Name = "buttonLoadImageHWindow";
            this.buttonLoadImageHWindow.Size = new System.Drawing.Size(224, 215);
            this.buttonLoadImageHWindow.TabIndex = 1;
            this.buttonLoadImageHWindow.Text = "Load Image Directly to Halcon Control ...";
            this.buttonLoadImageHWindow.UseVisualStyleBackColor = true;
            this.buttonLoadImageHWindow.Click += new System.EventHandler(this.ButtonLoadImageHWindow_Click);
            // 
            // buttonLoadImagePictureBox
            // 
            this.buttonLoadImagePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoadImagePictureBox.Location = new System.Drawing.Point(233, 223);
            this.buttonLoadImagePictureBox.Name = "buttonLoadImagePictureBox";
            this.buttonLoadImagePictureBox.Size = new System.Drawing.Size(224, 215);
            this.buttonLoadImagePictureBox.TabIndex = 2;
            this.buttonLoadImagePictureBox.Text = "Load image to PictureBox Control and Convert Bitmap to HImage for Display in Halc" +
    "on Control .. ";
            this.buttonLoadImagePictureBox.UseVisualStyleBackColor = true;
            this.buttonLoadImagePictureBox.Click += new System.EventHandler(this.ButtonLoadImagePictureBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(233, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.PictureBox1_LoadCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "png";
            this.openFileDialog1.FileName = "*.png";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "HSmartWindowControlExample";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private HalconDotNet.HSmartWindowControl hSmartWindowControl1;
        private System.Windows.Forms.Button buttonLoadImageHWindow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonLoadImagePictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

