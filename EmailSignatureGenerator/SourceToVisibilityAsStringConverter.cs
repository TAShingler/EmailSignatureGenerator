using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSignatureGenerator;
internal class SourceToVisibilityAsStringConverter : System.Windows.Data.IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return (value != null) ? System.Windows.Visibility.Visible.ToString() : System.Windows.Visibility.Collapsed.ToString();
        //throw new NotImplementedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
