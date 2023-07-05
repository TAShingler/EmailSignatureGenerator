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
    //public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
    //    foreach (var item in values) {
    //        Debug.WriteLine(item.ToString());
    //    }
    //    //get string

    //    //get file type from string

    //    //update and display source based on file type

    //    //throw new NotImplementedException();
    //    if (((bool)values[0]) == true) {
    //        if (((string)values[1]).Length > 0) {
    //            //SvgImage svgImg = new SvgImage();
    //            //Svg.SvgPathBuilder svgPathBuilder = new Svg.SvgPathBuilder();
    //            //svgPathBuilder.ConvertFromString(values[1]);
    //            return (string)values[1];
    //        } else {
    //            return null;
    //        }
    //    } else {
    //        return null;
    //    }
    //}

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        //var svgImg = App.Current.MainWindow.FindName("imageSvgIcon") as SvgImage;

        if (value is string) {
            if (String.IsNullOrEmpty((string)value) == false) {
                if (((string)value).Length > 0) {
                    if (File.Exists((string)value)) {
                        if (((string)value).EndsWith(@".svg")) {
                            //svgImg.Visibility = System.Windows.Visibility.Visible.ToString();

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

        //if (svgImg != null) {
        //    svgImg.Visibility = System.Windows.Visibility.Collapsed.ToString();
        //}
        return null;
        //throw new NotImplementedException();
    }

    //public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
    //    throw new NotImplementedException();
    //}

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
