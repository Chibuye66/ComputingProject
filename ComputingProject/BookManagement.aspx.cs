using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputingProject
{
    public partial class BookManagement : System.Web.UI.Page
    {
        string connectionStrng = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        static string FilePathGlobal;

        static int StockGlobal, CrrntStckGlobal, IssuedBooksGlobal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                fillAuthorPublisherDetails();
               
            }

            BookInvtryListMgmntGrdView.DataBind();
        }

        protected void GoBookMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                getBookByID();
            }

            else
            {
                Response.Write("<script>alert('The Book ID you have entered does not exist, check it and try again.')</script>");
            }
        }

        protected void AddBookMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                Response.Write("<script>alert('This book already exists, please try again.')</script>");

            }

            else
            {
                addNewBook();

            }
        }

            protected void UpdateBookMgmtBtn_Click(object sender, EventArgs e)
            {

                if (checkBookExists())
                {
                    updateBook();
                }

                else
                {
                    Response.Write("<script>alert('The BookID you have entered does not exist.')</script>");
                }

            }

        protected void DeleteBookMgmtBtn_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                deleteBook();
            }

            else
            {
                Response.Write("<script>alert('Book information NOT deleted.')</script>");
            }
        }

        void fillAuthorPublisherDetails()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT AuthorName FROM Authors", dbconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DropDownAuthor.DataSource = dataTable;
                DropDownAuthor.DataValueField = "AuthorName";
                DropDownAuthor.DataBind();

                command = new SqlCommand("SELECT PublisherName FROM Publishers", dbconnection);
                dataAdapter = new SqlDataAdapter(command);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DropDownPublisher.DataSource = dataTable;
                DropDownPublisher.DataValueField = "PublisherName";
                DropDownPublisher.DataBind();

                dbconnection.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool checkBookExists()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Books WHERE BookID ='" + BookIDMgmtTxt.Text.Trim() + "' OR BookName='" + BookNameMgmtTxt.Text.Trim() + "'", dbconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    return true;
                }

                else
                {
                    return false;
                }

                dbconnection.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }


        void getBookByID()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM Books WHERE BookID ='" + BookIDMgmtTxt.Text.Trim() + "'", dbconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    BookNameMgmtTxt.Text = dataTable.Rows[0]["BookName"].ToString();
                    DropDownAuthor.SelectedValue = dataTable.Rows[0]["Author"].ToString();
                    DropDownPublisher.SelectedValue = dataTable.Rows[0]["Publisher"].ToString();
                    DropDownLanguage.SelectedValue = dataTable.Rows[0]["Language"].ToString();
                    PublishDateTxt.Text = dataTable.Rows[0]["DatePublished"].ToString();

                    ListBoxGenre.ClearSelection();

                    string[] genre = dataTable.Rows[0]["Genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBoxGenre.Items.Count; j++)
                        {
                            if (ListBoxGenre.Items[j].ToString() == genre[i])
                            {
                                ListBoxGenre.Items[j].Selected = true;
                            }

                        }
                    }


                    EditionTxt.Text = dataTable.Rows[0]["Edition"].ToString().Trim();
                    PageNumTxt.Text = dataTable.Rows[0]["PageCount"].ToString().Trim();
                    AllStockTxt.Text = dataTable.Rows[0]["Stock"].ToString().Trim();
                    CrrntStckTxt.Text = dataTable.Rows[0]["CurrentStock"].ToString().Trim();

                    NumIssuedBooksTxt.Text = "" + (Convert.ToInt32(dataTable.Rows[0]["Stock"].ToString().Trim()) - Convert.ToInt32(dataTable.Rows[0]["CurrentStock"].ToString().Trim()));

                    BookDescTxt.Text = dataTable.Rows[0]["BookDescription"].ToString();

                    StockGlobal = Convert.ToInt32(dataTable.Rows[0]["Stock"].ToString().Trim());
                    CrrntStckGlobal = Convert.ToInt32(dataTable.Rows[0]["CurrentStock"].ToString().Trim());
                    IssuedBooksGlobal = StockGlobal - CrrntStckGlobal;
                    FilePathGlobal = dataTable.Rows[0]["BookImage"].ToString();
                }

                else
                {
                    Response.Write("<script>alert('The Book ID you have entered does not exist, check it and try again.')</script>");
                }

                dbconnection.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void addNewBook()
        {
            try
            {

                string genre = "";

                foreach (int i in ListBoxGenre.GetSelectedIndices())
                {
                    genre = genre + ListBoxGenre.Items[i] + ",";
                }

                genre = genre.Remove(genre.Length - 1);

                string filepath = "~/BookImages/BooksIcon.jpg";
                string filename = Path.GetFileName(FileUploadBookMgmnt.PostedFile.FileName);
                FileUploadBookMgmnt.SaveAs(Server.MapPath("BookImages/" + filename));
                filepath = "~/BookImages/" + filename;



                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

                SqlCommand command = new SqlCommand("INSERT INTO Books VALUES (@BookName, @Author, @Publisher, @Language, @DatePublished, @Genre, @Edition, @PageCount, @Stock, @CurrentStock, @BookImage, @BookDesc)", dbconnection);

                command.Parameters.AddWithValue("@BookName", BookNameMgmtTxt.Text.Trim());
                command.Parameters.AddWithValue("@Author", DropDownAuthor.SelectedItem.Value);
                command.Parameters.AddWithValue("@Publisher", DropDownPublisher.SelectedItem.Value);
                command.Parameters.AddWithValue("@Language", DropDownLanguage.SelectedItem.Value);
                command.Parameters.AddWithValue("@DatePublished", PublishDateTxt.Text.Trim());
                command.Parameters.AddWithValue("@Edition", EditionTxt.Text.Trim());
                command.Parameters.AddWithValue("@PageCount", PageNumTxt.Text.Trim());
                command.Parameters.AddWithValue("@Stock", AllStockTxt.Text.Trim());
                command.Parameters.AddWithValue("@CurrentStock", AllStockTxt.Text.Trim());
                command.Parameters.AddWithValue("@BookDesc", BookDescTxt.Text.Trim());
                command.Parameters.AddWithValue("@Genre", genre);
                command.Parameters.AddWithValue("@BookImage", filepath);


                command.ExecuteNonQuery();


                dbconnection.Close();



                Response.Write("<script>alert('New Book Added.')</script>");

                BookInvtryListMgmntGrdView.DataBind();



                dbconnection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        void updateBook()
        {
            try
            {

                int stock = Convert.ToInt32(AllStockTxt.Text.Trim());
                int currentStock = Convert.ToInt32(CrrntStckTxt.Text.Trim());

                if (StockGlobal == stock)
                {

                }

                else
                {
                    if (stock < StockGlobal)
                    {
                        Response.Write("<script>alert('Sorry, the Stock value cannot be less than the Issued Books value.')</script>");
                        return;
                    }
                    else
                    {
                        currentStock = stock - IssuedBooksGlobal;
                        CrrntStckTxt.Text = "" + currentStock;
                    }
                }

                string genre ="";

                foreach (int i in ListBoxGenre.GetSelectedIndices())
                {
                    genre = genre + ListBoxGenre.Items[i] + ",";
                }

                genre = genre.Remove(genre.Length - 1);

                string filepath = "~/BookImages/BooksIcon.jpg";
                string filename = Path.GetFileName(FileUploadBookMgmnt.PostedFile.FileName);
                if (filename == "" || filename == null)
                {
                    filename = FilePathGlobal;
                }

                else
                {
                    FileUploadBookMgmnt.SaveAs(Server.MapPath("BookImages/" + filename));
                    filepath = "~/BookImages/" + filename;
                }

                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }


                SqlCommand command = new SqlCommand("UPDATE Books SET BookName = @Bookname, Author = @Author, Publisher = @Publisher, Language = @Language, DatePublished = @DatePublished, Genre = @Genre, Edition = @Edition, PageCount = @PageCount, Stock = @Stock, CurrentStock = @CurrentStock, BookImage = @BookImage, BookDescription = @BookDesc WHERE BookID = '" + BookIDMgmtTxt.Text.Trim() + "'", dbconnection);

                command.Parameters.AddWithValue("@BookName", BookNameMgmtTxt.Text.Trim());
                command.Parameters.AddWithValue("@Author", DropDownAuthor.SelectedItem.Value);
                command.Parameters.AddWithValue("@Publisher", DropDownPublisher.SelectedItem.Value);
                command.Parameters.AddWithValue("@Language", DropDownLanguage.SelectedItem.Value);
                command.Parameters.AddWithValue("@DatePublished", PublishDateTxt.Text.Trim());
                command.Parameters.AddWithValue("@Edition", EditionTxt.Text.Trim());
                command.Parameters.AddWithValue("@PageCount", PageNumTxt.Text.Trim());
                command.Parameters.AddWithValue("@Stock", stock.ToString());
                command.Parameters.AddWithValue("@CurrentStock", currentStock.ToString());
                command.Parameters.AddWithValue("@BookDesc", BookDescTxt.Text.Trim());
                
                command.Parameters.AddWithValue("@Genre", genre);
                command.Parameters.AddWithValue("@BookImage", filepath);

                command.ExecuteNonQuery();
                dbconnection.Close();

                BookInvtryListMgmntGrdView.DataBind();

                Response.Write("<script>alert('Book information updated successfully.')</script>");

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        void deleteBook()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(connectionStrng);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }


                SqlCommand command = new SqlCommand("DELETE FROM Books WHERE BookID = '" + BookIDMgmtTxt.Text.Trim() + "'", dbconnection);

                command.ExecuteNonQuery();
                dbconnection.Close();

                Response.Write("<script>alert('Book information deleted successfully.')</script>");

                clearForm();

                BookInvtryListMgmntGrdView.DataBind();


                dbconnection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }



        void clearForm()
        {

            BookIDMgmtTxt.Text = "";
            BookNameMgmtTxt.Text = "";
            PublishDateTxt.Text = "";
            EditionTxt.Text = "";
            PageNumTxt.Text = "";
            AllStockTxt.Text = "";
            CrrntStckTxt.Text = "";
            NumIssuedBooksTxt.Text = "";
            BookDescTxt.Text = "";

        }
    }
}