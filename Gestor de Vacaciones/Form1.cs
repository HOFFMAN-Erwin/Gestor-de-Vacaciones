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
        public ListaEmpleados Lista { get; set; } = new ListaEmpleados();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (!Lista.AddPersona(txtNombre.Text, txtFechaIn.Text))
            {
                txtFechaIn.Focus();
                txtFechaIn.SelectAll();
                lblLista.Text = "Persona no válida";
            }
            else
            {
                btnMostrar_Click(null, null);
                txtNombre.Text = "";
                txtFechaIn.Text = "";
                txtNombre.Focus();
            }
        }
        

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            lblLista.Text = Lista.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Persona per = Lista.BuscarPersona(Convert.ToInt32(txtBuscar.Text));
            if (per.Código > 0)
            {
                txtNombre.Text = per.Nombre;
                txtFechaIn.Text = per.FechaIngreso.ToString();

                txtNombre.Focus();
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
    }
}
