using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Vacaciones
{
    public class ListaEmpleados
    {
        public Persona[] Personas { get; set; }

        public void Redimensionar()
        {
            if (Personas == null)
            {
                Personas = new Persona[1];
            }
            else
            {
                Persona[] arrayAuxiliar = new Persona[Personas.Length + 1];
                for (int i = 0; i < Personas.Length; i++)
                {
                    arrayAuxiliar[i] = Personas[i];
                }
                Personas = arrayAuxiliar;
            }
        }

        public bool AddPersona(string nombre, string año)
        {
            Persona persona = new Persona();
            persona.Nombre = nombre;
            persona.FechaIngreso = Convert.ToInt32(año);

            bool resp = persona.Validar();

            if (resp)
            {
                Redimensionar();
                Personas[Personas.Length - 1] = persona;
            }
            return resp;            
        }
        public override string ToString()
        {
            string Resp = "";
            Resp = "Lista \r\n";
            foreach (Persona item in Personas)
            {
                Resp = Resp + item.FechaIngreso.ToString() + " - " + item.Nombre + "\r\n";
            }
            return Resp;
        }
    }
}
