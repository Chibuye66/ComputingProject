<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="AdministratorMemberManagement.aspx.cs" Inherits="ComputingProject.AdministratorMemberManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
<link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css" />
<script
  src="https://code.jquery.com/jquery-3.6.0.js"
  integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk="
  crossorigin="anonymous"></script>

    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%= AdminMemberListMgmtGrdView.ClientID %>').DataTable();
    });
    </script>

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
                                    <h4>Member's Information</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="AdminMemberIDTxt" runat="server" placeholder="MemberID">
                                        </asp:TextBox>
                                        <asp:Button class="btn btn-outline-secondary" ID="AdminMemberIdGoBtn" runat="server" Text="Go" OnClick="AdminMemberIdGoBtn_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="AdminMemberAcctSttusTxt" runat="server" placeholder="Account Status" ReadOnly="true"></asp:TextBox>

                                        <asp:LinkButton Title="Activate Member's Account" CssClass="btn btn-outline-secondary" ID="ActiveAcctAdminBtn" runat="server" OnClick="ActiveAcctAdminBtn_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>

                                        <asp:LinkButton Title="Put Member's Account on Hold" CssClass="btn btn-outline-secondary" ID="PendAcctAdminBtn" runat="server" OnClick="PendAcctAdminBtn_Click"><i class="fa-regular fa-pause-circle"></i></asp:LinkButton>

                                        <asp:LinkButton Title="Deactivate Member's Account" CssClass="btn btn-outline-secondary" ID="DeactivateAdminBtn" runat="server" OnClick="DeactivateAdminBtn_Click"><i class="fa-regular fa-times-circle"></i></asp:LinkButton>
                                      
                                       
                                    </div>
                                </div>
                            </div>
                        </div>


                        <br />
                        <br />


                        <div class="row">
                            <div class="col">
                                <h5>Personal Information</h5>
                            </div>
                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="FirstNameProfileTxt" runat="server" placeholder="First Name" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />


                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="LastNameProfileTxt" runat="server" placeholder="Last Name" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="CurrentAddressProfileTxt" runat="server" placeholder="Current Address" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="CityProfileTxt" runat="server" placeholder="City" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="PassNRCProfileTxt" runat="server" placeholder="NRC/Passport Number" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="EmailProfileTxt" runat="server" placeholder="Email Address" ReadOnly="true">
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
                                    <asp:TextBox CssClass="form-control" ID="ChurchProfileTxt" runat="server" placeholder="Church" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChurchLocationProfileTxt" runat="server" placeholder="Church Location" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ChurchEmailProfileTxt" runat="server" placeholder="Church Email" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ChurchCityAdminMemberTxt" runat="server" placeholder="City" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="AdminMmbrMgmntChrchPosition" runat="server" placeholder="Position at Church" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ChurchStateAdminMemberTxt" runat="server" placeholder="State" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="RecomAdminMmbrMgmtTxt" runat="server" placeholder="Recommender's Name" ReadOnly="true"></asp:TextBox>
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
                                <h5>Children's Membership Privileges</h5>
                            </div>
                        </div>
                        <br />



                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenProfileTxt1" runat="server" placeholder="Name" ReadOnly="true"> 
                                    </asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenProfileTxt2" runat="server" placeholder="Name" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <br />

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenProfileTxt3" runat="server" placeholder="Name" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenProfileTxt4" runat="server" placeholder="Name" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />
                        <br />

                        <div class="row">
                            <div class="form-group d-grid gap-2">
                                <asp:Button CssClass="btn btn-block btn-outline-dark" ID="DeleteMemberBtn" runat="server" Text="Delete Member Permanently" OnClick="DeleteMemberBtn_Click" />
                            </div>
                        </div>


                    </div>
                </div>
            </div>


            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>List of Members</h4>
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
                                <asp:GridView class="table table-striped table-bordered table-responsive" ID="AdminMemberListMgmtGrdView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceProfileMgmt" OnRowDataBound="AdminMemberListMgmtGrdView_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="MemberID" HeaderText="MemberID" InsertVisible="False" ReadOnly="True" SortExpression="MemberID" />
                                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                                        <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
                                        <asp:BoundField DataField="Church" HeaderText="Church" SortExpression="Church" />
                                        <asp:BoundField DataField="AccountState" HeaderText="AccountState" SortExpression="AccountState" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceProfileMgmt" runat="server" ConnectionString="<%$ ConnectionStrings:EvergreenDBConnectionString %>" SelectCommand="SELECT [MemberID], [FirstName], [LastName], [City], [EmailAddress], [Church], [AccountState] FROM [Members]"></asp:SqlDataSource>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

        <br />
        <a href="Home.aspx"><< Home</a>
    </div>

</asp:Content>
