using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Dorknozzle
{
    public partial class AdminTools : System.Web.UI.Page


    {

        int ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            Loadlist();
        }
    

        protected void Update_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=localhost\\SqlExpress; Database=Dorknozzle; Integrated Security=True");
            SqlCommand comm;
            string connection = "Update Employees SET Name=@Name, Username=@Username, Department=@Department, Telephone=@Telephone, City=@City, State=@State where EmployeeID=@EmployeeID";
            comm = new SqlCommand(connection, conn);
            comm.Parameters.AddWithValue("@Name", Name.Text);
            comm.Parameters.AddWithValue("@Username", Username.Text);
            comm.Parameters.AddWithValue("@Department", Department.Text);
            comm.Parameters.AddWithValue("@Telephone", Telephone.Text);
            comm.Parameters.AddWithValue("@City", City.Text);
            comm.Parameters.AddWithValue("@State", State.Text);
            comm.Parameters.AddWithValue("@EmployeeID", Employee.SelectedValue);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();

            }
            catch
            {
                erroLabel.Text = "Cannot update anything";
            }

            finally
            {
                conn.Close();
            }

             
             EmployeeList();
             Loadlist();
            
        }

        private void EmployeeList()
        {
          
            SqlConnection conn = new SqlConnection("Server=localhost\\SqlExpress; Database=Dorknozzle; Integrated Security=True");
            SqlCommand comm;
            SqlDataReader reader;
            string connection = "Select EmployeeID, Name, Username, Department, Telephone, City, State from Employees where EmployeeID=@EmployeeID";
            //Update.Enabled = false;
            try
            {
                conn.Open();
                comm = new SqlCommand(connection, conn);
                comm.Parameters.AddWithValue("@EmployeeID", Employee.SelectedItem.Value);
                ID = Int16.Parse(Employee.SelectedItem.Value);
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Name.Text = reader["Name"].ToString();
                    Username.Text = reader["Username"].ToString();
                    Department.Text = reader["Department"].ToString();
                    Telephone.Text = reader["Telephone"].ToString();
                    City.Text = reader["City"].ToString();
                    State.Text = reader["State"].ToString();
                  
                }

            }

            finally
            {
                conn.Close();
            }
            
        }

        private void Loadlist()
        {
            SqlConnection conn = new SqlConnection("Server=localhost\\SqlExpress; Database=Dorknozzle; Integrated Security=True");
            SqlCommand comm;
            SqlDataReader reader;
            string connection = "Select Name, EmployeeID from Employees";
            comm = new SqlCommand(connection,conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                Employee.DataSource = reader;
                Employee.DataTextField = "Name";
                Employee.DataValueField = "EmployeeID";
                Employee.DataBind();
                reader.Close();

            }
            finally
            {
                conn.Close();
            }
          
        }

        protected void Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeList();
            
        }
    }
}