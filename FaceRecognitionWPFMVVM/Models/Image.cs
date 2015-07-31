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
        // Нормальные (нормализованные) размеры для изображений-шаблонов.
        const int GLOBAL_HEIGHT = 104;
        const int GLOBAL_WIDTH  = 104;        

        public Image<Gray, Byte> grayImage { get; set; }
        public Image<Bgr,  Byte> bgrImage  { get; set; }
        public string            path      { get; set; }
        public string            name      { get; set; }

        public CImage( string _patch, string _name )
        {
            this.path = _patch;
            this.name  = _name;
        }

        public int CreateGrayImage()
        {
            grayImage = new Image<Gray, byte>(name);

            return 0;
        }

        public int CreateBgrImage()
        {
            bgrImage = new Image<Bgr, byte>(name);

            return 0;
        }

        public int Normalization()
        {
            // Преобразование в оттенки серого.
            grayImage = bgrImage.Convert<Gray, Byte>();
            // Приводим к одному размеру.  
            // TODO: Возможно написать адаптер для преобразования IntPtr -> Image
            Image<Gray, Byte> imageProcessed = new Image<Gray, byte>(new System.Drawing.Size(bgrImage.Width, bgrImage.Height));
            imageProcessed.Ptr = CvInvoke.cvCreateImage(new System.Drawing.Size(GLOBAL_WIDTH, GLOBAL_HEIGHT), IPL_DEPTH.IPL_DEPTH_8U, 1);
            CvInvoke.cvResize(grayImage, imageProcessed, INTER.CV_INTER_LINEAR);
            // Выравниваем гистограмму изображения.
            CvInvoke.cvEqualizeHist(imageProcessed, imageProcessed);
            grayImage = imageProcessed;

            return 0;
        }
    }
}
