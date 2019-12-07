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

namespace HospiMan
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox2.PasswordChar = '●';
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string cs = @"Data Source=DESKTOP-OVMAKL8;Initial Catalog=Login;Integrated Security=True";

                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into admin_panel (User_,Pass) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')", conn);


                SqlDataReader myreader;
                try
            {
                conn.Open();

                myreader = cmd.ExecuteReader();

                MessageBox.Show("Signup Successful! \nClick OK To Continue", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("DUPLICATE USERNAME OR PASSWORD","ACCESS DENIED",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
