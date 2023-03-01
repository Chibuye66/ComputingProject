using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace ComputingProject
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        private const string V = "Postion at Church";
        string connectionStrng = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MembershipFormDownloadBtn_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Applcation/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=EvergreenLibraryMembershipApplicationForm.pdf");
            Response.TransmitFile(Server.MapPath("Documents/EvergreenLibraryMembershipApplicationForm.pdf"));
            Response.End();
        }

        protected void InformationVerificationMembershipChkBx_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void MemberRegisterBtn_Click(object sender, EventArgs e)
        {
            if(CheckMemberExistance())
            {
                Response.Write("<script>alert('Sorry, the username you have entered has already been used, please enter a different one.')</script>");
            }

            else
            {
                RegisterNewMember();
                SendEmail();
            }
             
        }

        void SendEmail()
        {
            try
            {

                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "frost.calvinfrost@gmail.com";
                string emailPassowrd = "Csmcbm@1&";
                string emailTo = EmailMembershipTxt.Text;
                string subject ="Re: Evergreen Library Application Form Confirmation";
                string body = "Thank you for applying for membership with Evergreen Christian Library. You will recieve an email in the near future confirming whether your application has been accepted or denied.";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, emailPassowrd);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool CheckMemberExistance()
        {
            try { 
            SqlConnection dbconnection = new SqlConnection(connectionStrng);
            if (dbconnection.State == ConnectionState.Closed)
            {
                dbconnection.Open();
            }

            SqlCommand command = new SqlCommand("SELECT * FROM Members WHERE memberUsername='"+ memberUsername.Text.Trim() +"'", dbconnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

                if(dataTable.Rows.Count >= 1)
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

        void RegisterNewMember()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                if (!InformationVerificationMembershipChkBx.Checked)
                {
                    Response.Write("<script>alert('Please check the information verification statement.')</script>");
                }

                else if (String.IsNullOrEmpty(FirstNameMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(LastNameMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(CurrentAddressMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(CityMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(PassNRCMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(EmailMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(ChurchMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (ChurchPositionMembershipDrpDwn.SelectedValue == V)
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(ChurchLocationTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(ChurchEmailMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(ChurchCityMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(ChurchPositionMembershipDrpDwn.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(ChurchStateMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(LibraryIntroductionMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(EmploymentMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(RecommenderNameMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(RecommenderPhoneMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(RecommenderEmailAddressMembershipTxt.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(memberUsername.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else if (String.IsNullOrEmpty(memberPassword.Text))
                {
                    Response.Write("<script>alert('Please fill in all the fields.')</script>");
                }

                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Members VALUES (@FirstName, @LastName, @CurrentAddress, @City, @NRCPassportNo, @EmailAddress, @Church, @ChurchLocation, @ChurchEmail, @ChurchCity, @ChurchPosition," +
                        " @State, @Introduction, @EmploymentStatus, @RecName, @RecPhone, @RecEmail, @MemberPassword, @MemberPriv1, @MemberPriv2, @MemberPriv3, @MemberPriv4, @MemberUsername, @AccountState)", dbconnection);

                    cmd.Parameters.AddWithValue("@FirstName", FirstNameMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", LastNameMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@CurrentAddress", CurrentAddressMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@City", CityMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@NRCPassportNo", PassNRCMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmailAddress", EmailMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@Church", ChurchMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ChurchLocation", ChurchLocationTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ChurchEmail", ChurchEmailMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ChurchCity", ChurchCityMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@ChurchPosition", ChurchPositionMembershipDrpDwn.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@State", ChurchStateMembershipTxt.Text);
                    cmd.Parameters.AddWithValue("@Introduction", LibraryIntroductionMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmploymentStatus", EmploymentMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@RecName", RecommenderNameMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@RecPhone", RecommenderPhoneMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@RecEmail", RecommenderEmailAddressMembershipTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberPassword", memberPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberPriv1", ChildrenMembershipTxt1.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberPriv2", ChildrenMembershipTxt2.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberPriv3", ChildrenMembershipTxt3.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberPriv4", ChildrenMembershipTxt4.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberUsername", memberUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@AccountState", "Pending");

                    cmd.ExecuteNonQuery();
                    dbconnection.Close();

                    Response.Write("<script>alert('Application Submitted! You will recieve an email shortly. You can use your Username and Password to Login.')</script>");

                    Response.Redirect("MemberLogin.aspx");

                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}