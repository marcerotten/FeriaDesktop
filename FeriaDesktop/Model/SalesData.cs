﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaDesktop.Model
{
    public class SalesData : ViewModelBase
    {

        #region Atributes
        
        private string displayName;
        private int idProd;
        private int cantProd;
        private int precProd;
        public string descProd;
        private int idUsuario;

       

        #endregion

        #region Properties
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
        public int PrecProd
        {
            get
            {
                return precProd;
            }
            set
            {
                precProd = value;
                OnPropertyChanged("PrecProd");
            }
        }
        public string DescProd
        {
            get
            {
                return descProd;
            }
            set
            {
                descProd = value;
                OnPropertyChanged("DescProd");
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
