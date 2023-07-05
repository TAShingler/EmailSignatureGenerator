using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using System.Xml.Serialization;
using Svg;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

namespace EmailSignatureGenerator;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        //viewBoxIcon.Child = new Image() { Source =  };
    }

    private void Window_StateChanged(object sender, EventArgs e) {
        if (this.WindowState.Equals(WindowState.Normal)) {
            windowMainBorder.BorderThickness = new Thickness(1);
        }

        if (this.WindowState.Equals(WindowState.Maximized)) {
            windowMainBorder.BorderThickness = new Thickness(8);
        }
    }

    private void btnSavePng_Click(object sender, RoutedEventArgs e) {
        if (!string.IsNullOrWhiteSpace(textBoxSaveToPath.Text) && !string.IsNullOrWhiteSpace(textBoxSaveToPath.Text)) {
            if (File.Exists(textBoxSaveToPath.Text + textBoxFileName.Text + ".png") == true) {
                //MessageBox.Show($"Image {textBoxFileName.Text}.png saved successfully.", "Save Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show(
                    $"File with the name {textBoxFileName.Text}.png already exists in directory at path {textBoxSaveToPath.Text}. Would you like to overwrite existing file?",
                    "File Exists Error",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                Debug.WriteLine(result);

                if (result.Equals(MessageBoxResult.Yes)) {
                    SaveFileAsPngToDirectory();
                } else {
                    return;
                }
            } else {
                SaveFileAsPngToDirectory();
            }
        } else {
            MessageBox.Show("Please make sure that both the Save to location and the File name boxes are filled out");
        }
    }
    private void ToggleEnableControls() {
        //Checkboxes
        //if (checkBoxEmployeeCredentials.IsEnabled == true) {
        //    checkBoxEmployeeCredentials.IsEnabled = false;
        //} else {
        //    checkBoxEmployeeCredentials.IsEnabled = true;
        //}
        //if (checkBoxEmployeeExtension.IsEnabled == true) {
        //    checkBoxEmployeeExtension.IsEnabled = !checkBoxEmployeeExtension.IsEnabled;
        //} else {
        //    checkBoxEmployeeExtension.IsEnabled = !checkBoxEmployeeExtension.IsEnabled;
        //}
        //if (checkBoxEmployeeDirectLine.IsEnabled == true) {
        //    checkBoxEmployeeDirectLine.IsEnabled = false;
        //} else {
        //    checkBoxEmployeeDirectLine.IsEnabled = true;
        //}
        checkBoxEmployeeCredentials.IsEnabled = !checkBoxEmployeeCredentials.IsEnabled;
        checkBoxEmployeeExtension.IsEnabled = !checkBoxEmployeeExtension.IsEnabled;
        checkBoxEmployeeDirectLine.IsEnabled = !checkBoxEmployeeDirectLine.IsEnabled;

        //Labels
        lblImageSource.IsEnabled = !lblImageSource.IsEnabled;
        lblEmployeeName.IsEnabled = !lblEmployeeName.IsEnabled;
        lblEmployeeTitle.IsEnabled = !lblEmployeeTitle.IsEnabled;
        lblEmployeeCredentials.IsEnabled = !lblEmployeeCredentials.IsEnabled;
        lblEmployeeEmail.IsEnabled = !lblEmployeeEmail.IsEnabled;
        lblEmployeePhone.IsEnabled = !lblEmployeePhone.IsEnabled;
        lblEmployeeExtension.IsEnabled = !lblEmployeeExtension.IsEnabled;
        lblEmployeeDirectLine.IsEnabled = !lblEmployeeDirectLine.IsEnabled;
        lblEmployeeAddressLine1.IsEnabled = !lblEmployeeAddressLine1.IsEnabled;
        lblEmployeeAddressLine2.IsEnabled = !lblEmployeeAddressLine2.IsEnabled;
        lblSaveToPath.IsEnabled = !lblSaveToPath.IsEnabled;
        lblFileName.IsEnabled = !lblFileName.IsEnabled;

        //Textboxes
        //if (textBoxImageSource.IsEnabled == true) {
        //    textBoxImageSource.IsEnabled = false;
        //} else {
        //    textBoxImageSource.IsEnabled = true;
        //}
        //if (textBoxEmployeeName.IsEnabled == true) {
        //    textBoxEmployeeName.IsEnabled = false;
        //} else {
        //    textBoxEmployeeName.IsEnabled = true;
        //}
        //if (textBoxEmployeeTitle.IsEnabled == true) {
        //    textBoxEmployeeTitle.IsEnabled = false;
        //} else {
        //    textBoxEmployeeTitle.IsEnabled = true;
        //}
        //if (textBoxEmployeeCredentials.IsEnabled == true) {
        //    textBoxEmployeeCredentials.IsEnabled = false;
        //} else {
        //    textBoxEmployeeCredentials.IsEnabled = true;
        //}
        //if (textBoxEmployeeEmail.IsEnabled == true) {
        //    textBoxEmployeeEmail.IsEnabled = false;
        //} else {
        //    textBoxEmployeeEmail.IsEnabled = true;
        //}
        //if (textBoxEmployeePhone.IsEnabled == true) {
        //    textBoxEmployeePhone.IsEnabled = false;
        //} else {
        //    textBoxEmployeePhone.IsEnabled = true;
        //}
        //if (textBoxEmployeeExtension.IsEnabled == true) {
        //    textBoxEmployeeExtension.IsEnabled = !textBoxEmployeeExtension.IsEnabled;
        //} else {
        //    textBoxEmployeeExtension.IsEnabled = !textBoxEmployeeExtension.IsEnabled;
        //}
        //if (textBoxEmployeeDirectLine.IsEnabled == true) {
        //    textBoxEmployeeDirectLine.IsEnabled = false;
        //} else {
        //    textBoxEmployeeDirectLine.IsEnabled = true;
        //}
        //if (textBoxEmployeeAddressLine1.IsEnabled == true) {
        //    textBoxEmployeeAddressLine1.IsEnabled = false;
        //} else {
        //    textBoxEmployeeAddressLine1.IsEnabled = true;
        //}
        //if (textBoxEmployeeAddressLine2.IsEnabled == true) {
        //    textBoxEmployeeAddressLine2.IsEnabled = false;
        //} else {
        //    textBoxEmployeeAddressLine2.IsEnabled = true;
        //}
        //if (textBoxSaveToPath.IsEnabled == true) {
        //    textBoxSaveToPath.IsEnabled = false;
        //} else {
        //    textBoxSaveToPath.IsEnabled = true;
        //}
        //if (textBoxFileName.IsEnabled == true) {
        //    textBoxFileName.IsEnabled = false;
        //} else {
        //    textBoxFileName.IsEnabled = true;
        //}
        textBoxImageSource.IsEnabled = !textBoxImageSource.IsEnabled;
        textBoxEmployeeName.IsEnabled = !textBoxEmployeeName.IsEnabled;
        textBoxEmployeeTitle.IsEnabled = !textBoxEmployeeTitle.IsEnabled;
        textBoxEmployeeCredentials.IsEnabled = !textBoxEmployeeCredentials.IsEnabled;
        textBoxEmployeeEmail.IsEnabled = !textBoxEmployeeEmail.IsEnabled;
        textBoxEmployeePhone.IsEnabled = !textBoxEmployeePhone.IsEnabled;
        textBoxEmployeeExtension.IsEnabled = !textBoxEmployeeExtension.IsEnabled;
        textBoxEmployeeDirectLine.IsEnabled = !textBoxEmployeeDirectLine.IsEnabled;
        textBoxEmployeeAddressLine1.IsEnabled = !textBoxEmployeeAddressLine1.IsEnabled;
        textBoxEmployeeAddressLine2.IsEnabled = !textBoxEmployeeAddressLine2.IsEnabled;
        textBoxSaveToPath.IsEnabled = !textBoxSaveToPath.IsEnabled;
        textBoxFileName.IsEnabled = !textBoxFileName.IsEnabled;

        //Buttons
        //if (btnImageSource.IsEnabled == true) {
        //    btnImageSource.IsEnabled = false;
        //} else {
        //    btnImageSource.IsEnabled = true;
        //}
        //if (btnChooseSaveLocation.IsEnabled == true) {
        //    btnChooseSaveLocation.IsEnabled = false;
        //} else {
        //    btnChooseSaveLocation.IsEnabled = true;
        //}
        //if (btnSavePng.IsEnabled == true) {
        //    btnSavePng.IsEnabled = false;
        //} else {
        //    btnSavePng.IsEnabled = true;
        //}
        btnImageSource.IsEnabled = !btnImageSource.IsEnabled;
        btnChooseSaveLocation.IsEnabled = !btnChooseSaveLocation.IsEnabled;
        btnSavePng.IsEnabled = !btnSavePng.IsEnabled;
        //btnColorChooser.IsEnabled = !btnColorChooser.IsEnabled;
    }
    private async void SaveFileAsPngToDirectory() {
        try {
            //get the current instance of the window
            Window wdw = Application.Current.Windows.OfType<Window>().Single(x => x.IsActive);

            //render the current control (window) with specified parameters of: width, height, horizontalDPI of the bitmap, vertical DPI of the bitmap, the format of the bitmap
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)businessCardOuterGrid.ActualWidth, (int)businessCardOuterGrid.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(businessCardOuterGrid);

            //encoding the rendered bitmap as desired (PNG, in my case, because i wanted lossless compression)
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            //save the image in the desired location; in my case, saveAs was C:\test.png
            /*
             *NEED TO INCLUDE CONFIRMATION BOX IN CASE FILE ALREADY EXISTS
             *
             * DISABLE ALL CONTROLS FOR 1 - 2 SECONDS WHILE FILE SAVES
             */
            ToggleEnableControls();
            //wdw.InvalidateVisual();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (Stream stm = File.Create(textBoxSaveToPath.Text + textBoxFileName.Text + ".png")) {
                png.Save(stm);
            }
            await Task.Delay(1000);
            if (File.Exists(textBoxSaveToPath.Text + textBoxFileName.Text + ".png") == true) {
                MessageBox.Show($"Image {textBoxFileName.Text}.png saved successfully.", "Save Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            } else {
                MessageBox.Show($"Image {textBoxFileName.Text}.png was not saved successfully.", "Save Failure!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds + " milliseconds elapsed to save PNG to " + textBoxSaveToPath.Text);
            //check that file saved; display message to user
            ToggleEnableControls();
        } catch (Exception ex) {
            Debug.WriteLine(ex.Message);
        }

        //Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
    }

    private void btnChooseSaveLocation_Click(object sender, RoutedEventArgs e) {
        using (var dialog = new System.Windows.Forms.FolderBrowserDialog()) {
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) {
                textBoxSaveToPath.Text = dialog.SelectedPath + "\\";
                //textBoxSaveToPath.CaretIndex = textBoxSaveToPath.Text.Length;
                //textBoxSaveToPath.Focus();
                //textBoxSaveToPath.ScrollToEnd();
            }
        }
    }
    
    private void btnMinimizeWindow_Click(object sender, RoutedEventArgs e) {
        if (!this.WindowState.Equals(WindowState.Minimized)) {
            WindowState = WindowState.Minimized;
        }
    }

    private void btnCloseApplication_Click(object sender, RoutedEventArgs e) {
        Application.Current.Shutdown();
    }

    private void btnImageSource_Click(object sender, RoutedEventArgs e) {
        OpenFileDialog ofd = new OpenFileDialog();

        ofd.Multiselect = false;
        ofd.Filter = "(*.png,*.svg)|*.png;*.svg";
        ofd.ShowDialog();
        var pathString = ofd.FileName;
        if (!string.IsNullOrEmpty(pathString)) {
            textBoxImageSource.Text = pathString;
        }
    }

    private void btnColorChooser_Click(object sender, RoutedEventArgs e) {
        Random rng = new Random();
        var businessCardPrimaryColorBrush = this.FindResource("BusinessCardPrimaryColorBrush") as SolidColorBrush;
        var businessCardSecondaryColorBrush = this.FindResource("BusinessCardSecondaryColorBrush") as SolidColorBrush;
        var businessCardTertiaryColorBrush = this.FindResource("BusinessCardTertiaryColorBrush") as SolidColorBrush;

        businessCardPrimaryColorBrush.Color = new System.Windows.Media.Color() {
            A = Convert.ToByte(rng.Next(256)),
            R = Convert.ToByte(rng.Next(256)),
            G = Convert.ToByte(rng.Next(256)),
            B = Convert.ToByte(rng.Next(256))
        };
        businessCardSecondaryColorBrush.Color = new System.Windows.Media.Color() {
            A = Convert.ToByte(rng.Next(256)),
            R = Convert.ToByte(rng.Next(256)),
            G = Convert.ToByte(rng.Next(256)),
            B = Convert.ToByte(rng.Next(256))
        };
        businessCardTertiaryColorBrush.Color = new System.Windows.Media.Color() {
            A = Convert.ToByte(rng.Next(256)),
            R = Convert.ToByte(rng.Next(256)),
            G = Convert.ToByte(rng.Next(256)),
            B = Convert.ToByte(rng.Next(256))
        };
    }


    //private static T DeserializeXMLFileToObject<T>(string fileName) {
    //    T returnObject = default(T);
    //    if (string.IsNullOrEmpty(fileName)) { return default(T); }

    //    try {
    //        StreamReader sr = new StreamReader(fileName);
    //        XmlSerializer serializer = new XmlSerializer(typeof(T));
    //        returnObject = (T)serializer.Deserialize(sr);
    //    } catch (Exception ex) {
    //        Debug.WriteLine(ex.Message);
    //    }
    //    return returnObject;
    //}
}
