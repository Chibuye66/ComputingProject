using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputingProject
{
    public partial class Evergreen : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["Role"] == null)
                {
                    navMemberLogin.Visible = true;
                    NavAdminLogin.Visible = true;
                    NavSignUp.Visible = true;

                    NavLogout.Visible = false;
                    NavHelloUser.Visible = false;
                    NavHelloAdmin.Visible = false;

                    footerBtnBookInventory.Visible = false;
                    footerBtnMembers.Visible = false;
                    FootBtnAuthor.Visible = false;
                    FootBtnPublisher.Visible = false;
                    FootBtnCirculation.Visible = false;
                }

                else if (Session["Role"].Equals("Member"))
                {
                    footerBtnBookInventory.Visible = false;
                    footerBtnMembers.Visible = false;
                    FootBtnAuthor.Visible = false;
                    FootBtnPublisher.Visible = false;
                    FootBtnCirculation.Visible = false;

                    NavAdminLogin.Visible = false;
                    NavHelloAdmin.Visible = false;

                    navMemberLogin.Visible = false;
                    NavAdminLogin.Visible = false;
                    NavSignUp.Visible = false;

                    adminLoginFoot.Visible = true;

                    NavLogout.Visible = true;
                    NavHelloUser.Visible = true;
                    NavHelloUser.Text = Session["FirstName"].ToString();
                }

                else if (Session["Role"].Equals("Admin"))
                {
                    footerBtnBookInventory.Visible = true;
                    footerBtnMembers.Visible = true;
                    FootBtnAuthor.Visible = true;
                    FootBtnPublisher.Visible = true;
                    FootBtnCirculation.Visible = true;

                    NavSignUp.Visible = false;
                    navMemberLogin.Visible = false;

                    NavAdminLogin.Visible = false;
                    NavHelloAdmin.Visible = true;
                    NavHelloAdmin.Text = "Administrator";

                    NavLogout.Visible = true;
                    NavHelloUser.Visible = false;

                    adminLoginFoot.Visible = false;


                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void NavViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogue.aspx");
        }

        protected void NavAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministratorLogin.aspx");
        }

        protected void NavSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationPage.aspx");
        }

        protected void footerBtnBookInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookManagement.aspx");
        }

        protected void footerBtnMembers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministratorMemberManagement.aspx");
        }

        protected void footerBtnDistribution_Click(object sender, EventArgs e)
        {
            Response.Redirect("CirculationManagement.aspx");
        }

        protected void FootBtnCatalogue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogue.aspx");
        }

        protected void FootBtnCirculation_Click(object sender, EventArgs e)
        {
            Response.Redirect("CirculationManagement.aspx");
        }

        protected void FootBtnPublisher_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherManagement.aspx");
        }

        protected void FootBtnKBCSite_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://kabwatabaptistchurch.com");
        }

        protected void FootBtnAuthor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorManagement.aspx");
        }

        protected void NavLogout_Click(object sender, EventArgs e)
        {
            Session["Role"] = "";

            navMemberLogin.Visible = true;
            NavAdminLogin.Visible = true;
            NavSignUp.Visible = true;

            NavLogout.Visible = false;
            NavHelloUser.Visible = false;
            NavHelloAdmin.Visible = false;

            footerBtnBookInventory.Visible = false;
            footerBtnMembers.Visible = false;
            FootBtnAuthor.Visible = false;
            FootBtnPublisher.Visible = false;
            FootBtnCirculation.Visible = false;

            Response.Redirect("Home.aspx");

        }

        protected void NavHelloUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberProfilePage.aspx");
        }

        protected void FootBtnBorrow_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogue.aspx");
        }

        protected void FootBtnVisitUs_Click(object sender, EventArgs e)
        {
        Response.Redirect("https://goo.gl/maps/nqxVEmtYQLWkjw2m9");
        }

        protected void navMemberLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberLogin.aspx");
        }

        protected void adminLoginFoot_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministratorLogin.aspx");
        }

        protected void NavHelloAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}