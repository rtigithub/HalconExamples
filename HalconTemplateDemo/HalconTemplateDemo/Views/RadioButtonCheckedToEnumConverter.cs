//-----------------------------------------------------------------------
// <copyright file="RadioButtonCheckedToEnumConverter.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.View
{
     using System;
     using System.Windows.Data;

     /// <summary>
     /// IValueConverter from radio button checked property to an enumeration type determined from usage.
     /// </summary>
     public class RadioButtonCheckedToEnumConverter : IValueConverter
     {
          /// <summary>
          /// Converts from the enumeration type to the value type, a boolean for the IsChecked property.
          /// </summary>
          /// <param name="value">The value of the radio button.</param>
          /// <param name="enumType">The type of the enumeration.</param>
          /// <param name="parameter">The converter parameter.</param>
          /// <param name="culture">The culture.</param>
          /// <returns>The boolean value.</returns>
          public object Convert(object value, Type enumType, object parameter, System.Globalization.CultureInfo culture) =>
                 parameter.Equals(value);

          /// <summary>
          /// Returns the enumeration value of the parameter if value is true.
          /// </summary>
          /// <param name="value">The value of the radio button.</param>
          /// <param name="enumType">The type of the enumeration.</param>
          /// <param name="parameter">The converter parameter.</param>
          /// <param name="culture">The culture.</param>
          /// <returns>The enumeration value.</returns>
          public object ConvertBack(object value, Type enumType, object parameter, System.Globalization.CultureInfo culture) =>
              value.Equals(true) ? parameter : Binding.DoNothing;
     }
}
