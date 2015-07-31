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

using System.ComponentModel;
using System.Data;
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

using System.Xml;
using System.Xml.Serialization;

//using FaceRecognitionWPFMVVM.Commands;
using System.Collections.ObjectModel;
using FaceRecognitionWPFMVVM.Models;

namespace FaceRecognitionWPFMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
    #region Binding-переменные
        public ObservableCollection<DatabaseImageViewModel> bindDatabaseImageList { get; set; }
        public ImageSource bindUserImage { get; set; }
        public ObservableCollection<RecognitionMethodsViewModel> bindRecognitionMethodsList { get; set; }
    #endregion

    #region Конструктор - передаём объекты для дальнейшего отображения их на формах
        public MainViewModel(List<CImage> lImages, CImage image, List<ACFaceRecognition> lFaceRecognitionMethods )
        {
            bindDatabaseImageList = new ObservableCollection<DatabaseImageViewModel>(lImages.Select(b => new DatabaseImageViewModel(b)));
            bindUserImage = new BitmapImage(new Uri(image.path));
            bindRecognitionMethodsList = new ObservableCollection<RecognitionMethodsViewModel>(lFaceRecognitionMethods.Select(a => new RecognitionMethodsViewModel(a)));
        }
    #endregion
    }
}
