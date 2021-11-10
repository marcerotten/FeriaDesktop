using System.Windows;
using System.Windows.Controls;

namespace FeriaDesktop.View
{
    /// <summary>
    /// Lógica de interacción para Applications.xaml
    /// </summary>
    public partial class Applications : Window
    {
        public Applications()
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
