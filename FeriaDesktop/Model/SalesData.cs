using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaDesktop.Model
{
    public class SalesData : ViewModelBase
    {

        #region Atributes

        private int cantProd;
        private int precProd;
        public string descProd;



        #endregion

        #region Properties
       
        
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
      
        #endregion
    }

}