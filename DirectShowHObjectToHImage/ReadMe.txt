Add HalconWindow control to form.
Add exported code to solution.
Wrap exported code with project namespace.
Change partial class name HDevelopExport to same class name as form.
Set NO_EXPORT_APP_MAIN conditional compilation symbol
Refactor HOperatorSet.CloseFramegrabber(hv_AcqHandle); and ho_Image.Dispose(); to ShutDownHalcon method.
Refactor ho_image and hv_AcqHandle as field and encapsulate as property.
Refactor OpenFrameGrabber and GrabImageStart calls to InitializeFramegrabber method.
Refactor the ho_Image.Dispose and GrabImageAsync calls to GrabImage method.
Add ShutDownHalcon to FormClosing event.
Add InitializeFramegrabber to Shown event.
Add the HobjectToHimage to your project.
Modify the Ho_image property to return the HObject as an HImage via the HobjectToHimage method.