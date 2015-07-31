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
    class CLBPHRecognition : ACFaceRecognition
    {
        public CLBPHRecognition( CImage _userImage, List<CImage> _lDatabaseImages )
        {
            comparisonMethod = "Метод применяющий двоичные локальные особенности (local binary pattern)";
            shortDescription = "--.";

            userImage = _userImage;
            lDatabaseImages = _lDatabaseImages;
        }

        public override int FaceRecognition()
        {

            FaceDetect(this.userImage);

            foreach (CImage tempImage in lDatabaseImages)
            {
                FaceDetect(tempImage);
            }

            int ContTrain = lDatabaseImages.Count;  // Количество изображений для тренировки.
            //Image<Gray, byte> result;
            foreach (MCvAvgComp f in aDetectedFaces[0])
            {
                if (this.lDatabaseImages.ToArray().Length != 0)
                {
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.0001);
                    FisherFaceRecognizer modelRecognition = new FisherFaceRecognizer(0, 3500);

                    Image<Gray, Byte>[] im = this.lDatabaseImages.Select(w => w.grayImage).ToArray();

                    modelRecognition.Train(this.lDatabaseImages.Select(w => w.grayImage).ToArray(), lIntDatabaseImagesLabels.ToArray());
                    FaceRecognizer.PredictionResult resultRecognition = new FaceRecognizer.PredictionResult();
                    resultRecognition = modelRecognition.Predict(userImage.grayImage);
                    // Зависимость степени похожести от разности изображений приблизительно имет вид
                    // 10 -> 99%; 100 -> 90%; 750 -> 50%, 10000 -> 1%
                    // тогда необходимо ввести шкалу (например, линейную): 
                    // Алгоритм расчёта степени похожести.
                    float threshold = 750;              // пороговое значение, равное 50% похожести изображений (установленно экспериментально)
                    float thresholdMismatch = 10000;    // пороговое значение несовпадения изоюражений (равное 1%, установлено экспериментально)    
                    if (resultRecognition.Distance < threshold)
                        similarityDegree = (100 - (resultRecognition.Distance * 50.0 / threshold)).ToString();
                    else
                        similarityDegree = (50 - (resultRecognition.Distance * 50 / thresholdMismatch)).ToString();
                }
            }

            return 0;
        }
    }
}
