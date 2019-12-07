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
    public partial class Employee_Info : Form
    {
        public Employee_Info()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Employee_Info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospiempDataSet1.employee_data' table. You can move, or remove it, as needed.
            this.employee_dataTableAdapter1.Fill(this.hospiempDataSet1.employee_data);
            // TODO: This line of code loads data into the 'hospiempDataSet2.employee_data' table. You can move, or remove it, as needed.
            this.employee_dataTableAdapter.Fill(this.hospiempDataSet2.employee_data);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiemp;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO employee_data (E_ID,Name,Designation,Gender,Age,Contact_No,Joining_Date,Leaving_Date) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "')", con);
            SqlDataReader myreader;
            try
            {
                con.Open();

                myreader = cmd.ExecuteReader();

                MessageBox.Show("Data Saved Successfully","Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiemp;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("UPDATE employee_data SET Name ='" + textBox2.Text + "', Designation ='" + comboBox1.Text + "' , Gender ='" + comboBox2.Text + "', Age ='" + textBox3.Text + "', Contact_No ='" + textBox4.Text + "', Joining_Date ='" + textBox5.Text + "', Leaving_Date ='" + textBox7.Text + "' WHERE (E_Id ='" + textBox1.Text + "')", con);

            SqlDataReader myreader;

            try
            {
                con.Open();

                myreader = cmd.ExecuteReader();

                MessageBox.Show("Data updated Successfully","Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiemp;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("DELETE FROM employee_data WHERE (E_ID ='" + textBox1.Text + "')", con);

            SqlDataReader myreader;

            try
            {
                con.Open();

                myreader = cmd.ExecuteReader();

                MessageBox.Show("Data Deleted Successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiemp;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("Select * from employee_data", con);

            

            try
            {

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource source = new BindingSource();

                source.DataSource = dbdataset;
                dataGridView1.DataSource = source;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ab = new Form2();
            ab.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiemp;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("Select * from employee_data WHERE E_ID LIKE ('" + textBox6.Text + "')", con);

            //SqlDataReader myreader;

            try
            {

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource source = new BindingSource();

                source.DataSource = dbdataset;
                dataGridView1.DataSource = source;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
