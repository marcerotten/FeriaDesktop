using FeriaDesktop.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
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
            if ((string)e.Column.Header == "IdUsuario")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "IdSolProd")
            {
                e.Cancel = true;
            }
        }

       
        private void VerSolicitudes_Click(object sender, RoutedEventArgs e)
        {
            var a = textBoxReq.Text;
            RequestData requestData = new RequestData(a);
            requestData.Show();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


       
    }
}
