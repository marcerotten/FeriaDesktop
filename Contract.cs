namespace FeriaDesktop.Model
{
    public class Contract : ViewModelBase
    {
        #region Atributes
        private string dni;
        private string displayName;
        private string codigo;
        private string fechaIni;
        private string fechaFin;
        private int idContrato;
        private int firmado;
        private int idUsuario;
        #endregion
        #region Properties
        public string Dni
        {
            get
            {
                return dni;
            }
            set
            {
                dni = value;
                OnPropertyChanged("Dni");
            }
        }
        public string DisplayName
        {
            get
            {
                return displayName;
            }
            set
            {
                displayName = value;
                OnPropertyChanged("DisplayName");
            }
        }
        public string Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
                OnPropertyChanged("Codigo");
            }
        }
        public string FechaIni
        {
            get
            {
                return fechaIni;
            }
            set
            {
                fechaIni = value;
                OnPropertyChanged("FechaIni");
            }
        }
        public string FechaFin
        {
            get
            {
                return fechaFin;
            }
            set
            {
                fechaFin = value;
                OnPropertyChanged("FechaFin");
            }
        }
        public int IdContrato
        {
            get
            {
                return idContrato;
            }
            set
            {
                idContrato = value;
                OnPropertyChanged("IdContrato");
            }
        }
        public int Firmado
        {
            get
            {
                return firmado;
            }
            set
            {
                firmado = value;
                OnPropertyChanged("Firmado");
            }
        }
        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
                OnPropertyChanged("IdUsuario");
            }
        }
        #endregion
    }
}
