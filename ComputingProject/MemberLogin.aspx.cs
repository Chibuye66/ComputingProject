using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputingProject
{
    public partial class MemberLogin : System.Web.UI.Page
    {

        string connectionStrng = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MemberLoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionStrng);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Members WHERE memberUsername='"+ MemberUsername.Text.Trim() + "' AND memberPassword='"+ MemberPassword.Text.Trim() +"'", connection);
                SqlDataReader dataReader = command.ExecuteReader();
                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                       

                        Session["memberUsername"] = dataReader.GetValue(23).ToString();
                        Session["FirstName"] = dataReader.GetValue(1).ToString();
                        Session["Role"] = "Member";
                        Session["AccountState"] = dataReader.GetValue(24).ToString();
                        Session["MemberID"] = dataReader.GetValue(0);
                    }

                    Response.Redirect("Home.aspx");
                }

                else
                { 
                    Response.Write("<script>alert('Either your username or password is incorrect, please re-enter correct credentials.')</script>");
                }
            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}