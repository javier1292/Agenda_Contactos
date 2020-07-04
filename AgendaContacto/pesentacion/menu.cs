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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           Agendass ss = new Agendass();
            ss.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            inicio ss =new  inicio();
           
            ss.Show();
            this.Hide();
                
        }
    }
}
