﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RoNSaveViewer_WPF.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ICommand OpenFileCommand{ get; set; }
    }
}