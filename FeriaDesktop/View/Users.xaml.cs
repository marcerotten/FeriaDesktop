using FeriaDesktop.ViewModel;
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
using System.Windows.Shapes;

namespace FeriaDesktop.View
{
    /// <summary>
    /// Lógica de interacción para Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
            //this.DataContext = new UsersViewModel();

        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string) e.Column.Header == "IdUsuario")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Pais")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Rol")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Estado")
            {
                e.Cancel = true;
            }
        }
    }
}
