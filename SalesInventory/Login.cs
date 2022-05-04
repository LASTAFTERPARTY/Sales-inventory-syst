using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesInventory
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname, password;
            uname = txtUname.Text;
            password = txtPass.Text;
           
            if(uname.Equals("Admin") && password.Equals("123"))
                    {
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }
              
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
