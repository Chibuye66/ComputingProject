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
    public partial class PublisherManagement : System.Web.UI.Page
    {
        string connectionStrng = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            PublisherListMgmntGrdView.DataBind();
        }

        protected void GoPublisherMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                getPublisherByID();
            }

            else
            {
                Response.Write("<script>alert('The Author ID you have entered does not exist, check it and try again.')</script>");
            }
        }

        protected void AddPublisherMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                Response.Write("<script>alert('This Publisher already exists, please enter a new author.')</script>");
            }

            else
            {
                addNewPublisher();
            }
        }

        protected void UpdatePublisherMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                updatePublisher();
            }

            else
            {
                Response.Write("<script>alert('The Publisher ID you have entered does not exist, check it and try again.')</script>");
            }
        }

        protected void DeletePublisherMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                deletePublisher();
            }

            else
            {
                Response.Write("<script>alert('The Publisher ID you have entered does not exist, check it and try again.')</script>");
            }
        }


        bool checkPublisherExists()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Publishers WHERE PublisherID ='" + PublisherIDMgmtTxt.Text.Trim() + "'", dbconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    return true;
                }

                else
                {
                    return false;
                }

                dbconnection.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }


        void getPublisherByID()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Publishers WHERE PublisherID ='" + PublisherIDMgmtTxt.Text.Trim() + "'", dbconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    PublisherNameMgmtTxt.Text = dataTable.Rows[0][1].ToString();
                }

                else
                {
                    Response.Write("<script>alert('The Publisher ID you have entered does not exist, check it and try again.')</script>");
                }

                dbconnection.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void addNewPublisher()
        {
            try
            {

                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("INSERT INTO Publishers VALUES (@PublisherName)", dbconnection);

               // command.Parameters.AddWithValue("@PublisherName", PublisherNameMgmtTxt.Text.Trim());

                SqlParameter param = command.Parameters.Add("@PublisherName", SqlDbType.VarChar);                
                param.Value = PublisherNameMgmtTxt.Text.Trim();

                command.ExecuteNonQuery();
                dbconnection.Close();

                Response.Write("<script>alert('New Publisher Added.')</script>");

                PublisherNameMgmtTxt.Text = "";
                PublisherIDMgmtTxt.Text = "";

                PublisherListMgmntGrdView.DataBind();
                

                dbconnection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        void updatePublisher()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }


                SqlCommand command = new SqlCommand("UPDATE Publishers SET PublisherName = @PublisherName WHERE PublisherID = '" + PublisherIDMgmtTxt.Text.Trim() + "'", dbconnection);
                command.Parameters.AddWithValue("@AuthorName", PublisherNameMgmtTxt.Text.Trim());
                command.ExecuteNonQuery();
                dbconnection.Close();

                Response.Write("<script>alert('Publisher information updated successfully.')</script>");

                PublisherNameMgmtTxt.Text = "";
                PublisherIDMgmtTxt.Text = "";

                PublisherListMgmntGrdView.DataBind();
                
                dbconnection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void deletePublisher()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }


                SqlCommand command = new SqlCommand("DELETE FROM Publishers WHERE PublisherID = '" + PublisherIDMgmtTxt.Text.Trim() + "'", dbconnection);

                command.ExecuteNonQuery();
                dbconnection.Close();

                Response.Write("<script>alert('Publisher information deleted successfully.')</script>");

                PublisherNameMgmtTxt.Text = "";
                PublisherIDMgmtTxt.Text = "";

                PublisherListMgmntGrdView.DataBind();
                

                dbconnection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}