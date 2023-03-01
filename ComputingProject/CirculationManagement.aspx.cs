using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ComputingProject
{
    public partial class CirculationManagement : System.Web.UI.Page
    {

        string connectionStrng = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

  
        protected void Page_Load(object sender, EventArgs e)
        {
            IssuedBooksGrdView.DataBind();

            
        }

        protected void GoCirculationgmtBtn_Click(object sender, EventArgs e)
        {
            getBookMemberNames();
        }

        protected void IssueBookMgmtBtn_Click(object sender, EventArgs e)
        {

            if (checkBookExistence() && checkMemberExistence())
            {
                if (checkIssueExistence())
                {
                    Response.Write("<script>alert('This member already has the book you are trying to issue out.')</script>");
                }

                else
                {
                    issueBook();
                }
            }
            else
            {
                Response.Write("<script>alert('Either the MemberID or the BookID you have entered is incorrect. Check them and try again.')</script>");
            }

        }

        protected void ReturnBookMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkBookExistence() && checkMemberExistence())
            {
                if (checkIssueExistence())
                {
                    returnBook();
                   
                }

                else
                {
                    Response.Write("<script>alert('This entry does not exist.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Either the MemberID or the BookID you have entered is incorrect. Check them and try again.')</script>");
            }
        }

        void getBookMemberNames()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Members WHERE MemberID ='" + MemberIDCirclationMgmtTxt.Text.Trim() + "'", dbconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    MemberNameCirculationMgmtTxt.Text = dataTable.Rows[0][1].ToString() + " " + dataTable.Rows[0][2].ToString();
                }

                else
                {
                    Response.Write("<script>alert('The Member ID you have entered does not exist, check it and try again.')</script>");
                }

                command = new SqlCommand("SELECT BookName FROM Books WHERE BookID = '" + BookIDCirculationMgmtTxt.Text.Trim() + "'", dbconnection);
                dataAdapter = new SqlDataAdapter(command);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    BookNameCirculationMgmtTxt.Text = dataTable.Rows[0][0].ToString();
                }

                else
                {
                    Response.Write("<script>alert('The Book ID you have entered does not exist, check it and try again.')</script>");
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool checkBookExistence()
        {

            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Books WHERE BookID ='" + BookIDCirculationMgmtTxt.Text.Trim() + "' AND CurrentStock > 0", dbconnection);
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
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        bool checkMemberExistence()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Members WHERE MemberID ='" + MemberIDCirclationMgmtTxt.Text.Trim() + "'", dbconnection);
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
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        void issueBook()
        {
            try
            {

                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("INSERT INTO BookIssues VALUES (@MemberID, @MemberName, @BookName, @Issuedate, @Duedate, @BookID)", dbconnection);


                SqlParameter param = command.Parameters.Add("@MemberID", SqlDbType.Int);
                param.Value = MemberIDCirclationMgmtTxt.Text.Trim();

                SqlParameter param1 = command.Parameters.Add("@MemberName", SqlDbType.VarChar);
                param1.Value = MemberNameCirculationMgmtTxt.Text.Trim();

                SqlParameter param2 = command.Parameters.Add("@BookName", SqlDbType.VarChar);
                param2.Value = BookNameCirculationMgmtTxt.Text.Trim();

                SqlParameter param3 = command.Parameters.Add("@Issuedate", SqlDbType.Date);
                param3.Value = IssueDateCirculationMgmntTxt.Text.Trim();

                SqlParameter param4 = command.Parameters.Add("@Duedate", SqlDbType.Date);
                param4.Value = ReturnDateCirculationMgmntTxt.Text.Trim();

                SqlParameter param5 = command.Parameters.Add("@BookID", SqlDbType.Int);
                param5.Value = BookIDCirculationMgmtTxt.Text.Trim();

                command.ExecuteNonQuery();

                command = new SqlCommand("UPDATE Books SET CurrentStock = CurrentStock-1 WHERE BookID = '"+ BookIDCirculationMgmtTxt.Text.Trim() +"'", dbconnection);
                command.ExecuteNonQuery();

                dbconnection.Close();

                Response.Write("<script>alert('Issued ' + '" + BookNameCirculationMgmtTxt.Text.ToString().Trim() + "' + ' out to ' + '" + MemberNameCirculationMgmtTxt.Text.Trim() + "')</script>");

                

                IssuedBooksGrdView.DataBind();

                clearForm();


                dbconnection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool checkIssueExistence()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM BookIssues WHERE Member_ID ='" + MemberIDCirclationMgmtTxt.Text.Trim() + "' AND Book_ID = '"+ BookIDCirculationMgmtTxt.Text.Trim() +"'", dbconnection);
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
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        void returnBook()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }


                SqlCommand command = new SqlCommand("DELETE FROM BookIssues WHERE Member_ID ='" + MemberIDCirclationMgmtTxt.Text.Trim() + "' AND Book_ID = '" + BookIDCirculationMgmtTxt.Text.Trim() + "'", dbconnection);

                int result = command.ExecuteNonQuery();

                

                if (result > 0)
                { 
                    command = new SqlCommand("UPDATE Books SET CurrentStock = CurrentStock + 1 WHERE BookID = '" + BookIDCirculationMgmtTxt.Text.Trim() + "'", dbconnection);
                    command.ExecuteNonQuery();

                    dbconnection.Close();

                    Response.Write("<script>alert('Successfully returned ' + '" + BookNameCirculationMgmtTxt.Text.ToString().Trim() + "'')</script>");

                    IssuedBooksGrdView.DataBind();

                    clearForm();
                    
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }


        void clearForm()
        {
            MemberIDCirclationMgmtTxt.Text = "";
            MemberNameCirculationMgmtTxt.Text = "";
            BookNameCirculationMgmtTxt.Text = "";
            IssueDateCirculationMgmntTxt.Text = "";
            ReturnDateCirculationMgmntTxt.Text = "";
            BookIDCirculationMgmtTxt.Text = "";

        }

        protected void IssuedBooksGrdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try 
            {
            if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today>dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}