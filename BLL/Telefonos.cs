using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Telefonos
    {
        public int TelefonoId { get; set; }
        public string Telefono { get; set; }

        public Telefonos(int TelefonoId,string Telefono)
        {
            this.TelefonoId = TelefonoId;
            this.Telefono = Telefono;
        }

        public Telefonos()
        {
            this.TelefonoId = 0;
            this.Telefono = "";
        }
    }
}
