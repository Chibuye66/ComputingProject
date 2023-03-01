<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="AuthorManagement.aspx.cs" Inherits="ComputingProject.AuthorManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

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
                                    <img width="150" src="Images/AuthorIcon.jpg" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>
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
                                    <asp:TextBox class="form-control" ID="AuthorIDMgmtTxt" runat="server" placeholder="AuthorID">
                                    </asp:TextBox>

                                    <asp:Button class="btn btn-outline-secondary" ID="GoAuthorMgmtBtn" runat="server" Text="Go" OnClick="GoAuthorMgmtBtn_Click" />
                                        </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />


                            <div class="col-md-8">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="AuthorNameMgmtTxt" runat="server" placeholder="Author Name">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-4 form-group d-grid gap-2">
                                <asp:Button CssClass="btn btn-block btn-outline-dark" ID="AddAuthorMgmtBtn" runat="server" Text="Add" OnClick="AddAuthorMgmtBtn_Click" />
                            </div>

                            <div class="col-4 form-group d-grid gap-2">
                                <asp:Button CssClass="btn btn-block btn-outline-dark" ID="UpdateAuthorMgmtBtn" runat="server" Text="Update" OnClick="UpdateAuthorMgmtBtn_Click" />
                            </div>

                            <div class="col-4 form-group d-grid gap-2">
                                <asp:Button CssClass="btn btn-block btn-outline-dark" ID="DeleteAuthorMgmtBtn" runat="server" Text="Delete" OnClick="DeleteAuthorMgmtBtn_Click" />
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
                                    <h4>List of Authors</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>


                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSourceAuthors" runat="server" ConnectionString="<%$ ConnectionStrings:EvergreenDBConnectionString %>" OnSelecting="SqlDataSourceAuthors_Selecting" SelectCommand="SELECT * FROM [Authors]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped dt-responsive" ID="AuthorListMgmtGrdView" runat="server" AutoGenerateColumns="False" DataKeyNames="AuthorID" DataSourceID="SqlDataSourceAuthors" OnRowDataBound="AuthorListMgmtGrdView_RowDataBound" AllowPaging="true" OnPageIndexChanging="AuthorListMgmtGrdView_PageIndexChanging">
                                    <PagerSettings Mode="Numeric" Position="Bottom" PageButtonCount="10" />
                                    <pagerstyle BackColor="LightBlue" Height="30" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="AuthorID" HeaderText="AuthorID" InsertVisible="False" ReadOnly="True" SortExpression="AuthorID" />
                                        <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                                    </Columns>
                                </asp:GridView>
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
