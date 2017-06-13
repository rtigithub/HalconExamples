' ***********************************************************************
' Assembly         : HalconScaledImage
' Author           : Resolution Technology, Inc.
' Created          : 06-12-2017
' Last Modified On : 06-13-2017
' ***********************************************************************
' <copyright file="Form1.vb" company="Resolution Technology, Inc.">
'     Copyright ©  2017
' </copyright>
' <summary></summary>
' *************************************************************************
Imports HalconDotNet

''' <summary>
''' Class Form1.
''' </summary>
''' <seealso cref="System.Windows.Forms.Form" />
Public Class Form1

#Region "Public Properties"

    ''' <summary>
    ''' Gets or sets the halcon image.
    ''' </summary>
    ''' <value>The halcon image.</value>
    Public Property HalconImage As HImage

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Handles the Click event of the ButtonLoadImage control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    Private Sub ButtonLoadImage_Click(sender As Object, e As EventArgs) Handles ButtonLoadImage.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            HalconImage = New HImage(OpenFileDialog1.FileName)
            DisplayHalconImage(HalconImage)
        End If
    End Sub

    ''' <summary>
    ''' Displays the halcon image.
    ''' </summary>
    ''' <param name="halconImage">The halcon image.</param>
    Private Sub DisplayHalconImage(halconImage As HImage)
        HalconWindowControl.HalconWindow.DispImage(halconImage)
        HalconWindowControl.SetFullImagePart(Nothing)
    End Sub

    ''' <summary>
    ''' Set the keep aspect ratio property when the Halcon window control is loaded.
    ''' </summary>
    ''' <param name="sender">The sender.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub HalconWindowControl_Load(sender As HSmartWindowControl, e As EventArgs) Handles HalconWindowControl.Load
        sender.HKeepAspectRatio = True
    End Sub

    ''' <summary>
    ''' Resize the image if the Halcon window control size is changed.
    ''' </summary>
    ''' <param name="sender">The sender.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub HalconWindowControl_SizeChanged(sender As HSmartWindowControl, e As EventArgs) Handles HalconWindowControl.SizeChanged
        If HalconImage IsNot Nothing Then
            If HalconImage.IsInitialized Then
                If HalconWindowControl IsNot Nothing Then
                    HalconWindowControl.SetFullImagePart(Nothing)
                End If
            End If
        End If

    End Sub

#End Region

End Class