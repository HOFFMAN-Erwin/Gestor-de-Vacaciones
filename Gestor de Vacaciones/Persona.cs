using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Vacaciones
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int FechaIngreso { get; set; }

        public bool Validar()
        {
            bool resp = false;
            if (FechaIngreso>=1998 && FechaIngreso<= DateTime.Now.Year)
            {
               resp = true;
            }
            return resp;
        }

    }
}
