namespace HalconConnected
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
         this.HalconWindowControl1 = new HalconDotNet.HWindowControl();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.HalconWindowControl2 = new HalconDotNet.HWindowControl();
         this.SuspendLayout();
         // 
         // HalconWindowControl1
         // 
         this.HalconWindowControl1.BackColor = System.Drawing.Color.Black;
         this.HalconWindowControl1.BorderColor = System.Drawing.Color.Black;
         this.HalconWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 512, 512);
         this.HalconWindowControl1.Location = new System.Drawing.Point(0, 0);
         this.HalconWindowControl1.Name = "HalconWindowControl1";
         this.HalconWindowControl1.Size = new System.Drawing.Size(512, 512);
         this.HalconWindowControl1.TabIndex = 0;
         this.HalconWindowControl1.WindowSize = new System.Drawing.Size(512, 512);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(12, 515);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(53, 20);
         this.label1.TabIndex = 1;
         this.label1.Text = "label1";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(531, 515);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(53, 20);
         this.label2.TabIndex = 2;
         this.label2.Text = "label2";
         // 
         // HalconWindowControl2
         // 
         this.HalconWindowControl2.BackColor = System.Drawing.Color.Black;
         this.HalconWindowControl2.BorderColor = System.Drawing.Color.Black;
         this.HalconWindowControl2.ImagePart = new System.Drawing.Rectangle(0, 0, 512, 512);
         this.HalconWindowControl2.Location = new System.Drawing.Point(515, 0);
         this.HalconWindowControl2.Name = "HalconWindowControl2";
         this.HalconWindowControl2.Size = new System.Drawing.Size(512, 512);
         this.HalconWindowControl2.TabIndex = 3;
         this.HalconWindowControl2.WindowSize = new System.Drawing.Size(512, 512);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(1012, 604);
         this.Controls.Add(this.HalconWindowControl2);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.HalconWindowControl1);
         this.Name = "Form1";
         this.Text = "Halcon Connected";
         this.Shown += new System.EventHandler(this.Form1_Shown);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private HalconDotNet.HWindowControl HalconWindowControl1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private HalconDotNet.HWindowControl HalconWindowControl2;
   }
}

