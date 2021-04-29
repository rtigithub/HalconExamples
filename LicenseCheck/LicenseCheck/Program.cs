using System;
using System.Runtime.InteropServices;
using HalconDotNet;

namespace LicenseCheck
{
    class Program
    {
        public delegate void HLicenseRecheckCallback(IntPtr context, int error);

        // Must match library name use "halconxl" if appropriate
        [DllImport("halcon", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HSetLicenseRecheckFailedCallback(
        HLicenseRecheckCallback callback, IntPtr context);

        // Member variable, delegate must be referenced / kept alive while in use
        static readonly HLicenseRecheckCallback MyCallback = MyCallbackImpl;
        // This method contains the implementation of what should happen in case of an error.
        public static void MyCallbackImpl(IntPtr context, int error)
        {
            Console.WriteLine("Error while checking the license (" + error + ")");
        }

        static void Main(string[] args)
        {
            // During execution of initialization code
            HSetLicenseRecheckFailedCallback(MyCallback, IntPtr.Zero);
            HImage img = new HImage();
            while (true)
            {
                // If possible, always do a proper error handling of HALCON functionality!
                // This should not always prevent you from licensing but also other issues.
                try
                {
                    Console.WriteLine("Executing HALCON functionality and sleeping afterwards...");
                    img.ReadImage("monkey");
                }
                catch (HOperatorException e)
                {
                    Console.WriteLine("Error while executing HALCON functionality: " + e.Message);
                }
                System.Threading.Thread.Sleep(5000);
            }
        }

    }
}
