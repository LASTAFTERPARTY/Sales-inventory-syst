using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SalesInventory
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;  Initial Catalog=Market; User Id =sa;Password=123");
        SqlCommand cmd;
        SqlDataReader read;
        string sql;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            string pid = txtId.Text;
            sql = "Select *from products where id=@pid";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtPname.Text = dr["pname"].ToString();
               double price = double.Parse(dr["price"].ToString());
               double dis = double.Parse(dr["discount"].ToString());
        
                double cal = price * dis / 100; ;
                double discountprice = price - cal;





                txtPrice.Text = price.ToString();
                txtDiscount.Text = discountprice.ToString();

            }
            else
            {
                MessageBox.Show("PRODUCT ID NOT FOUND");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pid = txtId.Text;
            string pname = txtPname.Text;
            string price = txtPrice.Text;
            string discount = txtDiscount.Text;

            sql = "insert into sales(pid,price,discount) values(@pid,@price,@discount)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@discount", discount);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Added!!");
            con.Close();
            txtPname.Clear();
            txtPrice.Clear();
            txtDiscount.Clear();
            txtPname.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
    }
}
