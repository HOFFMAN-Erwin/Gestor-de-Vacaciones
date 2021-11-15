using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Vacaciones
{
    public class ListaEmpleados
    {
        public Persona[] Personas { get; set; }

        public DataTable DT { get; set; } = new DataTable();

        public int UltimoCódigo { get; set; } = 0;

        public ListaEmpleados()
        {
            DT.TableName = "ListaEmpleados";
            DT.Columns.Add("Id");
            DT.Columns.Add("Nomebre");
            DT.Columns.Add("AñoIngreso");
        }

        public void LeerDT_DeArchivo()
        {

        }

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
                UltimoCódigo = UltimoCódigo + 1;
                persona.Id = UltimoCódigo;
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
                Resp = Resp + item.Id.ToString() + " - " 
                    + item.FechaIngreso.ToString() + " - "
                    + item.Nombre + "\r\n";
            }
            return Resp;
        }
        public Persona BuscarPersona(int código)
        {
            Persona res = new Persona();

            foreach (Persona item in Personas)
            {
                if (item.Id == código)
                {
                    res = item;
                    break;
                }
            }
            return res;
        }
        public bool UpdatePersona(Persona persona)

        {
            return false;
        }
        public bool DeletePersona(Persona persona)
        {
            return false;
        }
        
    }
}  
