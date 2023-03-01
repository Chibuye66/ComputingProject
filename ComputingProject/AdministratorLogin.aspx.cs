using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputingProject
{
    public partial class AdministratorLogin : System.Web.UI.Page
    {
        string connectionStrng = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdministratorLoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionStrng);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM AdminLogin WHERE Username ='" + AdministratorUsername.Text.Trim() + "' AND AdminPassword ='" + AdministratorPassword.Text.Trim() + "'", connection);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Session["Username"] = dataReader.GetValue(0).ToString();                       
                        Session["Role"] = "Admin";
                       
                    }

                    Response.Redirect("Home.aspx");
                }

                else
                {
                    Response.Write("<script>alert('Either your username or password is incorrect, please re-enter correct credentials.')</script>");
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}