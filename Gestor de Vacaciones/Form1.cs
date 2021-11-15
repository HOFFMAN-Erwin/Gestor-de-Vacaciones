using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_Vacaciones
{

    public partial class Form1 : Form
    {
        Persona per = new Persona();
        public ListaEmpleados Lista { get; set; } = new ListaEmpleados();
        public Form1()
        {
            InitializeComponent();

            dg.DataSource = Lista.DT;
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            per.Nombre = txtNombre.Text;
            per.FechaIngreso = Convert.ToInt32(txtFechaIn.Text);
            
            if (!Lista.AddPersona(per))
            {
                txtFechaIn.Focus();
                txtFechaIn.SelectAll();
                lblLista.Text = "Persona no válida";
            }
            else
            {
                limpiar();
            }
            per = new Persona();
        }
        

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            lblLista.Text = Lista.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            per = Lista.BuscarPersona(Convert.ToInt32(txtBuscar.Text));
            if (per.Id > 0)
            {
                txtNombre.Text = per.Nombre;
                txtFechaIn.Text = per.FechaIngreso.ToString();

                txtNombre.Focus();
                txtBuscar.Text = "";
            }
            else
            {
                txtBuscar.Text = "No existe";
                txtBuscar.Focus();
                txtBuscar.SelectAll();
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Lista.DeletePersona(per))
            {
                limpiar();
            }
            else
            {
                lblLista.Text = "El registro " + per.Nombre + " no se pudo borrar.";
                limpiar();
            }
            per = new Persona();
        }
        private void limpiar()
        {
            txtFechaIn.Text = "";
            txtNombre.Text = "";
            txtNombre.Focus();
            lblLista.Text = "";
        }
    }
}
