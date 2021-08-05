using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmployeePayrollAppWindows
{
    public partial class Form2 : Form
    {
        string path = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=EmployeePayroll;Integrated Security=True";
        SqlConnection con;
        SqlCommand command;
        SqlDataAdapter adp;
        DataTable dt;
        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
        public void display()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adp = new SqlDataAdapter("SELECT RegisterUser.Name,RegisterUser.Gender,RegisterUser.Departmant,RegisterUser.Salary,RegisterUser.Date from RegisterUser", con);
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("Register", this.con);
    
            con.Close();
            MessageBox.Show("Your action has been recorded");
           
        }
    }
}
