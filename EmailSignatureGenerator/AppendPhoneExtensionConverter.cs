using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmailSignatureGenerator;
internal class AppendPhoneExtensionConverter : System.Windows.Data.IMultiValueConverter {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
        StringBuilder sb = new StringBuilder();
        
        if (targetType == typeof(string)) {
            if (System.Convert.ToBoolean(values[2], culture) == true) {
                sb.Append(values[0]);
                sb.Append(" ext. ");
                sb.Append(values[1]);
            } else {
                sb.Append(values[0]);
            }
        }
        //foreach (var value in values) {
        //    Debug.WriteLine(value.ToString() + " | " + value.GetType());
        //}

        return sb.ToString();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
