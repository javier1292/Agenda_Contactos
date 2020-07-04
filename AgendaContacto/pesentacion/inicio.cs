using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agenda;

namespace pesentacion
{
    public partial class inicio : Form
    {
        CNcontactos obj = new CNcontactos();
        public bool acceso;

        public inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Usuario = textBox1.Text;
            string Contraseña = textBox2.Text;
            obj.Login(Usuario, Contraseña);

             acceso = obj.acceso;

            if (acceso == true)
            {
                menu ss = new menu();
                ss.Show();
                this.Hide();
                acceso = false;
            }
            else {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ss = new Form1();
            ss.Show();
            this.Hide();

        }
    }
}
