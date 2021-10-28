using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FeriaDesktop.Model
{
    public class Country : INotifyPropertyChanged
    {
        private int idPais;
        private string descripcion;
        public int IdPais
        {
            get
            {
                return idPais;
            }
            set
            {
                idPais = value;
                OnPropertyChanged("IdPais");
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
