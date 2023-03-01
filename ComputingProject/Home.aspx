<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ComputingProject.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <section>
    <div class="container">

            <div class="row">

                <div class="col-md-4">
                    <center>
                        <h3>
                            <br />
                            <br />
                            
                            
                           The Evergreen Christian Public Library is a Ministry of Kabwata Baptist Church.</h3>

                        <p class="text-justify" fontsize="14">
                            The primary purpose of the ministry is to spread the truth of the gospel of our Lord Jesus Christ through sound Christian books, magazines and preached recorded sermons to both Christians and non-Christians.
                     <br />
                            </p>
                    </center>
                </div>
                

                <div class="col-md-8">
                        <center>                                     
                        <img src="Images/Logo%20with%20white%20Background.jpg" width="1350"/>
                    </center>
                </div>

            </div>
        </div>
        </section>

    <br />
    <br />
    <br />

   <section>

       <div class ="container">
            <div class="row">
                <div class="col-md-4">
                    <center>
                        <a href="Catalogue.aspx">
                        <img width="100" src="Images/Catalogue%20Icon.jpg" alt="Browse Catalogue" />
                            </a>
                        <br /><br />
                        <h2>Browse through our catalogue.</h2>
                    </center>
                </div>


                <div class="col-md-4">
                    <center>
                        <a href="RegistrationPage.aspx">
                        <img width="100" src="Images/SignUp%20Icon.jpg" alt="Get Registered"/>
                            </a>
                        <h2>
                            <br />
                            Get Registered.</h2>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <br />
                        <a href="https://goo.gl/maps/nqxVEmtYQLWkjw2m9">
                        <img width="80" height="80"  src="Images/Location%20Icon.png" alt="Library Location" />
                            </a>
                        <br /><br /><br />
                        <h2>Visit Us.</h2>
                    </center>
                </div>

            </div>

        </div>

    </section>

    <br />
    <br />
    <br />

    <section>
        <div class="container">

            <div class="row">

                <div class="col-md-6">
                    <center>
                        <h4>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            Looking for something to read?</h4>
                        <p class="text-justify">
                            As Christians, we should always be eager to supplement our spiritual diet with good Christian literature. Here's our two recommended books from our shelves for the month of February.
                        </p>
                    </center>
                </div>

                <div class="col-md-6">
                    <center>
                        <br />
                        <br />
                        <img width="500" src="Images/February%20Read.jpg" />
                    </center>
                </div>

            </div>
        </div>
    </section>

</asp:Content>
