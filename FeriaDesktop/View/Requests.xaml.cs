﻿using System.Windows;
using System.Windows.Controls;

namespace FeriaDesktop.View
{
    /// <summary>
    /// Lógica de interacción para Request.xaml
    /// </summary>
    public partial class Requests : Window
    {
        public Requests()
        {
            InitializeComponent();
           
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //if ((string)e.Column.Header == "IdUsuario")
            //{
            //    e.Cancel = true;
            //}
            if ((string)e.Column.Header == "IdSolProd")
            {
                e.Cancel = true;
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
                       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RequestDatas requestData = new RequestDatas();
        }



        //private void DataGrid_CellDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    Window req = new Window();
        //    req.Content = new ViewModel.RequestDataViewModel();
        //    req.Show();
        //}

    }
}
