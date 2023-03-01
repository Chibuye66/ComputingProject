<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="AdministratorLogin.aspx.cs" Inherits="ComputingProject.AdministratorLogin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

     <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="Images/MemberIcon.png" />
                                </center>
                            </div>

                        </div>

                        <br />

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Administrator Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>




                        <div class="row">
                            <div class="col">

                                <br />

                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="AdministratorUsername" runat="server" placeholder="Username"></asp:TextBox>
                                </div>

                                <br />

                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="AdministratorPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                                <br />
                                <br />

                                <div class="form-group d-grid gap-2">
                                    <asp:Button class="btn btn-outline-secondary btn-block" ID="AdministratorLoginBtn" runat="server" Text="Login" OnClick="AdministratorLoginBtn_Click" />
                                </div>

                                <br />

                                <div class="form-group">
                                    <a class="d-grid gap-2" href="MemberLogin.aspx">
                                        <input class="btn btn-outline-dark" id="MemberSignUpBtn" type="button" value="Member Login" /></a>
                                </div>

                                

                               

                            </div>
                        </div>

                    </div>
                </div>

                <br />

                <a href="Home.aspx"><< Home</a>
            </div>
        </div>
    </div>
</asp:Content>
