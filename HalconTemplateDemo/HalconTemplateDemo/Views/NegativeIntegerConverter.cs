
// ***********************************************************************
// Assembly         : HalconTemplateDemo
// Author           : Resolution Technology, Inc.
// Created          : 06-15-2017
// Last Modified On : 06-15-2017
// ***********************************************************************
// <copyright file="NegativeIntegerConverter.cs" company="Resolution Technology, Inc.">
//     Copyright ©  2016, 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RibbonTest
{
     using System;
     using System.Globalization;
     using System.Windows.Data;

     /// <summary>
     /// Class NegativeIntegerConverter.
     /// </summary>
     /// <seealso cref="System.Windows.Data.IValueConverter" />
     class NegativeIntegerConverter : IValueConverter
     {
          /// <summary>
          /// Converts a value.
          /// </summary>
          /// <param name="value">The value produced by the binding source.</param>
          /// <param name="targetType">The type of the binding target property.</param>
          /// <param name="parameter">The converter parameter to use.</param>
          /// <param name="culture">The culture to use in the converter.</param>
          /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
          public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
               -1 * System.Convert.ToInt32(value);

          /// <summary>
          /// Converts a value.
          /// </summary>
          /// <param name="value">The value that is produced by the binding target.</param>
          /// <param name="targetType">The type to convert to.</param>
          /// <param name="parameter">The converter parameter to use.</param>
          /// <param name="culture">The culture to use in the converter.</param>
          /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
          public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
                -1 * System.Convert.ToInt32(value);
     }
}
