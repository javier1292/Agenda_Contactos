using agenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pesentacion
{
    public partial class Form1 : Form  
    {
        CNcontactos objetoc = new CNcontactos();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = txtNombre.Text;
            string ape = txtApellido.Text;
            string user = txtUsuario.Text;
            string pass = txtContraseña.Text;
            string passc = txtCcontra.Text;

            if (nom!="" || ape != "" || user != "" || pass != "" || passc != "") {
                if (pass.Equals(passc))
                {
                    try
                    {

                        objetoc.insertarusuario(txtNombre.Text, txtApellido.Text, txtUsuario.Text, txtContraseña.Text, txtCcontra.Text);
                        MessageBox.Show("Registro completado ");


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo registrar " + ex);
                    }

                    inicio ss = new inicio();
                    ss.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
            }
            else {
                MessageBox.Show("Aun faltan campos por llenar");
            }
        }
    }
}
