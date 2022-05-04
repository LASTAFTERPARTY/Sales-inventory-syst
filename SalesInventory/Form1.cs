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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }






        SqlConnection con = new SqlConnection("Data Source=.;  Initial Catalog=Market; User Id =sa;Password=123");
        SqlCommand cmd;
        SqlDataReader read;
        string sql;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)             //*******SAVE****************//
        {
            string pname = txtPname.Text;
            string price = txtPrice.Text;
            string discount = txtDiscount.Text;
            
            sql = "insert into products (pname,price,discount) values (@pname,@price,@discount)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pname", pname);
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtPname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)                                   //******UPDATE*****//
        {
            {
                string pname = txtPname.Text;
                string price = txtPrice.Text;
                string discount = txtDiscount.Text;
                string pid = txtId.Text;

                sql = "update products set pname= @pname, price= @price, discount= @discount where id = @pid";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pname", pname);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated!!");
                con.Close();
                txtPname.Clear();
                txtPrice.Clear();
                txtDiscount.Clear();
                txtPname.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)                    //******SEARCH ID ************//
        {
            string pid = txtId.Text;
            sql = "Select *from products where id=@pid";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if(dr.Read())
                    {
                txtPname.Text = dr["pname"].ToString();
                txtPrice.Text = dr["price"].ToString();
                txtDiscount.Text = dr["discount"].ToString();
            }
            else
            {
                MessageBox.Show("PRODUCT ID NOT FOUND");
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
    }
}
