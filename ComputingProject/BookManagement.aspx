<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="BookManagement.aspx.cs" Inherits="ComputingProject.BookManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
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
                                    <img id="imgview" width="200" src="Images/BooksIcon.jpg" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Details</h4>
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
                                        <asp:TextBox class="form-control" ID="BookIDMgmtTxt" runat="server" placeholder="BookID">
                                        </asp:TextBox>

                                        <asp:Button class="btn btn-outline-secondary" ID="GoBookMgmtBtn" runat="server" Text="Go" OnClick="GoBookMgmtBtn_Click" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />

                            <div class="col-md-8">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="BookNameMgmtTxt" runat="server" placeholder="Book Name">
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
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownLanguage" runat="server">

                                        <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                        <asp:ListItem Text="Cinyanja" Value="Cinyanja"></asp:ListItem>
                                        <asp:ListItem Text="Icibemba" Value="Icibemba"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Author</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownAuthor" runat="server">

                                        <asp:ListItem Text="Author" Value="Author"></asp:ListItem>
                                        <asp:ListItem Text="Author1" Value="Author1"></asp:ListItem>
                                        <asp:ListItem Text="Author2" Value="Author2"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>Publisher</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownPublisher" runat="server">

                                        <asp:ListItem Text="Publisher" Value="Publisher"></asp:ListItem>
                                        <asp:ListItem Text="Publsher1" Value="Publsher1"></asp:ListItem>
                                        <asp:ListItem Text="Publsher2" Value="Publsher2"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <br />
                                <label>Date Published</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="PublishDateTxt" runat="server" placeholder="Date Published" TextMode="Date">
                                    </asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-8">
                                <br />
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" ID="ListBoxGenre" runat="server" SelectionMode="Multiple" Rows="3">
                                        <asp:ListItem Text="Epistle" Value="Epistle"></asp:ListItem>
                                        <asp:ListItem Text="Prophecy" Value="Prophecy"></asp:ListItem>
                                        <asp:ListItem Text="Sermon" Value="Sermon"></asp:ListItem>
                                        <asp:ListItem Text="Apocalyptic" Value="Apocalyptic"></asp:ListItem>
                                        <asp:ListItem Text="Christian Science Fiction" Value="Christian Science Fiction"></asp:ListItem>
                                        <asp:ListItem Text="Parable" Value="Parable"></asp:ListItem>
                                        <asp:ListItem Text="Self Help" Value="Self Help"></asp:ListItem>
                                        <asp:ListItem Text="Time Management" Value="Time Management"></asp:ListItem>
                                        <asp:ListItem Text="Self Management" Value="Self Management"></asp:ListItem>
                                    </asp:ListBox>

                                    <br />
                                </div>
                            </div>


                            <div class="row">
                                <div class="col">
                                    <hr />
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-md-4">
                                    <br />
                                    <label>Edition</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="EditionTxt" runat="server" placeholder="Edition">
                                        </asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <br />
                                    <label>Number of Pages</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="PageNumTxt" runat="server" placeholder="Number of Pages" TextMode="Number">
                                        </asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <br />
                                    <label>Stock</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="AllStockTxt" runat="server" placeholder="10" TextMode="Number">
                                        </asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <br />
                                    <label>Current Stock</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="CrrntStckTxt" runat="server" placeholder="0" TextMode="Number" ReadOnly="true">
                                        </asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <br />
                                    <label>Number of Issued Books</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="NumIssuedBooksTxt" runat="server" placeholder="0" TextMode="Number" ReadOnly="true">
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
                                <div class="col-md-12">
                                    <label>Description of Book</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="BookDescTxt" runat="server" placeholder="To the two friends, the treehouse was much more than a treehouse. It was a sanctuary away from the other kids where they could be themselves without being teased or bullied. It was their secret fortress hidden high in the branches of a huge oak that only they knew existed." Rows="4" TextMode="MultiLine">
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
                                    <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="FileUploadBookMgmnt" runat="server" />
                                </div>
                            </div>

                            <br />
                            <br />
                            <br />

                            <div class="row">

                                <div class="col-4 form-group d-grid gap-2">
                                    <asp:Button CssClass="btn btn-block btn-outline-dark" ID="AddBookMgmtBtn" runat="server" Text="Add" OnClick="AddBookMgmtBtn_Click" />
                                </div>

                                <div class="col-4 form-group d-grid gap-2">
                                    <asp:Button CssClass="btn btn-block btn-outline-dark" ID="UpdateBookMgmtBtn" runat="server" Text="Update" OnClick="UpdateBookMgmtBtn_Click" />
                                </div>

                                <div class="col-4 form-group d-grid gap-2">
                                    <asp:Button CssClass="btn btn-block btn-outline-dark" ID="DeleteBookMgmtBtn" runat="server" Text="Delete" OnClick="DeleteBookMgmtBtn_Click" />
                                </div>

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
                                    <h4>Book Inventory List</h4>
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
                                <asp:GridView class="table table-striped" ID="BookInvtryListMgmntGrdView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceAdminBooks">
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
                                                                    Publisher - <asp:Label ID="dataGridPublisher" runat="server" Text='<%# Eval("Publisher") %>' Font-Bold="True"></asp:Label> | Date Published - <asp:Label ID="dataGridDatePublished" runat="server" Text='<%# Eval("DatePublished", "{0:dd MMMM, yyyy}") %>' Font-Bold="True"></asp:Label> | Page Count - <asp:Label ID="dataGridPageCount" runat="server" Text='<%# Eval("PageCount") %>' Font-Bold="True"></asp:Label> | Edition - <asp:Label ID="dataGridEdition" runat="server" Text='<%# Eval("Edition") %>' Font-Bold="True"></asp:Label>
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
                                <asp:SqlDataSource ID="SqlDataSourceAdminBooks" runat="server" ConnectionString="<%$ ConnectionStrings:EvergreenDBConnectionString %>" SelectCommand="SELECT [BookID], [BookName], [Author], [Publisher], [Genre], [Stock], [Edition], [Language], [BookImage], [DatePublished], [BookDescription], [PageCount], [CurrentStock] FROM [Books]"></asp:SqlDataSource>
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
