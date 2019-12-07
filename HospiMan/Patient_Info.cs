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
    public partial class Patient_Info : Form
    {
        public Patient_Info()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Patient_Info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospimanDataSet4.patient_data' table. You can move, or remove it, as needed.
            this.patient_dataTableAdapter2.Fill(this.hospimanDataSet4.patient_data);
            

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /*private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.patient_dataTableAdapter.FillBy(this.hospimanDataSet.patient_data, toolStripTextBox1.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }*/

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiman;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("INSERT INTO patient_data (P_ID,Name,Gender,Age,Bed_No,Admission_Date,Discharged_Date) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", con);

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
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiman;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("UPDATE patient_data SET Name ='" + textBox2.Text + "', Gender ='" + comboBox1.Text + "', Age ='" + textBox3.Text + "', Bed_No ='" + textBox4.Text + "', Admission_Date ='" + textBox6.Text + "', Discharged_Date ='" + textBox7.Text + "' WHERE (P_Id ='" + textBox1.Text + "')", con);
           
            SqlDataReader myreader;

            try
            {
                con.Open();

                myreader = cmd.ExecuteReader();

                MessageBox.Show("Data Updated Successfully","Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiman;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("DELETE FROM patient_data WHERE (P_ID ='" + textBox1.Text + "')", con);

            SqlDataReader myreader;

            try
            {
                con.Open();

                myreader = cmd.ExecuteReader();

                MessageBox.Show("Data Deleted Successfully","Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiman;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("Select * from patient_data", con);

            

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
            Form2 ss = new Form2();
            ss.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ab = new Form1();
            ab.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OVMAKL8;Initial Catalog=hospiman;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("Select * from patient_data WHERE P_ID LIKE ('" + textBox5.Text + "')", con);

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.patient_dataTableAdapter1.FillBy(this.hospimanDataSet2.patient_data);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
