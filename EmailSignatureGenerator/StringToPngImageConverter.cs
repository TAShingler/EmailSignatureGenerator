using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmailSignatureGenerator;
internal class StringToPngImageConverter : System.Windows.Data.IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is string) {
            if (String.IsNullOrEmpty((string)value) == false) {
                if (((string)value).Length > 0) {
                    if (File.Exists((string)value)) {
                        if (((string)value).EndsWith(@".png")) {
                            //nonSvgImg.Visibility = System.Windows.Visibility.Visible;

                            return (string)value;
                        }

                        //if (((string)value).EndsWith(@".png")) {
                        //    return (string)value;
                        //}
                    }
                }
            }
        }

        //if (((string)value).EndsWith(@".svg")) {
        //    return (string)value;
        //}

        //if (nonSvgImg != null) {
        //    nonSvgImg.Visibility = System.Windows.Visibility.Collapsed;
        //}
        return null;
        //throw new NotImplementedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
