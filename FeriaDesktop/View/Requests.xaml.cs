using System.Windows;
using System.Windows.Controls;

namespace FeriaDesktop.View
{
    /// <summary>
    /// Lógica de interacción para Request.xaml
    /// </summary>
    public partial class Requests : Window
    {
        public Requests() ///para tener las 2 grid en misma window

        {
            InitializeComponent();
            DataContext = new ViewModel.LinkViewModel()
            {
                GridReq = new ViewModel.RequestViewModel(),
                GridReqData = new ViewModel.RequestDataViewModel()
            };
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

       

       
    }
}
