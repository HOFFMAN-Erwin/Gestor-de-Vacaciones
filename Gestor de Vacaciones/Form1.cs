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
                txtNombre.Text = "";
                txtFechaIn.Text = "";
                txtNombre.Focus();
                lblLista.Text = "Persona cargada";
            }
        }
        

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            lblLista.Text = Lista.ToString();
        }
    }
}
