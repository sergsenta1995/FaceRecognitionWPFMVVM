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

namespace FaceRecognitionWPFMVVM.Models
{
    class CImage
    {
        public Image<Gray, Byte> grayImage { get; set; }
        public Image<Bgr,  Byte> bgrImage  { get; set; }
        public string            patch     { get; set; }

        public CImage( 
            Image<Gray, Byte> _grayImage,
            Image<Bgr, Byte>  _bgrImage,
            string            _patch )
        {
            this.grayImage = _grayImage;
            this.bgrImage  = _bgrImage;
            this.patch     = _patch;
        }
    }
}
