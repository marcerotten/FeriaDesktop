using System.Windows;
using System.Windows.Controls;

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
            if ((string)e.Column.Header == "Usuario")
            {
                e.Cancel = true;
            }
        }
    }
}
