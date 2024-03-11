using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace QLThuVienSachCaNhan_1911211
{
    public partial class QLThuVien : Form
    {
        List<Publisher> publisherList = new List<Publisher>();
        List<Book> booksList = new List<Book>();
        List<Author> authorList = new List<Author>();
        List<Category> categoryList = new List<Category>();

        List<string> bookType = new List<string>();

        Book selectedBook = new Book();

        public QLThuVien()
        {
            InitializeComponent();
        }

        private void QLThuVien_Load(object sender, EventArgs e)
        {
            LoadPublisher();
            LoadAuthor();
            LoadCategory();
            LoadBook(lvBook);
        }

        // Utils

        private int GetBookType()
        {
            return rbSingleVolume.Checked ? 0 : 1;
        }

        // Load funcs

        private void LoadPublisher()
        {
            PublisherBL publisherBL = new PublisherBL();
            publisherList = publisherBL.GetAll();

            cbPublisher.DataSource = publisherList;
            cbPublisher.DisplayMember = "TenNhaXuatBan";
            cbPublisher.ValueMember = "ID";
            cbPublisher.Text = null;
        }

        private void LoadAuthor()
        {
            AuthorBL authorBL = new AuthorBL();
            authorList = authorBL.GetAll();

            cbAuthor.DataSource = authorList;
            cbAuthor.DisplayMember = "TenTacGia";
            cbAuthor.ValueMember = "ID";
            cbAuthor.Text = null;
        }

        private void LoadCategory()
        {
            CategoryBL categoryBL = new CategoryBL();
            categoryList = categoryBL.GetAll();

            cbCategory.DataSource = categoryList;
            cbCategory.DisplayMember = "TenTheLoai";
            cbCategory.ValueMember = "ID";
            cbCategory.Text = null;
        }

        public void LoadBook(ListView bookListView)
        {
            BookBL bookBL = new BookBL();
            booksList = bookBL.GetAll();

            int count = 1;
            bookListView.Items.Clear();

            foreach (var book in booksList)
            {
                ListViewItem item = bookListView.Items.Add(count.ToString());
                item.SubItems.Add(book.TenSach);
                string type;
                if (book.LoaiSach == 0)
                    type = "Sách đơn";
                else type = "Sách bộ";
                item.SubItems.Add(type);
                string status;
                if (book.TenTrangThai == 0)
                    status = "Lưu trữ";
                else if (book.TenTrangThai == 1)
                    status = "Cho mượn";
                else status = "Sách mượn";
                item.SubItems.Add(status);
                string categoryName = categoryList.Find(x => x.ID == book.ID_TheLoai).TenTheLoai;
                item.SubItems.Add(categoryName);
                string authorName = (book.ID_TacGia != null) ? authorList.Find(x => x.ID == book.ID_TacGia).TenTacGia : null;
                item.SubItems.Add(authorName);
                string publisherName = (book.ID_NhaXuatBan != null) ? publisherList.Find(x => x.ID == book.ID_NhaXuatBan).TenNhaXuatBan : null;
                item.SubItems.Add(publisherName);
                item.SubItems.Add(book.NamXuatBan);
                item.SubItems.Add(book.ViTri);
                item.SubItems.Add(book.GhiChu);
                count++;
            }
        }

        // Add funcs

        //public string ThemTheLoai()
        //{
        //    try
        //    {
        //        string categoryID = "";

        //        SqlConnection conn = new SqlConnection(Utilities.ConnectionString);

        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "EXECUTE InsertCategory @id OUTPUT, @tenTheLoai";

        //        cmd.Parameters.Add("@id", SqlDbType.Int);
        //        cmd.Parameters.Add("@tenTheLoai", SqlDbType.NVarChar, 50);

        //        cmd.Parameters["@id"].Direction = ParameterDirection.Output;

        //        cmd.Parameters["@tenTheLoai"].Value = cbCategory.Text;

        //        conn.Open();

        //        int numRowAffected = cmd.ExecuteNonQuery();

        //        if (numRowAffected > 0)
        //        {
        //            categoryID = cmd.Parameters["@id"].Value.ToString();
        //            MessageBox.Show($"Đã thêm thể loại mới. ID = {categoryID}");
        //            this.ResetText();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không thể thêm thể loại.");
        //        }

        //        conn.Close();
        //        conn.Dispose();

        //        return categoryID;
        //    }
        //    catch (SqlException ex)
        //    {
        //        return ex.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //public string ThemTacGia()
        //{
        //    try
        //    {
        //        string authorID = "";

        //        SqlConnection conn = new SqlConnection(Utilities.ConnectionString);

        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "EXECUTE InsertAuthor @id OUTPUT, @tenTacGia";

        //        cmd.Parameters.Add("@id", SqlDbType.Int);
        //        cmd.Parameters.Add("@tenTacGia", SqlDbType.NVarChar, 50);

        //        cmd.Parameters["@id"].Direction = ParameterDirection.Output;

        //        cmd.Parameters["@tenTacGia"].Value = cbAuthor.Text;

        //        conn.Open();

        //        int numRowAffected = cmd.ExecuteNonQuery();

        //        if (numRowAffected > 0)
        //        {
        //            authorID = cmd.Parameters["@id"].Value.ToString();
        //            MessageBox.Show($"Đã thêm tác giả mới. ID = {authorID}");
        //            this.ResetText();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không thể thêm tác giả.");
        //        }

        //        conn.Close();
        //        conn.Dispose();

        //        return authorID;
        //    }
        //    catch (SqlException ex)
        //    {
        //        return ex.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        public int InsertMinorProperty(int property)
        {
            // 0 = Category; 1 = Author; 2 = Publisher

            switch (property)
            {
                case 0: // Category
                    Category newCategory = new Category();
                    newCategory.ID = 0;
                    newCategory.TenTheLoai = cbCategory.Text;
                    CategoryBL category = new CategoryBL();
                    return category.Insert(newCategory);
                case 1: // Author
                    Author newAuthor = new Author();
                    newAuthor.ID = 0;
                    newAuthor.TenTacGia = cbAuthor.Text;
                    AuthorBL authorBL = new AuthorBL();
                    return authorBL.Insert(newAuthor);
                case 2: // Publisher
                    Publisher newPublisher = new Publisher();
                    newPublisher.ID = 0;
                    newPublisher.TenNhaXuatBan = cbPublisher.Text;
                    PublisherBL publisherBL = new PublisherBL();
                    return publisherBL.Insert(newPublisher);
            }
            return -1;
        }

        public int InsertBook()
        {
            Book newBook = new Book();
            newBook.ID = 0;
            if (cbCategory.Text == "" || tbBookName.Text == "" || (!rbSingleVolume.Checked && !rbSeries.Checked))
                MessageBox.Show("Chưa nhập dữ liệu vài ô cần thiết. Vui lòng nhập lại");
            else
            {
                newBook.LoaiSach = GetBookType();
                newBook.TenSach = tbBookName.Text;
                newBook.NamXuatBan = mtbPublishedYear.Text;
                newBook.ViTri = tbLocation.Text;
                newBook.GhiChu = tbNotes.Text;
                newBook.TenTrangThai = 0;
                if (cbCategory.SelectedValue != null)
                    newBook.ID_TheLoai = Convert.ToInt32(cbCategory.SelectedValue);
                else
                {
                    int result = InsertMinorProperty(0);
                    if (result > 0)
                    {
                        MessageBox.Show($"Đã thêm thể loại, ID = {result}");
                        newBook.ID_TheLoai = result;
                        LoadCategory();
                    }
                    else MessageBox.Show("Không thể thêm thể loại");
                }
                if (cbAuthor.SelectedValue != null)
                    newBook.ID_TacGia = Convert.ToInt32(cbAuthor.SelectedValue);
                else if (cbAuthor.Text != "")
                {
                    int result = InsertMinorProperty(1);
                    if (result > 0)
                    {
                        MessageBox.Show($"Đã thêm tác giả, ID = {result}");
                        newBook.ID_TacGia = result;
                        LoadAuthor();
                    }
                    else MessageBox.Show("Không thể thêm tác giả");
                }
                else newBook.ID_TacGia = null;
                if (cbPublisher.SelectedValue != null)
                    newBook.ID_NhaXuatBan = Convert.ToInt32(cbPublisher.SelectedValue);
                else if (cbPublisher.Text != "")
                {
                    int result = InsertMinorProperty(2);
                    if (result > 0)
                    {
                        MessageBox.Show($"Đã thêm nhà xuất bản, ID = {result}");
                        newBook.ID_NhaXuatBan = result;
                        LoadPublisher();
                    }
                    else MessageBox.Show("Không thể thêm nhà xuất bản");
                }
                else newBook.ID_NhaXuatBan = null;
                BookBL bookBL = new BookBL();
                return bookBL.Insert(newBook);
            }
            return -1;
        }

        // Events

        //private void bAddBook_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(Utilities.ConnectionString);

        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "EXECUTE InsertBook @id OUTPUT, @loaiSach, @id_theLoai, @tenSach, @id_tacGia, " +
        //            "@namXuatBan, @id_nhaXuatBan, @viTri, @tenTrangThai, @ghiChu";

        //        cmd.Parameters.Add("@id", SqlDbType.Int);
        //        cmd.Parameters.Add("@loaiSach", SqlDbType.Int);
        //        cmd.Parameters.Add("@id_theLoai", SqlDbType.Int);
        //        cmd.Parameters.Add("@tenSach", SqlDbType.NVarChar, 100);
        //        cmd.Parameters.Add("@id_tacGia", SqlDbType.Int);
        //        cmd.Parameters.Add("@namXuatBan", SqlDbType.NChar, 4);
        //        cmd.Parameters.Add("@id_nhaXuatBan", SqlDbType.Int);
        //        cmd.Parameters.Add("@viTri", SqlDbType.NVarChar, 50);
        //        cmd.Parameters.Add("@tenTrangThai", SqlDbType.SmallInt);
        //        cmd.Parameters.Add("@ghiChu", SqlDbType.NText);

        //        cmd.Parameters["@id"].Direction = ParameterDirection.Output;

        //        cmd.Parameters["@loaiSach"].Value = rbSingleVolume.Checked ? 0 : 1;

        //        if (cbCategory.SelectedValue != null)
        //            cmd.Parameters["@id_theLoai"].Value = cbCategory.SelectedValue;
        //        else
        //        {
        //            string theLoai = ThemTheLoai();
        //            if (theLoai.All(char.IsDigit))
        //                cmd.Parameters["@id_theLoai"].Value = Convert.ToInt32(theLoai);
        //            else MessageBox.Show(theLoai, "Error");
        //        }

        //        cmd.Parameters["@tenSach"].Value = tbBookName.Text;

        //        if (cbAuthor.SelectedValue != null)
        //            cmd.Parameters["@id_tacGia"].Value = cbAuthor.SelectedValue;
        //        else
        //        {
        //            string tacGia = ThemTacGia();
        //            if (tacGia.All(char.IsDigit))
        //                cmd.Parameters["@id_tacGia"].Value = Convert.ToInt32(tacGia);
        //            else MessageBox.Show(tacGia, "Error");
        //        }

        //        cmd.Parameters["@namXuatBan"].Value = mtbPublishedYear.Text;
        //        cmd.Parameters["@id_nhaXuatBan"].Value = cbPublisher.SelectedValue;
        //        cmd.Parameters["@viTri"].Value = tbLocation.Text;
        //        cmd.Parameters["@tenTrangThai"].Value = 0;
        //        cmd.Parameters["@ghiChu"].Value = tbNotes.Text;

        //        conn.Open();

        //        int numRowAffected = cmd.ExecuteNonQuery();

        //        if (numRowAffected > 0)
        //        {
        //            string bookID = cmd.Parameters["@id"].Value.ToString();
        //            MessageBox.Show($"Đã thêm sách/bộ sách mới. ID = {bookID}");
        //            this.ResetText();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không thể thêm sách.");
        //        }

        //        conn.Close();
        //        conn.Dispose();

        //        TaiTatCaSach();
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message, "SQL Error");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error");
        //    }
        //}

        private void lvBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBook.SelectedItems.Count == 0)
                return;

            int currentIndex = Convert.ToInt32(lvBook.SelectedItems[0].Text) - 1;
            //MessageBox.Show(currentIndex);

            Book currentBook = booksList[currentIndex];
            tbID.Text = currentBook.ID.ToString();
            _ = (currentBook.LoaiSach == 0) ? rbSingleVolume.Checked = true : rbSeries.Checked = true;
            tbBookName.Text = currentBook.TenSach;
            cbCategory.SelectedValue = currentBook.ID_TheLoai;
            if (currentBook.ID_TacGia != null) cbAuthor.SelectedValue = currentBook.ID_TacGia;
            mtbPublishedYear.Text = currentBook.NamXuatBan;
            if (currentBook.ID_NhaXuatBan != null) cbPublisher.SelectedValue = currentBook.ID_NhaXuatBan;
            tbLocation.Text = currentBook.ViTri;
            tbNotes.Text = currentBook.GhiChu;
        }

        private void bSaveBook_Click(object sender, EventArgs e)
        {
            if (tbID.Text == "")
            {
                int result = InsertBook();
                if (result > 0)
                {
                    MessageBox.Show($"Thêm sách thành công. ID = {result}");
                    LoadBook(lvBook);
                }
                else MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại.");
            }
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(cbCategory.SelectedValue));
        }
    }
}
