using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaDesktop.Model
{
    public class Contract : ViewModelBase
    {
        #region Atributes
        public string dni { get; set; }
        public string displayName { get; set; }
        public string codigo { get; set; }
        public string fechaIni { get; set; }
        public string fechaFin { get; set; }
        public int idContrato { get; set; }
        public int firmado { get; set; }
        public int idUsuario { get; set; }
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
