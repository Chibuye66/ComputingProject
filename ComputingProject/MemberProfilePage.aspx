<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="MemberProfilePage.aspx.cs" Inherits="ComputingProject.MemberProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
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
                                    <h3>Your Profile</h3>
                                    <span>Account Status - </span>
                                    <asp:Label class="badge rounded-pill bg-success" ID="AccountStatusLbl" runat="server"></asp:Label>

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
                                <h5>Personal Information</h5>
                            </div>
                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="FirstNameProfileTxt" runat="server" placeholder="First Name">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />


                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="LastNameProfileTxt" runat="server" placeholder="Last Name">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="CurrentAddressProfileTxt" runat="server" placeholder="Current Address">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="CityProfileTxt" runat="server" placeholder="City">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="PassNRCProfileTxt" runat="server" placeholder="NRC/Passport Number">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="EmailProfileTxt" runat="server" placeholder="Email Address">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>


                        <br />

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="employmentStatusProfileTxt" runat="server" placeholder="Employment Status">
                                    </asp:TextBox>
                                </div>
                            </div>
                            </div>
                        <br />

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h5>Church Affiliation</h5>
                            </div>
                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChurchProfileTxt" runat="server" placeholder="Church">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChurchLocationProfileTxt" runat="server" placeholder="Church Location">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ChurchEmailProfileTxt" runat="server" placeholder="Church Email">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ChurchCityProfileTxt" runat="server" placeholder="City">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">

                                    <asp:DropDownList class="form-control" ID="ChurchPositionProfileDrpDwn" runat="server">
                                        <asp:ListItem Text="Position at Church" Value="Position at Church"></asp:ListItem>
                                        <asp:ListItem Text="Pastor" Value="Pastor"></asp:ListItem>
                                        <asp:ListItem Text="Elder" Value="Elder"></asp:ListItem>
                                        <asp:ListItem Text="Deacon" Value="Deacon"></asp:ListItem>
                                        <asp:ListItem Text="Ordinary Church Member" Value="Ordinary Church Member"></asp:ListItem>

                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ChurchStateProfileTxt" runat="server" placeholder="State/Province">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />


                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <h5>Children's Membership Privileges</h5>
                            </div>
                        </div>
                        <br />



                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenProfileTxt1" runat="server" placeholder="Name">
                                    </asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenProfileTxt2" runat="server" placeholder="Name">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <br />

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenProfileTxt3" runat="server" placeholder="Name">
                                    </asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenProfileTxt4" runat="server" placeholder="Name">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <h5>Password Modification</h5>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="oldPassProfileTxt" runat="server" placeholder="Current Password" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="newPassProfileTxt" runat="server" placeholder="New Password">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">

                                <br />
                                <br />

                                <div class="form-group d-grid gap-2">
                                    <asp:Button class="btn btn-outline-secondary btn-block" ID="MemberProfileUpdateBtn" runat="server" Text="Update Profile" OnClick="MemberProfileUpdateBtn_Click" />
                                </div>

                                <br />


                            </div>
                        </div>

                        <br />

                    </div>
                </div>

                <br />

                <a href="Home.aspx"><< Home</a>
            </div>


            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="250" src="Images/BooksIcon.jpg" />
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Issued Books</h3>
                                  <span>Your Book Information.</span>
                                    <br />
                                    <asp:Label class="badge rounded-pill bg-light text-dark" ID="BookInfoTagLbl" runat="server" Text=""></asp:Label>

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
                                <asp:GridView class="table table-striped" ID="IssuedBooksProfileGrdView" runat="server" OnRowDataBound="IssuedBooksProfileGrdView_RowDataBound" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Member_ID" HeaderText="Member ID" SortExpression="Member_ID" />
<asp:BoundField DataField="Book_ID" HeaderText="Book ID" SortExpression="Book_ID" />
                                        <asp:BoundField DataField="MembersName" HeaderText="Member Name" SortExpression="MembersName" />
                                        <asp:BoundField DataField="BooksName" HeaderText="Book Name" SortExpression="BooksName" />
                                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" SortExpression="IssueDate" DataFormatString = "{0:dd MMMM, yyyy}" />
                                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="DueDate" DataFormatString = "{0:dd MMMM, yyyy}"/>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
                </div>
            </div>
       
        </div>
</asp:Content>
