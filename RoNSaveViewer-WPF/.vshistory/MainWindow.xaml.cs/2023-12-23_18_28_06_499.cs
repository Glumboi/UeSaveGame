﻿using RoNSaveViewer_WPF.CustomObjects;
using RoNSaveViewer_WPF.ViewModels;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoNSaveViewer_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = this.DataContext as MainWindowViewModel;
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            RoNSaveObject currentObj = vm.RoNSaveObjects[dataGrid.SelectedIndex];

            switch (dataGrid.CurrentColumn.Header)
            {
                case "Name":
                    currentObj.Name = 
                    break;
                case "OBJName":
                    currentObj.OBJName =
                    break;
                case "Value":
                    break;
                case "Type":
                    break; 
                default:
                    Debug.WriteLine("Not a known Column");
                    return;
            }

        }
    }
}