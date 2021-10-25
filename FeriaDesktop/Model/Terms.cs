using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace FeriaDesktop.Model
{
    public class Terms : INotifyPropertyChanged
    {
        private int idTerms;
        private string descripcion;
        public int IdTerms
        {
            get
            {
                return idTerms;
            }
            set
            {
                idTerms = value;
                OnPropertyChanged("IdTerms");
            }
        }
        [XmlAttribute("Descripcion")]
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
