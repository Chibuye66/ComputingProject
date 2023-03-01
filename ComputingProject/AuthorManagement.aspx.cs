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
    public partial class AuthorManagement : System.Web.UI.Page
    {

        string connectionStrng = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorListMgmtGrdView.DataBind();
            
        }

        protected void AddAuthorMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                Response.Write("<script>alert('This author already exists, please enter a new author.')</script>");
            }

            else
            {
                addNewAuthor();
            }
        }

        protected void UpdateAuthorMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                updateAuthor();
            }

            else
            {
                Response.Write("<script>alert('The Author ID you have entered does not exist, check it and try again.')</script>");
            }
        }

        protected void DeleteAuthorMgmtBtn_Click(object sender, EventArgs e)
        {

            if (checkAuthorExists())
            {
                deleteAuthor();
            }

            else
            {
                Response.Write("<script>alert('The Author ID you have entered does not exist, check it and try again.')</script>");
            }
        }

        protected void GoAuthorMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                getAuthorByID();
            }

            else
            {
                Response.Write("<script>alert('The Author ID you have entered does not exist, check it and try again.')</script>");
            }
        }

        void getAuthorByID ()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Authors WHERE AuthorID ='" + AuthorIDMgmtTxt.Text.Trim() + "'", dbconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    AuthorNameMgmtTxt.Text = dataTable.Rows[0][1].ToString();
                }

                else
                {
                    Response.Write("<script>alert('The Author ID you have entered does not exist, check it and try again.')</script>");
                }

                dbconnection.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void addNewAuthor()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("INSERT INTO Authors VALUES (@AuthorName)", dbconnection);
                command.Parameters.AddWithValue("@AuthorName", AuthorNameMgmtTxt.Text.Trim());
                command.ExecuteNonQuery();
                dbconnection.Close();

                Response.Write("<script>alert('New Author Added.')</script>");

                AuthorNameMgmtTxt.Text = "";
                AuthorIDMgmtTxt.Text = "";

                AuthorListMgmtGrdView.DataBind();
                AuthorListMgmtGrdView.HeaderRow.TableSection = TableRowSection.TableHeader;

                dbconnection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool checkAuthorExists()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Authors WHERE AuthorID ='" + AuthorIDMgmtTxt.Text.Trim() + "'", dbconnection);
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

        void updateAuthor()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }


                SqlCommand command = new SqlCommand("UPDATE Authors SET AuthorName = @AuthorName WHERE AuthorID = '"+ AuthorIDMgmtTxt.Text.Trim() +"'", dbconnection);
                command.Parameters.AddWithValue("@AuthorName", AuthorNameMgmtTxt.Text.Trim());
                command.ExecuteNonQuery();
                dbconnection.Close();

                Response.Write("<script>alert('Author information updated successfully.')</script>");

                AuthorNameMgmtTxt.Text = "";
                AuthorIDMgmtTxt.Text = "";

                AuthorListMgmtGrdView.DataBind();
                AuthorListMgmtGrdView.HeaderRow.TableSection = TableRowSection.TableHeader;

                dbconnection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }


                SqlCommand command = new SqlCommand("DELETE FROM Authors WHERE AuthorID = '" + AuthorIDMgmtTxt.Text.Trim() + "'", dbconnection);
                
                command.ExecuteNonQuery();
                dbconnection.Close();

                Response.Write("<script>alert('Author information deleted successfully.')</script>");

                AuthorNameMgmtTxt.Text = "";
                AuthorIDMgmtTxt.Text = "";

                AuthorListMgmtGrdView.DataBind();
                AuthorListMgmtGrdView.HeaderRow.TableSection = TableRowSection.TableHeader;

                dbconnection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void SqlDataSourceAuthors_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void AuthorListMgmtGrdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void AuthorListMgmtGrdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AuthorListMgmtGrdView.PageIndex = e.NewPageIndex;
            getAuthorByID();
            AuthorListMgmtGrdView.DataBind();

        }
    }
}