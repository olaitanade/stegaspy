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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using AForge.Video.FFMPEG;

namespace StegaSpy
{
    /// <summary>
    /// Interaction logic for VideoInfo.xaml
    /// </summary>
    public partial class VideoInfo : MetroWindow
    {
       
        OpenFileDialog aviDlg;
        
        String aviLocation = "";

        public VideoInfo()
        {
            InitializeComponent();
        }

        private void browseAvi_click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog initialization
            aviDlg = new OpenFileDialog();
            aviDlg.Filter = "Text Files|*.avi";
            aviDlg.Title = "Avi Video to use in steganography";
            aviDlg.ShowDialog();
            //Start the appending to file chosen from the file dialog
            aviLocation = aviDlg.FileName;
            txtLocation_tb.Text = aviLocation;
        }

        private void videoinfoBtn_click(object sender, RoutedEventArgs e)
        {
            // create instance of video reader
            VideoFileReader reader = new VideoFileReader();
            // open video file
            reader.Open(aviLocation);
            codec_tb.Text = reader.CodecName;
            framecount_tb.Text = reader.FrameCount.ToString();
            framerate_tb.Text = reader.FrameRate.ToString();
            width_tb.Text = reader.Width.ToString();
            height_tb.Text = reader.Height.ToString();
            long totalBits = reader.Width * reader.Height * reader.FrameCount;
            long totalMB = totalBits / 8000000;
            stegocapacity_tb.Text = totalMB.ToString()+"MB";

        }
    }
}
