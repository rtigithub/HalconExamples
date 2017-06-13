<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.HalconWindowControl = New HalconDotNet.HSmartWindowControl()
        Me.ButtonLoadImage = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.HalconWindowControl, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonLoadImage, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(908, 627)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'HalconWindowControl
        '
        Me.HalconWindowControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.HalconWindowControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.HalconWindowControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HalconWindowControl.HDoubleClickToFitContent = True
        Me.HalconWindowControl.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None
        Me.HalconWindowControl.HImagePart = New System.Drawing.Rectangle(0, 0, 640, 480)
        Me.HalconWindowControl.HKeepAspectRatio = False
        Me.HalconWindowControl.HMoveContent = True
        Me.HalconWindowControl.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn
        Me.HalconWindowControl.Location = New System.Drawing.Point(114, 0)
        Me.HalconWindowControl.Margin = New System.Windows.Forms.Padding(0)
        Me.HalconWindowControl.MinimumSize = New System.Drawing.Size(64, 64)
        Me.HalconWindowControl.Name = "HalconWindowControl"
        Me.TableLayoutPanel1.SetRowSpan(Me.HalconWindowControl, 2)
        Me.HalconWindowControl.Size = New System.Drawing.Size(794, 627)
        Me.HalconWindowControl.TabIndex = 0
        Me.HalconWindowControl.WindowSize = New System.Drawing.Size(794, 627)
        '
        'ButtonLoadImage
        '
        Me.ButtonLoadImage.AutoSize = True
        Me.ButtonLoadImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ButtonLoadImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonLoadImage.Location = New System.Drawing.Point(3, 3)
        Me.ButtonLoadImage.Name = "ButtonLoadImage"
        Me.ButtonLoadImage.Size = New System.Drawing.Size(108, 27)
        Me.ButtonLoadImage.TabIndex = 1
        Me.ButtonLoadImage.Text = "Load Image ..."
        Me.ButtonLoadImage.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "png"
        Me.OpenFileDialog1.Filter = """Image files|*.png;*.tif;*.jpg;*.bmp|All files|*.*"""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 627)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Display Halcon Image"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents HalconWindowControl As HalconDotNet.HSmartWindowControl
    Friend WithEvents ButtonLoadImage As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
