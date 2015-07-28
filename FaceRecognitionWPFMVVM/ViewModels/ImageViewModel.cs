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

using FaceRecognitionWPFMVVM.Models;

namespace FaceRecognitionWPFMVVM.ViewModel
{
    class CImageViewModel : ViewModelBase
    {
        public CImage image;

        public CImageViewModel( CImage _image)
        {
            this.image = _image;
        }

        public Image<Bgr, Byte> bgrImage
        {
            get { return image.bgrImage;  }
            set
            {
                image.bgrImage = value;
                OnPropertyChanged("bgrImage");
            }
        }

        public Image<Gray, Byte> bgrImage
        {
            get { return image.grayImage; }
            set
            {
                image.grayImage = value;
                OnPropertyChanged("grayImage");
            }
        }

        public string patch
        {
            get { return image.patch; }
            set
            {
                image.patch = value;
                OnPropertyChanged("patch");
            }
        }
    }
}
