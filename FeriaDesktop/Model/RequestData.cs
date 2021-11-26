using System;
using System.Collections.Generic;
using System.Text;


namespace FeriaDesktop.Model
{
    public class RequestData : ViewModelBase
    {
        #region Atributes


        private int idSolProd;
        private int idUsuario;
        private int idTipoSol;
        private int idEstadoSol;


        private string displayName;
        private string apPaterno;
        private string apMaterno;


        private string productName;
        private int cantProd;


        private string paisName;
        private string estadoSolName;
        private string tipoSolName;
        #endregion

        public int IdSolProd
        {
            get
            {
                return idSolProd;
            }
            set
            {
                idSolProd = value;
                   ; //aca modificar para segunda datagrid popup
                OnPropertyChanged("IdSolProd");
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
        public int IdTipoSol
        {
            get
            {
                return idTipoSol;
            }
            set
            {
                idTipoSol = value;
                OnPropertyChanged("IdTipoSol");
            }
        }
        public int IdEstadoSol
        {
            get
            {
                return idEstadoSol;
            }
            set
            {
                idEstadoSol = value;
                OnPropertyChanged("IdEstadoSol");
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
        public string ApPaterno
        {
            get
            {
                return apPaterno;
            }
            set
            {
                apPaterno = value;
                OnPropertyChanged("ApPaterno");
            }
        }
        public string ApMaterno
        {
            get
            {
                return apMaterno;
            }
            set
            {
                apMaterno = value;
                OnPropertyChanged("ApMaterno");
            }
        }
        //public string Dni
        //{
        //    get
        //    {
        //        return dni;
        //    }
        //    set
        //    {
        //        dni = value;
        //        OnPropertyChanged("Dni");
        //    }
        //}
        public string PaisName
        {
            get
            {
                return paisName;
            }
            set
            {
                paisName = value;
                OnPropertyChanged("PaisName");
            }
        }
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }
        //public string Correo
        //{
        //    get
        //    {
        //        return correo;
        //    }
        //    set
        //    {
        //        correo = value;
        //        OnPropertyChanged("Correo");
        //    }
        //}
        public int CantProd
        {
            get
            {
                return cantProd;
            }
            set
            {
                cantProd = value;
                OnPropertyChanged("CantProd");
            }
        }
        public string EstadoSolName
        {
            get
            {
                return estadoSolName;
            }
            set
            {
                estadoSolName = value;
                OnPropertyChanged("EstadoSolName");
            }
        }
        public string TipoSolName
        {
            get
            {
                return tipoSolName;
            }
            set
            {
                tipoSolName = value;
                OnPropertyChanged("TipoSolName");
            }
        }

    }
}
