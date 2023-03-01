using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ComputingProject
{
    public partial class MemberProfilePage : System.Web.UI.Page
    {
        string connectionStrng = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["memberUsername"].ToString() == "" || Session["memberUsername"].ToString() == null )
                {
                    Response.Write("<script>alert('The session has expired, please login again.')</script>");
                    Response.Redirect("MemberLogin.aspx");
                }

                else 
                {
                    getIssuesData();

                    if(!Page.IsPostBack)
                    {
                        getUserDetails();
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        protected void MemberProfileUpdateBtn_Click(object sender, EventArgs e)
        {
            if (Session["memberUsername"].ToString() == "" || Session["memberUsername"].ToString() == null)
            {
                Response.Write("<script>alert('The session has expired, please login again.')</script>");
                Response.Redirect("MemberLogin.aspx");
            }

            else
            {
                updateMemberInfo();
            }
        }

        void updateMemberInfo()
        {
            string password = "";
            if (newPassProfileTxt.Text.Trim() == "")
            {
                password = oldPassProfileTxt.Text.Trim();
            }

            else
            {
                password = newPassProfileTxt.Text.Trim();

            }

            try
            {

                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("UPDATE Members SET FirstName=@FirstName, LastName=@LastName, CurrentAddress=@CurrentAddress, City=@City, NRCPassportNo=@NRCPassportNo, EmailAddress=@EmailAddress, Church=@Church, ChurchLocation=@ChurchLocation, ChurchEmail=@ChurchEmail, ChurchCity=@ChurchCity, ChurchPosition=@ChurchPosition, State=@State, EmploymentStatus=@EmploymentStatus, MemberPassword@MemberPassword, MemberPriv1=@MemberPriv1, MemberPriv2=@MemberPriv2, MemberPriv3=@MemberPriv3, MemberPriv4=@MemberPriv4 WHERE MemberID='"+ Session["MemberID"].ToString().Trim() + "'", dbconnection);

                SqlParameter param = command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                param.Value = FirstNameProfileTxt.Text.Trim();

                SqlParameter param1 = command.Parameters.Add("@LastName", SqlDbType.VarChar);
                param1.Value = LastNameProfileTxt.Text.Trim();

                SqlParameter param2 = command.Parameters.Add("@CurrentAddress", SqlDbType.VarChar);
                param2.Value = CurrentAddressProfileTxt.Text.Trim();

                SqlParameter param3 = command.Parameters.Add("@City", SqlDbType.VarChar);
                param3.Value = CityProfileTxt.Text.Trim();

                SqlParameter param4 = command.Parameters.Add("@NRCPassportNo", SqlDbType.VarChar);
                param4.Value = PassNRCProfileTxt.Text.Trim();

                SqlParameter param5 = command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                param5.Value = EmailProfileTxt.Text.Trim();

                SqlParameter param6 = command.Parameters.Add("@Church", SqlDbType.VarChar);
                param6.Value = ChurchProfileTxt.Text.Trim();

                SqlParameter param7 = command.Parameters.Add("@ChurchLocation", SqlDbType.VarChar);
                param7.Value = ChurchLocationProfileTxt.Text.Trim();

                SqlParameter param8 = command.Parameters.Add("@ChurchEmail", SqlDbType.VarChar);
                param8.Value = ChurchEmailProfileTxt.Text.Trim();

                SqlParameter param9 = command.Parameters.Add("@ChurchCity", SqlDbType.VarChar);
                param9.Value = ChurchCityProfileTxt.Text.Trim();

                SqlParameter param10 = command.Parameters.Add("@ChurchPosition", SqlDbType.VarChar);
                param10.Value = ChurchPositionProfileDrpDwn.SelectedItem.Value;

                SqlParameter param11 = command.Parameters.Add("@State", SqlDbType.VarChar);
                param11.Value = ChurchStateProfileTxt.Text.Trim();

                SqlParameter param12 = command.Parameters.Add("@EmploymentStatus", SqlDbType.VarChar);
                param12.Value = employmentStatusProfileTxt.Text.Trim();

                SqlParameter param13 = command.Parameters.Add("@MemberPassword", SqlDbType.VarChar);
                param13.Value = newPassProfileTxt.Text.Trim();

                SqlParameter param14 = command.Parameters.Add("@MemberPriv1", SqlDbType.VarChar);
                param14.Value = ChildrenProfileTxt1.Text.Trim();

                SqlParameter param15 = command.Parameters.Add("@MemberPriv2", SqlDbType.VarChar);
                param15.Value = ChildrenProfileTxt2.Text.Trim();

                SqlParameter param16 = command.Parameters.Add("@MemberPriv3", SqlDbType.VarChar);
                param16.Value = ChildrenProfileTxt3.Text.Trim();

                SqlParameter param17 = command.Parameters.Add("@MemberPriv4", SqlDbType.VarChar);
                param17.Value = ChildrenProfileTxt4.Text.Trim();

                int result = command.ExecuteNonQuery();
                dbconnection.Close();

                if (result>0)
                {
                    Response.Write("<script>alert('Updated your details successfully.')</script>");
                    getUserDetails();
                    getIssuesData();
                       
                }

                else
                {
                    Response.Write("<script>alert('Invalid entry.')</script>");
                }


            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void getUserDetails()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Members WHERE MemberID ='" + Session["MemberID"] + "';", dbconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                FirstNameProfileTxt.Text = dataTable.Rows[0]["FirstName"].ToString();
                LastNameProfileTxt.Text = dataTable.Rows[0]["LastName"].ToString();
                CurrentAddressProfileTxt.Text = dataTable.Rows[0]["CurrentAddress"].ToString();
                CityProfileTxt.Text = dataTable.Rows[0]["City"].ToString();
                PassNRCProfileTxt.Text = dataTable.Rows[0]["NRCPassportNo"].ToString();
                EmailProfileTxt.Text = dataTable.Rows[0]["EmailAddress"].ToString();
                ChurchProfileTxt.Text = dataTable.Rows[0]["Church"].ToString();
                ChurchLocationProfileTxt.Text = dataTable.Rows[0]["ChurchLocation"].ToString();
                ChurchEmailProfileTxt.Text = dataTable.Rows[0]["ChurchEmail"].ToString();
                ChurchCityProfileTxt.Text = dataTable.Rows[0]["ChurchCity"].ToString();
                ChurchPositionProfileDrpDwn.SelectedValue = dataTable.Rows[0]["ChurchPosition"].ToString();
                ChurchStateProfileTxt.Text = dataTable.Rows[0]["State"].ToString();
                ChildrenProfileTxt1.Text = dataTable.Rows[0]["MemberPriv1"].ToString();
                ChildrenProfileTxt2.Text = dataTable.Rows[0]["MemberPriv2"].ToString();
                ChildrenProfileTxt3.Text = dataTable.Rows[0]["MemberPriv3"].ToString();
                ChildrenProfileTxt4.Text = dataTable.Rows[0]["MemberPriv4"].ToString();
                oldPassProfileTxt.Text = dataTable.Rows[0]["MemberPassword"].ToString();
                employmentStatusProfileTxt.Text = dataTable.Rows[0]["EmploymentStatus"].ToString();

                AccountStatusLbl.Text = dataTable.Rows[0]["AccountState"].ToString().Trim();

               if (dataTable.Rows[0]["AccountState"].ToString().Trim() == "Active")
                {
                    AccountStatusLbl.Attributes.Add("class", "badge rounded-pill bg-success");
                }
                else if (dataTable.Rows[0]["AccountState"].ToString().Trim() == "Pending")
                {
                    AccountStatusLbl.Attributes.Add("class", "badge rounded-pill bg-secondary");
                }
                else if (dataTable.Rows[0]["AccountState"].ToString().Trim() == "Inactive")
                {
                    AccountStatusLbl.Attributes.Add("class", "badge rounded-pill bg-danger");
                }

                dbconnection.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void getIssuesData()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM BookIssues WHERE Member_ID ='" + Session["MemberID"] + "';", dbconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                IssuedBooksProfileGrdView.DataSource = dataTable;
                IssuedBooksProfileGrdView.DataBind();

                dbconnection.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void IssuedBooksProfileGrdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[4].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
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