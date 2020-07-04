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
    public partial class Agendass : Form
    {
        private string ID_contacto;
        private bool editarr = false;
        CNcontactos objetoc = new CNcontactos();
        private CNcontactos objetocd = new CNcontactos();

        public Agendass()
        {
            InitializeComponent();
        }

        private void Agendass_Load(object sender, EventArgs e)
        {
            mostrarcontacto();
        }

        private void mostrarcontacto()
        {
            CNcontactos obj = new CNcontactos();
            dataGridView1.DataSource = obj.mostrarcontacto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ID_contacto = dataGridView1.CurrentRow.Cells["ID_contacto"].Value.ToString();
                objetocd.eliminiar(ID_contacto);

                MessageBox.Show("se elmino el contacto");
                mostrarcontacto();
            }
            else
            {
                MessageBox.Show("seleccione un contacto");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu ss = new menu();
            ss.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (editarr == false )
            {
                try
                {

                    objetoc.insertarC(txtNom.Text, txtap.Text, txtdire.Text, txtnump.Text, txtnumt.Text);
                    MessageBox.Show("Se agrego correctamente  ");
                    mostrarcontacto();
                    limpiar();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar el contacto  " + ex);
                }
                limpiar();
            }        
            if (editarr == true )
            {
                try
                {
                    int idContacto = Int32.Parse(ID_contacto);
                    objetocd.Editar(txtNom.Text, txtap.Text, txtdire.Text, txtnump.Text, txtnumt.Text, idContacto );

                    MessageBox.Show("Se edito correctamente   ");
                    mostrarcontacto();
                    editarr = false;
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos   " + ex);
                }
            }
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0  )
            {
                limpiar();
                editarr = true;
                txtNom.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtap.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                txtdire.Text = dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
                txtnump.Text = dataGridView1.CurrentRow.Cells["Numero_personal"].Value.ToString();
                txtnumt.Text = dataGridView1.CurrentRow.Cells["Numero_trabajo"].Value.ToString();
                ID_contacto = dataGridView1.CurrentRow.Cells["ID_contacto"].Value.ToString();
            }
            else
            {
                MessageBox.Show("seleccione una fila ");
            }

            
       
            
        }


        private void limpiar()
        {
            txtNom.Clear();
            txtap.Clear();
            txtdire.Clear();
            txtnump.Clear();
            txtnumt.Clear();



        }
    }
}
