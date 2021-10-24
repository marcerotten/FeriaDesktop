using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaDesktop.Model
{
    public class Contract : ViewModelBase
    {
        public int idContrato { get; set; }
        public int firmado { get; set; }
        public int idUsuario { get; set; }
    }
}
