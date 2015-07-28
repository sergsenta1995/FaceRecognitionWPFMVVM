using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

//using FaceRecognitionWPFMVVM.Commands;
using System.Collections.ObjectModel;
using FaceRecognitionWPFMVVM.Models;

namespace FaceRecognitionWPFMVVM.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<CImageViewModel> imageList { get; set; }

        #region Constructor
        public MainViewModel(List<CImage> lImages)
        {
            imageList = new ObservableCollection<CImageViewModel>(lImages.Select(b => new CImageViewModel(b)));
        }
        #endregion
    }
}
