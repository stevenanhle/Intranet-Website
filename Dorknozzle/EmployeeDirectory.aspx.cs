using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Dorknozzle
{
    public partial class EmployeeDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }
        protected void BindList()
        {
            SqlConnection conn;
            SqlCommand command;
            SqlDataReader reader;
            //string connection = ConfigurationManager.ConnectionStrings["Dorknozzle"].ConnectionString;
            //conn = new SqlConnection(connection);
            conn = new SqlConnection("Server=localhost\\SqlExpress; Database=Dorknozzle; Integrated Security=True");
            command = new SqlCommand("Select EmployeeID, Name, Username, City, State from Employees", conn);
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                employeeList.DataSource = reader;
                employeeList.DataBind();
                reader.Close();
            }
            finally
            {
                conn.Close();
            }
        }
        protected void employeeList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "MoreDetailsPlease")
            {
                Literal listeral = new Literal();
                listeral = (Literal)e.Item.FindControl("extraDetailsLiteral");
                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(';');
                listeral.Text = "Employee ID: <strong>" + arg[0].ToString() + "</strong><br/>" + "City:<strong>" + arg[1].ToString() + "</strong><br/>" + "State:<strong>" + arg[2].ToString() + "</strong><br/>";
            }
            if (e.CommandName == "editInfor")
            {
                employeeList.EditItemIndex = e.Item.ItemIndex;
                BindList();
            }
            if (e.CommandName == "CancelItem")
            {
                employeeList.EditItemIndex = -1;
                BindList();
            }

            if (e.CommandName == "UpdateItem")
            {
                int employeeId = Convert.ToInt32(e.CommandArgument);
                TextBox nameTextBox = (TextBox)e.Item.FindControl("nameTextBox");
                string newName = nameTextBox.Text;
                TextBox usernameTextBox = (TextBox)e.Item.FindControl("usernameTextBox");
                string newUserName = usernameTextBox.Text;
                UpdateItem(employeeId, newName, newUserName);
                employeeList.EditItemIndex = -1;
                BindList();
            }
        }

        private void UpdateItem(int employeeId, string newName, string newUserName)
        {
            SqlConnection conn;
            SqlCommand comm;
            conn = new SqlConnection("Server=localhost\\SqlExpress; Database=Dorknozzle; Integrated Security=True");
            //string command = "Update Employees SET Name=@newName, Username= @newUsername where EmployeeID=@EmployeeID";
           // comm = new SqlCommand(command, conn);
            comm = new SqlCommand("UpdateEmployee", conn);
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@newName", newName);
            comm.Parameters.AddWithValue("@newUsername", newUserName);
            comm.Parameters.AddWithValue("@EmployeeID", employeeId);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

       
    }
}