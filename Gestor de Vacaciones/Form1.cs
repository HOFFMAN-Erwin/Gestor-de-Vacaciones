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
        public Persona[] Personas { get; set; }
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
            Persona persona = new Persona();
            persona.Nombre = txtNombre.Text;
            persona.FechaIngreso = Convert.ToInt32(txtFechaIn.Text);
            Redimensionar();
            Personas[Personas.Length - 1] = persona;
        }
        private void Redimensionar()
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

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            lblLista.Text = "Lista \r\n";
            foreach (Persona item in Personas)
            {
                lblLista.Text = lblLista.Text + item.Nombre + "\r\n";
            }
        }
    }
}
