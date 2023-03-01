
<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="PublisherManagement.aspx.cs" Inherits="ComputingProject.PublisherManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            
        }
            )
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    
    <div class="container">
        <div class="row">

            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="Images/PublisherIcon.jpg" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                         <div class="row">

                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox class="form-control" ID="PublisherIDMgmtTxt" runat="server" placeholder="PublisherID">
                                    </asp:TextBox>

                                    <asp:Button class="btn btn-outline-secondary" ID="GoPublisherMgmtBtn" runat="server" Text="Go" OnClick="GoPublisherMgmtBtn_Click" />
                                        </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />


                            <div class="col-md-8">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="PublisherNameMgmtTxt" runat="server" placeholder="Publisher Name">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-4 form-group d-grid gap-2">
                                <asp:Button CssClass="btn btn-block btn-outline-dark" ID="AddPublisherMgmtBtn" runat="server" Text="Add" OnClick="AddPublisherMgmtBtn_Click" />
                            </div>

                            <div class="col-4 form-group d-grid gap-2">
                                <asp:Button CssClass="btn btn-block btn-outline-dark" ID="UpdatePublisherMgmtBtn" runat="server" Text="Update" OnClick="UpdatePublisherMgmtBtn_Click" />
                            </div>

                            <div class="col-4 form-group d-grid gap-2">
                                <asp:Button CssClass="btn btn-block btn-outline-dark" ID="DeletePublisherMgmtBtn" runat="server" Text="Delete" OnClick="DeletePublisherMgmtBtn_Click" />
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
                                    <h4>List of Publishers</h4>
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
                                <asp:GridView class="table table-striped table-bordered dt-responsive" ID="PublisherListMgmntGrdView" runat="server" AutoGenerateColumns="False" DataKeyNames="PublisherID" DataSourceID="SqlDataSourcePublishers">
                                    <Columns>
                                        <asp:BoundField DataField="PublisherID" HeaderText="PublisherID" InsertVisible="False" ReadOnly="True" SortExpression="PublisherID" />
                                        <asp:BoundField DataField="PublisherName" HeaderText="PublisherName" SortExpression="PublisherName" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourcePublishers" runat="server" ConnectionString="<%$ ConnectionStrings:EvergreenDBConnectionString %>" SelectCommand="SELECT * FROM [Publishers]"></asp:SqlDataSource>
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
