// ***********************************************************************
// Assembly         : Rti.Core.dll
// Author           : Resolution Technology, Inc.
// Created          : 03-10-2017
// Last Modified On : 04-26-2017
// ***********************************************************************
// <copyright file="Halcon.cs" company="Resolution Technology, Inc.">
//     Copyright (c) 2016, 2017. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Rti.Halcon
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Drawing;
    using System.Drawing.Imaging;
    using HalconDotNet;

    /// <summary>
    /// A class containing a collection of extension methods for HALCON developed by RTI.
    /// </summary>
    public static class Halcon
    {
        #region Public Methods

        /// <summary>
        /// Returns the convex hull from a collection of XLD contours.
        /// </summary>
        /// <param name="from">The collection of XLD contours to be processed.</param>
        /// <returns>An XLD contour that is the convex hull.</returns>
        /// <example> HXLDCont convexHullXld = MyXldContours.ConvexHull (); .</example>
        public static HXLDCont ConvexHull(this HXLDCont from)
        {
            HXLDCont tempContour = new HXLDCont(), convexHull = new HXLDCont();
            HTuple cumulativeRows = new HTuple(), cumulativeColumns = new HTuple();

            try
            {
                if (@from != null && @from.IsValid())
                {
                    int count = @from.CountObj();
                    if (count > 1)
                    {
                        for (int i = 1; i <= count; i++)
                        {
                            @from[i].GetContourXld(out HTuple rows, out HTuple columns);
                            cumulativeRows = cumulativeRows.TupleConcat(rows);
                            cumulativeColumns = cumulativeColumns.TupleConcat(columns);
                        }

                        tempContour.GenContourPolygonXld(
                        cumulativeRows,
                        cumulativeColumns);
                        convexHull = tempContour.ShapeTransXld("convex");
                    }
                    else
                    {
                        convexHull = @from.ShapeTransXld("convex");
                    }
                }

                if (convexHull.IsInitialized())
                {
                    return convexHull.CopyObj(1, -1);
                }
                else
                {
                    return new HXLDCont();
                }
            }
            finally
            {
                tempContour.Dispose();
                convexHull.Dispose();
            }
        }

        /// <summary>
        /// A helper method to ensure that a HALCON HImage is correctly disposed when assigned a new value.
        /// </summary>
        /// <param name="from">The source HImage.</param>
        /// <param name="to">The destination HImage.</param>
        /// <exception cref="ArgumentNullException">from must not be null.</exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void HCopy(this HImage from, ref HImage to)
        {
            try
            {
                if (@from == null)
                {
                    throw new ArgumentNullException(nameof(from));
                }

                if (to == null)
                {
                    to = new HImage();
                }

                to.Dispose();
                to = @from.CopyObj(1, -1);
            }
            finally
            {
                if (@from != null)
                {
                    @from.Dispose();
                }
            }
        }

        /// <summary>
        /// A helper method to ensure that a HALCON HRegion is correctly disposed when assigned a
        /// new value.
        /// </summary>
        /// <param name="from">The source HRegion.</param>
        /// <param name="to">The destination HRegion.</param>
        /// <exception cref="ArgumentNullException">from must not be null.</exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void HCopy(this HRegion from, ref HRegion to)
        {
            try
            {
                if (@from == null)
                {
                    throw new ArgumentNullException(nameof(from));
                }

                if (to == null)
                {
                    to = new HRegion();
                }

                to.Dispose();
                to = @from.CopyObj(1, -1);
            }
            finally
            {
                if (@from != null)
                {
                    @from.Dispose();
                }
            }
        }

        /// <summary>
        /// A helper method to ensure that a HALCON HXLD is correctly disposed when assigned a new value.
        /// </summary>
        /// <param name="from">The source HXLD.</param>
        /// <param name="to">The destination HXLD.</param>
        /// <exception cref="ArgumentNullException">from must not be null.</exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void HCopy(this HXLD from, ref HXLD to)
        {
            try
            {
                if (@from == null)
                {
                    throw new ArgumentNullException(nameof(from));
                }

                if (to == null)
                {
                    to = new HXLD();
                }

                to.Dispose();
                to = @from.CopyObj(1, -1);
            }
            finally
            {
                if (@from != null)
                {
                    @from.Dispose();
                }
            }
        }

        /// <summary>
        /// A helper method to ensure that a HALCON XLD Contour is correctly disposed when assigned a
        /// new value.
        /// </summary>
        /// <param name="from">The source HXLDCont.</param>
        /// <param name="to">The destination HXLDCont.</param>
        /// <exception cref="ArgumentNullException">from must not be null.</exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void HCopy(this HXLDCont from, ref HXLDCont to)
        {
            try
            {
                if (@from == null)
                {
                    throw new ArgumentNullException(nameof(from));
                }

                if (to == null)
                {
                    to = new HXLDCont();
                }

                to.Dispose();
                to = @from.CopyObj(1, -1);
            }
            finally
            {
                if (@from != null)
                {
                    @from.Dispose();
                }
            }
        }

        /// <summary>
        /// Determines whether the specified halcon object, image, xld or region is not null and is initialized.
        /// </summary>
        /// <param name="from">Any Halcon object.</param>
        /// <returns><c>true</c> if the specified from is valid; otherwise, <c>false</c>.</returns>
        /// <example> if (myRegion.IsValid()) myRegion.Connection(); .</example>
        public static bool IsValid(this HObject from)
        {
            bool result = false;
            if (@from != null)
            {
                if (@from.IsInitialized())
                {
                    result = @from.CountObj() > 0;
                }
            }

            return result;
        }

        /// <summary>
        /// Converts a bitmap to a Halcon image.
        /// </summary>
        /// <param name="from">A bitmap to be converted to an HImage.</param>
        /// <returns>An HImage converted from a Windows Bitmap.</returns>
        /// <example> HImage imageFromBitmap = myBitmap.ToHImage(); .</example>
        public static HImage ToHimage(this Bitmap from)
        {
            Contract.Requires(from != null);
            Rectangle rectangle = new Rectangle(0, 0, from.Width, from.Height);
            HImage interleavedHalconImage = new HImage();

            // Convert 24 bit bitmap to 32 bit bitmap in order to ensure
            // that the bit width of the image (the Stride) is divisible by four.
            // Otherwise, one might obtain skewed conversions.
            Bitmap image32 = new Bitmap(from.Width, from.Height, PixelFormat.Format32bppRgb);
            image32.SetResolution(from.HorizontalResolution, from.VerticalResolution);
            using (Graphics g = Graphics.FromImage(image32))
            {
                g.DrawImage(from, new Point(0, 0));
            }

            // Obtain the image pointer.
            BitmapData bitmapData = image32.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            IntPtr pointerToBitmap = bitmapData.Scan0;
            IntPtr pointerToPixels = pointerToBitmap;

            // Create HALCON image from the pointer.
            interleavedHalconImage.GenImageInterleaved(pointerToPixels, "bgrx", from.Width, from.Height, -1, "byte", from.Width, from.Height, 0, 0, -1, 0);

            // Don't forget to unlock the bits again. ;-)
            image32.UnlockBits(bitmapData);
            HImage outputHalconImage = interleavedHalconImage.CopyImage();

            // Release memory by dereferencing and garbage collection
            interleavedHalconImage.Dispose();
            image32.Dispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return outputHalconImage;
        }

        /// <summary>
        /// A helper method to convert an HObject containing an image to an HImage.
        /// </summary>
        /// <param name="from">The HObject.</param>
        /// <returns>The HImage.</returns>
        /// <example> HImage imageFromHalconObject = myHObject.ToHImage(); .</example>
        public static HImage ToHImage(this HObject from)
        {
            HImage newImage = new HImage();

            if (from.IsValid())
            {
                if (from.GetObjClass().S == "image")
                {
                    newImage.Dispose();
                    newImage = new HImage(from);
                }
            }

            return newImage;
        }

        /// <summary>
        /// A helper method to convert an HObject containing a region to an HRegion.
        /// </summary>
        /// <param name="from">A Halcon HObject to convert to an HRegion.</param>
        /// <returns>HRegion.</returns>
        /// <example> HRegion regionFromHalconObject = myHObject.ToHRegion(); .</example>
        public static HRegion ToHRegion(this HObject from)
        {
            HRegion newRegion = new HRegion();
            if (from.IsValid())
            {
                if (from.GetObjClass().S == "region")
                {
                    newRegion.Dispose();
                    newRegion = new HRegion(from);
                }
            }

            return newRegion;
        }

        /// <summary>
        /// A helper method to convert an HObject containing an XLD contour to an HXLDCont.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>HXLDCont.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static HXLDCont ToHXLDCont(this HObject from)
        {
            HXLDCont newXldCont = new HXLDCont();
            if (from.IsValid())
            {
                if (from.GetObjClass().S == "xld_cont")
                {
                    newXldCont.Dispose();
                    newXldCont = new HXLDCont(from);
                }
            }

            return newXldCont;
        }

        /// <summary>
        /// A helper method to convert an HObject containing parallel polygons to an HXLDPara.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>HXLDPara.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static HXLDPara ToHXLDPara(this HObject from)
        {
            HXLDPara newXldPara = new HXLDPara();
            if (from.IsValid())
            {
                if (from.GetObjClass().S == "xld_parallel")
                {
                    newXldPara.Dispose();
                    newXldPara = new HXLDPara(from);
                }
            }

            return newXldPara;
        }

        /// <summary>
        /// A helper method to convert an HObject containing a polygon to an HXLDPoly.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>HXLDPoly.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static HXLDPoly ToHXLDPoly(this HObject from)
        {
            HXLDPoly newXldPoly = new HXLDPoly();
            if (from.IsValid())
            {
                if (from.GetObjClass().S == "xld_poly")
                {
                    newXldPoly.Dispose();
                    newXldPoly = new HXLDPoly(from);
                }
            }

            return newXldPoly;
        }

        /// <summary>
        /// A helper method to convert an HTuple to an appropriate string format.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>System.String.</returns>
        public static string ToTypedString(this HTuple from)
        {
            switch (from.Type)
            {
                case HTupleType.INTEGER:
                    return from.I.ToString();

                case HTupleType.LONG:
                    return from.L.ToString();

                case HTupleType.DOUBLE:
                    return from.D.ToString("G");

                case HTupleType.STRING:
                    return from;

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// A helper method to convert an HTupleElements to an appropriate string format.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>System.String.</returns>
        public static string ToTypedString(this HTupleElements from)
        {
            switch (from.Type)
            {
                case HTupleType.INTEGER:
                    return from.I.ToString();

                case HTupleType.LONG:
                    return from.L.ToString();

                case HTupleType.DOUBLE:
                    return from.D.ToString("G");

                case HTupleType.STRING:
                    return from;

                default:
                    return string.Empty;
            }
        }

        #endregion Public Methods
    }
}