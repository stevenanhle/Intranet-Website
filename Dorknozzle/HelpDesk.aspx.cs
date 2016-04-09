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
    public partial class HelpDesk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlConnection conn = new SqlConnection("Server=localhost\\SqlExpress;Database=Dorknozzle;Integrated Security=True");
                string insertCommand = "INSERT INTO HelpDesk (EmployeeID, StationNumber, CategoryID, SubjectID, Description, StatusID)" +
                    " Values (@EmployeeID, @StationNumber, @CategoryID, @SubjectID, @Description, @StatusID)";
                SqlCommand command = new SqlCommand(insertCommand, conn);
               // SqlCommand command = new SqlCommand("InsertHelpDesk", conn);
               // command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", 5);
                command.Parameters.AddWithValue("@StationNumber", int.Parse(stationTextBox.Text));
                command.Parameters.AddWithValue("@CategoryID", DropDownList1.SelectedItem.Value);
                command.Parameters.AddWithValue("@SubjectID", DropDownList2.SelectedItem.Value);
                command.Parameters.AddWithValue("@Description", description.Text);
                command.Parameters.AddWithValue("@StatusID", 1);
         
                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    Response.Redirect("HelpDesk.aspx");
                }

                finally
                {
                    conn.Close();
                }
                
            }
        }
    }
}