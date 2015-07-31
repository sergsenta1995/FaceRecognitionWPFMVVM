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

namespace FaceRecognitionWPFMVVM.ViewModels
{
    class RecognitionMethodsViewModel : ViewModelBase
    {
        // Указываем откуда будем брать данные.
        public ACFaceRecognition faceRecognition;

        public RecognitionMethodsViewModel( ACFaceRecognition _faceRecognition )
        {
            this.faceRecognition = _faceRecognition;
        }

        #region Методы, которые отвечают как "биндить" поля формы данными класса CImage
        // Методы - суть переменные XAML формы
        public string bindComparisonMethod
        {
            get { return faceRecognition.comparisonMethod; }
            set
            {
                faceRecognition.comparisonMethod = value.ToString();
                OnPropertyChanged("comparisonMethod");
            }
        }
        public string bindSimilarityDegree
        {
            get { return faceRecognition.similarityDegree; }
            set
            {
                faceRecognition.similarityDegree = value;
                OnPropertyChanged("similarityDegree");
            }
        }
        public string bindShortDescription
        {
            get { return faceRecognition.shortDescription; }
            set
            {
                faceRecognition.similarityDegree = value;
                OnPropertyChanged("bindShortDescription");
            }
        }
        #endregion 
    }
}
