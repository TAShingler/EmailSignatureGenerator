using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSignatureGenerator;
internal class SourceToVisibilityAsStringConverter : System.Windows.Data.IValueConverter {
    /// <summary>
    /// Converts FileSource object to Visibility object to display SVG image.
    /// </summary>
    /// <param name="values">value passed to converter</param>
    /// <param name="targetType">target type for output data</param>
    /// <param name="parameter">converter parameter passed to converter</param>
    /// <param name="culture">culture data passed to converter</param>
    /// <returns>System.Windows.Visibility.Visible or System.Windows.Visibility.Collapsed as string based on SVGImage.FileSource object</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return (value != null) ? System.Windows.Visibility.Visible.ToString() : System.Windows.Visibility.Collapsed.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
