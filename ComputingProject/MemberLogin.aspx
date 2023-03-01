 <%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="ComputingProject.MemberLogin" %>

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

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
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
                                    <asp:TextBox CssClass="form-control" ID="MemberUsername" runat="server" placeholder="Username"></asp:TextBox>
                                </div>

                                <br />

                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="MemberPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                                <br />
                                <br />

                                <div class="form-group d-grid gap-2">
                                    <asp:Button class="btn btn-outline-secondary btn-block" ID="MemberLoginBtn" runat="server" Text="Login" OnClick="MemberLoginBtn_Click" />
                                </div>

                                <br />

                                <div class="form-group">
                                    <a class="d-grid gap-2" href="RegistrationPage.aspx">
                                        <input class="btn btn-outline-dark" id="MemberSignUpBtn" type="button" value="Sign Up" /></a>
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
