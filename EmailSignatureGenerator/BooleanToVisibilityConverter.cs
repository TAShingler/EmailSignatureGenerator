﻿using System;
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
        //throw new NotImplementedException();
        throw new InvalidOperationException("Converter cannot convert back.");
    }
}
