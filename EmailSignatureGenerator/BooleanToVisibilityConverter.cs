using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace EmailSignatureGenerator;
internal class BooleanToVisibilityConverter : IValueConverter {
    public Boolean InvertVisibility {
        get; set;
    }

    /// <summary>
    /// Toggles control Visibility from Visible to Collapsed and vice versa.
    /// </summary>
    /// <param name="values">value passed to converter</param>
    /// <param name="targetType">target type for output data</param>
    /// <param name="parameter">converter parameter passed to converter</param>
    /// <param name="culture">culture data passed to converter</param>
    /// <returns>System.Windows.Visibilty.Visible or System.Windows.Visibility.Collapsed</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (targetType == typeof(Visibility)) {
            var visible = System.Convert.ToBoolean(value, culture);

            if (InvertVisibility) {
                visible = !visible;
            }

            return visible ? Visibility.Visible : Visibility.Collapsed;
        }

        throw new InvalidOperationException("Converter can only convert to value of type Visibilty.");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new InvalidOperationException("Converter cannot convert back.");
    }
}
