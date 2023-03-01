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
    public partial class AdministratorMemberManagement : System.Web.UI.Page
    {
        string connectionStrng = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMemberListMgmtGrdView.DataBind(); 
        }

        protected void AdminMemberIdGoBtn_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }

        protected void ActiveAcctAdminBtn_Click(object sender, EventArgs e)
        {

        
                updateMemberStatusByID("Active");
           
        }

        protected void PendAcctAdminBtn_Click(object sender, EventArgs e)
        {

                updateMemberStatusByID("Pending");
           
            
        }

        protected void DeactivateAdminBtn_Click(object sender, EventArgs e)
        {
           
                updateMemberStatusByID("Inactive");
          

        }

        protected void DeleteMemberBtn_Click(object sender, EventArgs e)
        {
            deleteMember();
        }

        protected void AdminMemberListMgmtGrdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        bool checkMemberrExists()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Members WHERE MemberID ='" + AdminMemberIDTxt.Text.Trim() + "'", dbconnection);
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

        void getMemberByID()
        {
            if (checkMemberrExists())
            {

                try
                {
                    SqlConnection connection = new SqlConnection(connectionStrng);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand command = new SqlCommand("SELECT * FROM Members WHERE MemberID ='" + AdminMemberIDTxt.Text.Trim() + "'", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            AdminMemberAcctSttusTxt.Text = dataReader.GetValue(24).ToString();
                            FirstNameProfileTxt.Text = dataReader.GetValue(1).ToString();
                            LastNameProfileTxt.Text = dataReader.GetValue(2).ToString();
                            CurrentAddressProfileTxt.Text = dataReader.GetValue(3).ToString();
                            CityProfileTxt.Text = dataReader.GetValue(4).ToString();
                            PassNRCProfileTxt.Text = dataReader.GetValue(5).ToString();
                            EmailProfileTxt.Text = dataReader.GetValue(6).ToString();
                            ChurchProfileTxt.Text = dataReader.GetValue(7).ToString();
                            ChurchLocationProfileTxt.Text = dataReader.GetValue(8).ToString();
                            ChurchEmailProfileTxt.Text = dataReader.GetValue(9).ToString();
                            ChurchCityAdminMemberTxt.Text = dataReader.GetValue(10).ToString();
                            AdminMmbrMgmntChrchPosition.Text = dataReader.GetValue(11).ToString();
                            ChurchStateAdminMemberTxt.Text = dataReader.GetValue(12).ToString();
                            RecomAdminMmbrMgmtTxt.Text = dataReader.GetValue(15).ToString();
                            ChildrenProfileTxt1.Text = dataReader.GetValue(19).ToString();
                            ChildrenProfileTxt2.Text = dataReader.GetValue(20).ToString();
                            ChildrenProfileTxt3.Text = dataReader.GetValue(21).ToString();
                            ChildrenProfileTxt4.Text = dataReader.GetValue(22).ToString();

                        }

                    }

                    else
                    {
                        Response.Write("<script>alert('The MemberID you have entered does not exist, check it and try again.')</script>");
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
               
            }
            else
            {
                Response.Write("<script>alert('Please enter a valid MemberID')</script>");
            }
        }

        void updateMemberStatusByID(string Status)
        {

            if (checkMemberrExists())
            {

                try
                {
                    SqlConnection dbconnection = new SqlConnection(connectionStrng);
                    if (dbconnection.State == ConnectionState.Closed)
                    {
                        dbconnection.Open();
                    }


                    SqlCommand command = new SqlCommand("UPDATE Members SET AccountState = '" + Status + "' WHERE MemberID = '" + AdminMemberIDTxt.Text.Trim() + "'", dbconnection);

                    command.ExecuteNonQuery();
                    dbconnection.Close();

                    AdminMemberAcctSttusTxt.Text = Status;

                    Response.Write("<script>alert('Member acccount state updated successfully.')</script>");

                    AdminMemberListMgmtGrdView.DataBind();



                    dbconnection.Close();
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please enter a valid MemberID')</script>");
            }

        }

        void deleteMember()
        {

            if (checkMemberrExists())
            {
                try
                {
                    SqlConnection dbconnection = new SqlConnection(connectionStrng);
                    if (dbconnection.State == ConnectionState.Closed)
                    {
                        dbconnection.Open();
                    }


                    SqlCommand command = new SqlCommand("DELETE FROM Members WHERE MemberID = '" + AdminMemberIDTxt.Text.Trim() + "'", dbconnection);

                    command.ExecuteNonQuery();
                    dbconnection.Close();

                    Response.Write("<script>alert('Member permanently deleted successfully.')</script>");

                    clearForm();

                    AdminMemberListMgmtGrdView.DataBind();


                    dbconnection.Close();
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
              
            }
            else
            {
                Response.Write("<script>alert('Please enter a valid MemberID')</script>");
            }
        }

        void clearForm()
        {
            AdminMemberAcctSttusTxt.Text = "";
            FirstNameProfileTxt.Text = "";
            LastNameProfileTxt.Text = "";
            CurrentAddressProfileTxt.Text = "";
            CityProfileTxt.Text = "";
            PassNRCProfileTxt.Text = "";
            EmailProfileTxt.Text = "";
            ChurchProfileTxt.Text = "";
            ChurchLocationProfileTxt.Text = "";
            ChurchEmailProfileTxt.Text = "";
            ChurchCityAdminMemberTxt.Text = "";
            AdminMmbrMgmntChrchPosition.Text = "";
            ChurchStateAdminMemberTxt.Text = "";
            RecomAdminMmbrMgmtTxt.Text = "";
            ChildrenProfileTxt1.Text = "";
            ChildrenProfileTxt2.Text = "";
            ChildrenProfileTxt3.Text = "";
            ChildrenProfileTxt4.Text = "";
        }
    }
}