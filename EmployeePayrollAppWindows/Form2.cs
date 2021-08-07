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
       public static int id;
        public static string  Name, Department, Gender, Salary, Date,pic;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            pic = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Gender = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Department = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Form1 f1 = new Form1();
            f1.Show();
        }
        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            //id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            if(id>0)
            {
                con.Open();
                command = new SqlCommand("DELETE FROM RegisterUser WHERE ID='" + id + "'", con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted From Data");
                display();
            }
            else
            {
                MessageBox.Show("Please select Row");
            }
            
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            con.Open();
            command = new SqlCommand("DELETE FROM RegisterUser WHERE ID='" + id + "'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted From Data");
            display();
        }
        public void display()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adp = new SqlDataAdapter("SELECT RegisterUser.ID, RegisterUser.Name,RegisterUser.ProfilePic,RegisterUser.Gender,RegisterUser.Department,RegisterUser.Salary,RegisterUser.Date from RegisterUser", con);
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
