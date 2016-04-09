using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Dorknozzle
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
                BindGrid();

        }

        private void BindGrid()
        {
            SqlConnection conn;
            DataSet dataset = new DataSet();
            SqlDataAdapter adapter;
            /*string connectionString = ConfigurationManager.ConnectionStrings["Dorknozzle"].ConnectionString;
            conn = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("Select DepartmentID, Department from Departments", conn);
            adapter.SelectCommand = new SqlCommand("Select EmployeeID, Name, Telephone from Employees", conn);
            adapter.Fill(dataset, "Employees");
            departmentGrid.DataSource = dataset;
            departmentGrid.DataMember = "Employees";
            departmentGrid.DataBind();*/

            if (ViewState["DepartmentDataSet"] == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Dorknozzle"].ConnectionString;
                conn = new SqlConnection(connectionString);
                adapter = new SqlDataAdapter("Select DepartmentID, Department from Departments", conn);
                adapter.Fill(dataset, "Departments");
                ViewState["DeparmentsDataSet"] = dataset;

            }

            else
            {
                dataset = (DataSet)ViewState["DepartmentDataSet"];
            }


            string sortExpression;

            if (gridSortDirection == SortDirection.Ascending)
            {
                sortExpression = gridSortExpression + " ASC";
            }
            else
            {
                sortExpression = gridSortExpression + " DESC";
            }

            //Lenh duoi xac dinh kieu sort. 
             dataset.Tables["Departments"].DefaultView.Sort = sortExpression;
           
            //departmentGrid.DataSource = dataset;
            departmentGrid.DataSource = dataset.Tables["Departments"].DefaultView;// This statement is equal to statment above
            departmentGrid.DataBind();
        }

        protected void departmentGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            departmentGrid.PageIndex = newPageIndex;
            BindGrid();
        }






        protected void departmentGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            if (sortExpression == gridSortExpression)
            {
                if (gridSortDirection == SortDirection.Ascending)
                {
                    gridSortDirection = SortDirection.Descending;
                }
                else
                {
                    gridSortDirection = SortDirection.Ascending;
                }

            }
            else
            {
                gridSortDirection = SortDirection.Ascending;

            }
            gridSortExpression = sortExpression;
            BindGrid();
        }

        private SortDirection gridSortDirection // Dinh nghia mot Property
        {
            get
            {
                if(ViewState["GridSortDirection"]==null)
        // ViewState["anyName"] chi la mot an bat ki
        // Neu ban dau an nay ko co gia tri, thi gan cho no gia tri sort ascending, xep ABC
                {
                    ViewState["GridSortDirection"]= SortDirection.Ascending;
                }
                return (SortDirection) ViewState["GridSortDirection"];
            }
            set
            {
                ViewState["GridSortDirection"] = value;
            }
        }

        private string gridSortExpression // Dinh nghia mot Property
        {
            get
            {
                if(ViewState["GridSortExpression"]==null)
                {
                    ViewState["GridSortExpression"] = "DepartmentID";

                }
                return (string)ViewState["GridSortExpression"];
            }

            set
            {
                ViewState["GridSortExpression"] = value;
            }
        }
    }
}