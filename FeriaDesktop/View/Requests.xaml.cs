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

       

        private void OnPropertyChanged(string displayName)
        {
            throw new NotImplementedException();
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
            
            RequestData win_menu = new RequestData();
            win_menu.Show();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        public string displayName { get; set; }

        public string DisplayName
        {
            get
            {
                return displayName;
            }
            set
            {
                displayName = "ADRIAN3";

            }
        }
    }
}
