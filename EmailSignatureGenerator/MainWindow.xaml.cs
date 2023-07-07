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
    }

    /// <summary>
    /// Adjusts border thickness for Window based on WindowState.
    /// </summary>
    /// <param name="sender">object the rasied the event</param>
    /// <param name="e">EventArgs passed to the method</param>
    private void Window_StateChanged(object sender, EventArgs e) {
        //make Window border thickness 1px if WindowState is Normal
        if (this.WindowState.Equals(WindowState.Normal)) {
            windowMainBorder.BorderThickness = new Thickness(1);
        }

        //make Window border thickness 8px if WindowState is Maximized
        if (this.WindowState.Equals(WindowState.Maximized)) {
            windowMainBorder.BorderThickness = new Thickness(8);
        }
    }

    /// <summary>
    /// Handles click event for 'Save as PNG' button. Method checks whether file with entered name already exists at specified location before saving.
    /// </summary>
    /// <param name="sender">object the rasied the event</param>
    /// <param name="e">EventArgs passed to the method</param>
    private void btnSavePng_Click(object sender, RoutedEventArgs e) {
        //check that a file name has been entered
        if (!string.IsNullOrWhiteSpace(textBoxSaveToPath.Text) && !string.IsNullOrWhiteSpace(textBoxSaveToPath.Text)) {

            //check whether file with entered name exists at specified location
            if (File.Exists(textBoxSaveToPath.Text + textBoxFileName.Text + ".png") == true) {

                //verify that user wants to overwrite existing file
                var result = MessageBox.Show(
                    $"File with the name {textBoxFileName.Text}.png already exists in directory at path {textBoxSaveToPath.Text}. Would you like to overwrite existing file?",
                    "File Exists Error",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                //save to file if user chooses to overwrite existing file; exit method otherwise
                if (result.Equals(MessageBoxResult.Yes)) {
                    SaveFileAsPngToDirectory();
                } else {
                    return;
                }
            } else {

                //save to file if file with entered name does not already exist at specified location
                SaveFileAsPngToDirectory();
            }
        } else {
            MessageBox.Show("Please make sure that both the Save to location and the File name boxes are filled out");
        }
    }

    /// <summary>
    /// Toggles all UI controls IsEnabled value.
    /// </summary>
    private void ToggleEnableControls() {
        //Checkboxes
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
        btnImageSource.IsEnabled = !btnImageSource.IsEnabled;
        btnChooseSaveLocation.IsEnabled = !btnChooseSaveLocation.IsEnabled;
        btnSavePng.IsEnabled = !btnSavePng.IsEnabled;
    }

    /// <summary>
    /// Saves generated email signature as PNG file to directory specified by user.
    /// </summary>
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

            //disable UI controls
            ToggleEnableControls();

            //open stream to write data to file
            using (Stream stm = File.Create(textBoxSaveToPath.Text + textBoxFileName.Text + ".png")) {
                png.Save(stm);
            }

            await Task.Delay(1000);

            //check that file was successfully created
            if (File.Exists(textBoxSaveToPath.Text + textBoxFileName.Text + ".png") == true) {
                MessageBox.Show($"Image {textBoxFileName.Text}.png saved successfully.", "Save Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            } else {
                MessageBox.Show($"Image {textBoxFileName.Text}.png was not saved successfully.", "Save Failure!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //enable UI controls
            ToggleEnableControls();
        } catch (Exception ex) {
            MessageBox.Show(
                "Unable to save to file. Check fields and try again.",
                "",MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    /// <summary>
    /// Allows user to select folder to save to.
    /// </summary>
    /// <param name="sender">object the rasied the event</param>
    /// <param name="e">EventArgs passed to the method</param>
    private void btnChooseSaveLocation_Click(object sender, RoutedEventArgs e) {
        using (var dialog = new System.Windows.Forms.FolderBrowserDialog()) {
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) {
                textBoxSaveToPath.Text = dialog.SelectedPath + "\\";
            }
        }
    }

    /// <summary>
    /// Minimizes Window.
    /// </summary>
    /// <param name="sender">object the rasied the event</param>
    /// <param name="e">EventArgs passed to the method</param>
    private void btnMinimizeWindow_Click(object sender, RoutedEventArgs e) {
        if (!this.WindowState.Equals(WindowState.Minimized)) {
            WindowState = WindowState.Minimized;
        }
    }

    /// <summary>
    /// Closes application.
    /// </summary>
    /// <param name="sender">object the rasied the event</param>
    /// <param name="e">EventArgs passed to the method</param>
    private void btnCloseApplication_Click(object sender, RoutedEventArgs e) {
        Application.Current.Shutdown();
    }

    /// <summary>
    /// Displays OpenFileDialog for user to choose left-side image.
    /// </summary>
    /// <param name="sender">object the rasied the event</param>
    /// <param name="e">EventArgs passed to the method</param>
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
}
