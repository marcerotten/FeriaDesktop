using FeriaDesktop.Model;
using System;
using System.Collections.Generic;
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

namespace FeriaDesktop.View
{
    /// <summary>
    /// Lógica de interacción para RequestData.xaml
    /// </summary>
    public partial class RequestData : Window
    {

        
        public RequestData(String a)
        {

            MessageBox.Show(a);
            InitializeComponent();
            this.textBoxReqData.Text = a;


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

       

      

       
    }
}
