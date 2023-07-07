using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSignatureGenerator;
internal class SourceToVisibilityConverter : System.Windows.Data.IValueConverter {
    /// <summary>
    /// Converts Source object to Visibility object to display image.
    /// </summary>
    /// <param name="values">value passed to converter</param>
    /// <param name="targetType">target type for output data</param>
    /// <param name="parameter">converter parameter passed to converter</param>
    /// <param name="culture">culture data passed to converter</param>
    /// <returns>System.Windows.Visibility.Visible or System.Windows.Visibility.Collapsed based on Image.Source object</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return (value != null) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
