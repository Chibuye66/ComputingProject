<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="Catalogue.aspx.cs" Inherits="ComputingProject.Catalogue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Evergreen Library Catalogue</h4>
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
                                <asp:GridView class="table table-striped" ID="BookInvtryListMgmntGrdView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceCatalogue">
                                    <Columns>
                                        <asp:BoundField DataField="BookID" HeaderText="BookID" InsertVisible="False" ReadOnly="True" SortExpression="BookID" />
                                         <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="dataGridBookName" runat="server" Text='<%# Eval("BookName") %>' Font-Size="Large" Font-Bold="True"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Author - <asp:Label ID="dataGridAuthor" runat="server" Text='<%# Eval("Author") %>' Font-Bold="True"></asp:Label> | Genre - <asp:Label ID="Label1" runat="server" Text='<%# Eval("Genre") %>' Font-Bold="True"></asp:Label> | Language - <asp:Label ID="Label2" runat="server" Text='<%# Eval("Language") %>' Font-Bold="True"></asp:Label>
                                                                     

                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publisher - <asp:Label ID="dataGridPublisher" runat="server" Text='<%# Eval("Publisher") %>' Font-Bold="True"></asp:Label> | Date Published - <asp:Label ID="dataGridDatePublished" runat="server" Text='<%# Eval("DatePublished", "{0:d MMM yyyy}") %>' Font-Bold="True"></asp:Label> | Page Count - <asp:Label ID="dataGridPageCount" runat="server" Text='<%# Eval("PageCount") %>' Font-Bold="True"></asp:Label> | Edition - <asp:Label ID="dataGridEdition" runat="server" Text='<%# Eval("Edition") %>' Font-Bold="True"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Stock - <asp:Label ID="dataGridStock" runat="server" Text='<%# Eval("Stock") %>' Font-Bold="True"></asp:Label> | Available - <asp:Label ID="dataGridCurrentStock" runat="server" Text='<%# Eval("CurrentStock") %>' Font-Bold="True"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Description - <asp:Label ID="dataGridDesc" runat="server" Text='<%# Eval("BookDescription") %>' Font-Bold="True" Font-Size="Small" Font-Italic="True"></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image CssClass="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("BookImage") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceCatalogue" runat="server" ConnectionString="<%$ ConnectionStrings:EvergreenDBConnectionString %>" SelectCommand="SELECT * FROM [Books]"></asp:SqlDataSource>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
