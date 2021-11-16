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
        public DataTable DT { get; set; } = new DataTable();

        public int UltimoCodigo { get; set; } = 0;

        public ListaEmpleados()
        {
            DT.TableName = "ListaEmpleados";
            DT.Columns.Add("Id");
            DT.Columns.Add("Nombre");
            DT.Columns.Add("FechaIngreso");
            LeerDT_DeArchivo();
        }

        public void LeerDT_DeArchivo()
        {
            if (System.IO.File.Exists("Lista.xml"))
            {
                //DT.Clear();
                DT.ReadXml("Lista.xml");
                UltimoCodigo = 0;
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    if (Convert.ToInt32(DT.Rows[i]["Id"])>UltimoCodigo)
                    {
                        UltimoCodigo = Convert.ToInt32(DT.Rows[i]["Id"]);
                    }
                }
            }
            
        }
        public bool AddPersona(Persona persona)
        {
            
            bool resp = persona.Validar();

            if (resp)
            {
                if (persona.Id == 0)
                {
                    UltimoCodigo = UltimoCodigo + 1;
                    persona.Id = UltimoCodigo;
                    
                    DT.Rows.Add();
                    int NumeroRegistroNuevo = DT.Rows.Count - 1;

                    DT.Rows[NumeroRegistroNuevo]["Id"] = persona.Id.ToString();
                    DT.Rows[NumeroRegistroNuevo]["Nombre"] = persona.Nombre;
                    DT.Rows[NumeroRegistroNuevo]["FechaIngreso"] = persona.FechaIngreso.ToString();

                    DT.WriteXml("Lista.xml");
                }
                else
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(DT.Rows[i]["Id"])==persona.Id)
                        {
                            DT.Rows[i]["Nombre"] = persona.Nombre;
                            DT.Rows[i]["AñoIngreso"] = persona.FechaIngreso.ToString();
                            DT.WriteXml("Lista.xml");
                            break;
                        }
                    }
                }
            }
            return resp;            
        }
        public Persona BuscarPersona(int id)
        {
            Persona res = new Persona();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (Convert.ToInt32(DT.Rows[i]["Id"])==id)
                {
                    res.Id = Convert.ToInt32(DT.Rows[i]["Id"]);
                    res.Nombre = DT.Rows[i]["Nombre"].ToString();
                    res.FechaIngreso = Convert.ToInt32(DT.Rows[i]["FechaIngreso"]);
                    break;
                }
            }
            return res;
        }
        
        public bool DeletePersona(Persona persona)
        {
            bool resp = false;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (Convert.ToInt32(DT.Rows[i]["Id"])==persona.Id) 
                {
                    DT.Rows[i].Delete();
                    DT.WriteXml("Lista.xml");
                    resp = true;
                    break;
                }
            }
            return resp;
        }
    }
}  
