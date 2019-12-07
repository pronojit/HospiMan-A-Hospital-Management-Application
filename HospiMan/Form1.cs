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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '●';
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = @"Data Source=DESKTOP-OVMAKL8;Initial Catalog=Login;Integrated Security=True";

                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from admin_panel where User_ ='" + textBox1.Text + "' and Pass='" + textBox2.Text + "'", conn);


                SqlDataReader myreader;


                myreader = cmd.ExecuteReader();

                int count = 0;
                while (myreader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("Click OK To Continue", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           
                    this.Hide();
                    Form2 ss = new Form2();
                    ss.Show();
                }

                else if (count > 1)
                {
                    MessageBox.Show("DUPLICATE USERNAME OR PASSWORD", "ACCESS DENIED", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }

                

                else
                {
                    MessageBox.Show("Incorrect Username or Password", "Try Again!",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                }

                conn.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Error!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 ss = new Form3();
            ss.Show();

        }
        }
    }
