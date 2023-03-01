<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="CirculationManagement.aspx.cs" Inherits="ComputingProject.CirculationManagement" %>

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
                                    <img width="200"  src="Images/BookIssuance.jpg" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuance</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                         <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    
                                    <asp:TextBox class="form-control" ID="MemberIDCirclationMgmtTxt" runat="server" placeholder="MemberID">
                                    </asp:TextBox>

                                    
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />


                            <div class="col-md-6">
                                <div class="form-group"> 
                                    <div class="input-group">
                                    <asp:TextBox class="form-control" ID="BookIDCirculationMgmtTxt" runat="server" placeholder="BookID">
                                    </asp:TextBox>

                                    <asp:Button class="btn btn-outline-secondary" ID="GoCirculationgmtBtn" runat="server" Text="Go" OnClick="GoCirculationgmtBtn_Click" />
                                        </div>
                                  
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="MemberNameCirculationMgmtTxt" runat="server" placeholder="Member's Name" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="BookNameCirculationMgmtTxt" runat="server" placeholder="Book Name" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <br />
                    

                        <div class="row">
                            <div class="col-md-6">
                                <label>Issue Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="IssueDateCirculationMgmntTxt" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>   
                            
                            <div class="col-md-6">
                                <label>Return Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ReturnDateCirculationMgmntTxt" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div> 

                        </div>

                        <br />
                        <br />

                        <div class="row">

                            <div class="col-6 form-group d-grid gap-2">
                                <asp:Button CssClass="btn btn-block btn-outline-dark" ID="IssueBookMgmtBtn" runat="server" Text="Issue" OnClick="IssueBookMgmtBtn_Click" />
                            </div>

                            <div class="col-6 form-group d-grid gap-2">
                                <asp:Button CssClass="btn btn-block btn-outline-secondary" ID="ReturnBookMgmtBtn" runat="server" Text="Return" OnClick="ReturnBookMgmtBtn_Click" />
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
                                    <h4>List of Issued Books</h4>
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
                                <asp:GridView class="table table-striped" ID="IssuedBooksGrdView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceIssues" OnRowDataBound="IssuedBooksGrdView_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="Member_ID" HeaderText="MemberID" SortExpression="Member_ID" />
                                         <asp:BoundField DataField="Book_ID" HeaderText="BookID" SortExpression="Book_ID" />
                                        <asp:BoundField DataField="MembersName" HeaderText="Member's Name" SortExpression="MembersName" />
                                        <asp:BoundField DataField="BooksName" HeaderText="Book Name" SortExpression="BooksName" />
                                        <asp:BoundField DataField="IssueDate" HeaderText="Date Issued" SortExpression="IssueDate" DataFormatString ="{0:dd MMMM, yyyy}"/>
                                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="DueDate" DataFormatString ="{0:dd MMMM, yyyy}"/>
                                       
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceIssues" runat="server" ConnectionString="<%$ ConnectionStrings:EvergreenDBConnectionString %>" SelectCommand="SELECT * FROM [BookIssues]"></asp:SqlDataSource>
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
