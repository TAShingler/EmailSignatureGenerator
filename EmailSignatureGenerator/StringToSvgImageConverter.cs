using Svg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSignatureGenerator;
internal class StringToSvgImageConverter : System.Windows.Data.IValueConverter {

    /// <summary>
    /// Validates file path string entered into textBoxImageSource on MainWindow.
    /// </summary>
    /// <param name="values">value passed to converter</param>
    /// <param name="targetType">target type for output data</param>
    /// <param name="parameter">converter parameter passed to converter</param>
    /// <param name="culture">culture data passed to converter</param>
    /// <returns>file path as string or null</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is not string)
            return null;

        if (String.IsNullOrEmpty((string)value) == true)
            return null;

        if (((string)value).Length <= 0)
            return null;

        if (File.Exists((string)value) == false)
            return null;

        if (((string)value).EndsWith(@".svg") == false)
            return null;

        return (string)value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
