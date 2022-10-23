using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using ZXing;
using ZXing.Common;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using System.Security.Cryptography;

namespace HackathonXAMLApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BarcodeCamera : Window
    {
        VideoCapture capture;
        Timer timer;
        Timer closeTimer;
        public static string barcode_value { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //the fps of the webcam
            int cameraFps = 30;

            //init the camera
            capture = new VideoCapture();

            //set the captured frame width and height (default 640x480)
            capture.Set(CapProp.FrameWidth, 1024);
            capture.Set(CapProp.FrameHeight, 768);

            //create a timer that refreshes the webcam feed
            timer = new Timer()
            {
                Interval = 1000 / cameraFps,
                Enabled = true
            };
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);



        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.Close();
            });
        }


        private async void timer_Tick(object sender, ElapsedEventArgs e)
        {

            //there is a qr code image visible
            if (feedImage.Visibility == Visibility.Collapsed)
            {
                timer.Stop();

                //the delay time you want to display the qr code in the ui for
                await Task.Run(() => Task.Delay(2500));

                //set the image visibility
                this.Dispatcher.Invoke(() =>
                {
                    feedImage.Visibility = Visibility.Visible;
                    Image1.Visibility = Visibility.Collapsed;
                });

                timer.Start();
            }

            this.Dispatcher.Invoke(() =>
            {
                var mat1 = capture.QueryFrame();
                var mat2 = new Mat();
                //flip the image horizontally
                CvInvoke.Flip(mat1, mat2, FlipType.Horizontal);

                //convert the mat to a bitmap
                var bmp = mat2.ToImage<Bgr, byte>().ToBitmap();

                //copy the bitmap to a memorystream
                var ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Bmp);

                //display the image on the ui
                feedImage.Source = BitmapFrame.Create(ms);

                //try to find a qr code in the feed
                string qrcode = FindQrCodeInImage(bmp);
                if (!string.IsNullOrEmpty(qrcode))
                {
                    //set the found text in the qr code in the ui
                    TextBlock1.Text = qrcode;
                    TextBlock2.Text = $"Last scan: {DateTime.Now.ToLongDateString()} at {DateTime.Now.ToShortTimeString()}.";
                    //play a sound to indicate qr code found
                    var player_ok = new SoundPlayer(GetStreamFromResource("sound_ok.wav"));
                    player_ok.Play();
                    //hide the feed image
                    feedImage.Visibility = Visibility.Collapsed;
                    Image1.Source = new BitmapImage(new Uri("https://img.myloview.com/stickers/camera-icon-with-checkmark-400-144448856.jpg"));
                    Image1.Visibility = Visibility.Visible;
                    barcode_value = qrcode;
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Interval = 1500;
                    aTimer.Enabled = true;

                }
            });
        }


        private string FindQrCodeInImage(Bitmap bmp)
        {
            //decode the bitmap and try to find a qr code
            var source = new BitmapLuminanceSource(bmp);
            var bitmap = new BinaryBitmap(new HybridBinarizer(source));
            var result = new MultiFormatReader().decode(bitmap);
            //no qr code found in bitmap
            if (result == null)
            {
                return null;
            }
            //create a new qr code image
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 300,
                    Width = 300
                }
            };
            //write the result to the new qr code bmp image
            var qrcode = writer.Write(result.Text);
            //make the bmp transparent
            qrcode.MakeTransparent();
            //show the found qr code in the app


            //and/or save the new qr code image to disk if needed

            return result.Text;
        }
        private static Stream GetStreamFromResource(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(string.Format("{0}.Resources.{1}", assembly.GetName().Name, filename));
        }
    }





}
