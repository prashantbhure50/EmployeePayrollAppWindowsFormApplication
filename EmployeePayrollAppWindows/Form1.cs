using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeePayrollAppWindows
{
    public partial class Form1 : Form
    {
        string path = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=EmployeePayroll;Integrated Security=True";
        SqlConnection con;
        SqlCommand command;
        public static string SetValueForText = "";
        int id;
        public  string Gender, profileimg, Department;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            Name.Text = Form2.Name;
            id = Form2.id;
            Department = Form2.Department;
            Gender = Form2.Gender;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            if(Gender=="Male")
            {
                rbmale.Checked=true;
            }
            if (Gender == "Female")
            {
                rbmale.Checked = true;
            }
            if (Department == "HR")
            {
                hr.Checked = true;
            }
            if (Department == "Sales")
            {
                sales.Checked = true;
            }
            if (Department == "Finance")
            {
                finance.Checked = true;
            }
            if (Department == "Engineer")
            {
                engineer.Checked = true;
            }
            if (Department == "Others")
            {
                checkBox11.Checked = true;
            }
            if (profileimg == "1")
            {
                propic1.Checked = true;
            }
            if (profileimg == "2")
            {
                propic2.Checked = true;
            }
            if (profileimg == "3")
            {
                propic3.Checked = true;
            }
            if (profileimg == "4")
            {
                propic4.Checked = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void rtbResult_TextChanged(object sender, EventArgs e)
        {
            //lblCount.Text = rtbResult.Text.Length.ToString();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (Name.Text == "")
            {
                MessageBox.Show("Please Fill All Feild");
            }
            else
            {
                try
                {
                    SetValueForText = Name.Text;
                    Form2 f2 = new Form2();
                    f2.Show();

                    if (rbmale.Checked)
                    {
                        Gender = "Male";
                    }
                    else
                    {
                        Gender = "Female";
                    }
                    if (hr.Checked)
                    {
                        Department = "HR";
                    }
                    else if (sales.Checked)
                    {
                        Department = "Sales";
                    }
                    else if (finance.Checked)
                    {
                        Department = "Finance";
                    }
                    else if (engineer.Checked)
                    {
                        Department = "Engineer";
                    }
                    else
                    {
                        Department = "Others";
                    }

                    if (propic1.Checked)
                    {
                        profileimg = "1";
                    }
                    else if (propic2.Checked)
                    {
                        profileimg = "2";
                    }
                    else if (propic3.Checked)
                    {
                        profileimg = "3";
                    }
                    else
                    {
                        profileimg = "4";
                    }

                    con.Open();
                    SqlCommand command = new SqlCommand("Register", this.con);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", Name.Text);
                    command.Parameters.AddWithValue("@ProfilePic", profileimg);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Department", Department);
                    command.Parameters.AddWithValue("@Salary", Salary.Value);
                    command.Parameters.AddWithValue("@Date", Date.Value);
                    command.Parameters.AddWithValue("@Notes", Notes.Text);
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your action has been recorded");
                    clear();
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void clear()
        {
            Name.Text = "";
            Salary.Value = 1;
            Notes.Text = "";
        }
        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void Notes_TextChanged(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {

            if (Name.Text == "")
            {
                MessageBox.Show("Please Fill All Feild");
            }
            else
            {
                try
                {
                    

                    if (rbmale.Checked)
                    {
                        Gender = "Male";
                    }
                    else
                    {
                        Gender = "Female";
                    }
                    if (hr.Checked)
                    {
                        Department = "HR";
                    }
                    else if (sales.Checked)
                    {
                        Department = "Sales";
                    }
                    else if (finance.Checked)
                    {
                        Department = "Finance";
                    }
                    else if (engineer.Checked)
                    {
                        Department = "Engineer";
                    }
                    else
                    {
                        Department = "Others";
                    }

                    if (propic1.Checked)
                    {
                        profileimg = "1";
                    }
                    else if (propic2.Checked)
                    {
                        profileimg = "2";
                    }
                    else if (propic3.Checked)
                    {
                        profileimg = "3";
                    }
                    else
                    {
                        profileimg = "4";
                    }

                    con.Open();
                    SqlCommand command = new SqlCommand("Update", this.con);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", Name.Text);
                    command.Parameters.AddWithValue("@ProfilePic", profileimg);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Department", Department);
                    command.Parameters.AddWithValue("@Salary", Salary.Value);
                    command.Parameters.AddWithValue("@Date", Date.Value);
                    command.Parameters.AddWithValue("@Notes", Notes.Text);
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your action has been recorded");
                    clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Name_TextChanged(object sender, EventArgs e)
        {
            //Name.Clear();
        }
      

        

        private void Salary_Scroll(object sender, EventArgs e)
        {
            label19.Text = Salary.Value.ToString();

        }
    }
}
