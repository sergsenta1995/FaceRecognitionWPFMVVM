using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;

using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

//Подключаем библиотеки
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Features2D;
using Emgu.CV.Util;
using Emgu.CV.GPU;

using FaceRecognitionWPFMVVM.Models;
using FaceRecognitionWPFMVVM.ViewModels;
using FaceRecognitionWPFMVVM.Views;

namespace FaceRecognitionWPFMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            List<CImage> lImages = new List<CImage>()
            {
                new CImage(
                    Directory.GetCurrentDirectory() + @"\images\stalone\сталоне1.jpg",
                    "stalone1"),
                new CImage(
                    Directory.GetCurrentDirectory() + @"\images\stalone\сталоне2.jpg",
                    "stalone2"),
                new CImage(
                    Directory.GetCurrentDirectory() + @"\images\stalone\сталоне3.jpg",
                    "stalone3"),
            };

            CImage image = new CImage(
                    Directory.GetCurrentDirectory() + @"\images\stalone\сталоне0.jpg",
                    "stalone0");

            List<ACFaceRecognition> lFaceRecognition = new List<ACFaceRecognition>()
            {
                new CFisherRecognition( image, lImages ),
                new CLBPHRecognition( image, lImages ),
                new CPCARecognition( image, lImages ),
            };

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(lImages, image, lFaceRecognition); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
