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
    abstract class ACFaceRecognition
    {
        const int MAX_FACES_IN_IMAGE = 30;

        public CImage       userImage       { get; set; }
        public List<CImage> lDatabaseImages { get; set; }
        public List<int>    lIntDatabaseImagesLabels;
        public List<string> lStringDatabaseImagesLabels;

        public string comparisonMethod { get; set; } // метод сравнения
        public string similarityDegree { get; set; } // степень похожести изображений
        public string shortDescription { get; set; } // краткое описание метода сравнения

        protected MCvAvgComp[][] aDetectedFaces;     // массив распознанных лиц 

        public ACFaceRecognition()
        {
            // Максимальное к-во лиц на фото - 30.
            MCvAvgComp[][] facesDetected = new MCvAvgComp[MAX_FACES_IN_IMAGE][];

            lIntDatabaseImagesLabels    = new List<int>();
            lStringDatabaseImagesLabels = new List<string>();
        }

        // Метод, обнаруживающий все лица на фото.
        public int FaceDetect(CImage _image )
        {
            /*
            // Можно так.
            HaarCascade HaarCascadeXML = new HaarCascade("haarcascade_frontalface_default.xml");
            _facesDetected = HaarCascadeXML.Detect(
                this.inputImage, 
                1.2, 
                10, 
                HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new System.Drawing.Size(20, 20) 
                );
            */
            Emgu.CV.HaarCascade face = new HaarCascade("haarcascade_frontalface_default.xml");
            aDetectedFaces = _image.bgrImage.DetectHaarCascade(
                 face,
                 1.2,
                 10,
                 Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                 new System.Drawing.Size(20, 20));

            foreach (MCvAvgComp f in aDetectedFaces[0])
            {
                CvInvoke.cvSetImageROI(_image.bgrImage, f.rect); // Устанавливаем ROI
            }

            _image.Normalization();

            return 0;
        }

        public int CreateDatabaseImageLabels()
        {
            int index = 0;
            foreach (CImage tempImage in lDatabaseImages)
            {
                lIntDatabaseImagesLabels.Add(index);
                lStringDatabaseImagesLabels.Add(tempImage.name);
                index++;
            }

            return 0;
        }
        abstract public int FaceRecognition();

    }
}
