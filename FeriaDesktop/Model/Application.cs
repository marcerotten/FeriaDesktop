using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaDesktop.Model
{
    public class Application : ViewModelBase
    {
        #region Atributes
        private string dni;
        private string displayName;
        private string codigo;

        private string fechaIni;
        private string fechaFin;

        private int idProd;
        private int cantProd;
        
        private int idSolProd;
        private int idUsuario;
        private int idTipoSol;
        private int idEstadoSol;
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



        public int IdProd
        {
            get
            {
                return idProd;
            }
            set
            {
                idProd = value;
                OnPropertyChanged("IdProd");
            }
        }
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
        public int IdSolProd
        {
            get
            {
                return idSolProd;
            }
            set
            {
                idSolProd = value;
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
        #endregion
    }
}