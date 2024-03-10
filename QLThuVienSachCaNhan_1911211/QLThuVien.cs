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
            LoadBook();
            TaiTatCaSach();
        }

        private void LoadPublisher()
        {
            PublisherBL publisherBL = new PublisherBL();
            publisherList = publisherBL.GetAll();

            cbPublisher.DataSource = publisherList;
            cbPublisher.DisplayMember = "TenNhaXuatBan";
            cbPublisher.ValueMember = "ID";
            cbPublisher.Text = "";
        }

        private void LoadAuthor()
        {
            AuthorBL authorBL = new AuthorBL();
            authorList = authorBL.GetAll();

            cbAuthor.DataSource = authorList;
            cbAuthor.DisplayMember = "TenTacGia";
            cbAuthor.ValueMember = "ID";
            cbAuthor.Text = "";
        }

        private void LoadCategory()
        {
            CategoryBL categoryBL = new CategoryBL();
            categoryList = categoryBL.GetAll();

            cbCategory.DataSource = categoryList;
            cbCategory.DisplayMember = "TenTheLoai";
            cbCategory.ValueMember = "ID";
            cbCategory.Text = "";
        }

        public void LoadBook()
        {
            BookBL bookBL = new BookBL();
            booksList = bookBL.GetAll();

            int count = 1;
            lvBook.Items.Clear();

            foreach (var book in booksList)
            {
                ListViewItem item = lvBook.Items.Add(count.ToString());
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
                string authorName = authorList.Find(x => x.ID == book.ID_TacGia).TenTacGia;
                item.SubItems.Add(authorName);
                string publisherName = publisherList.Find(x => x.ID == book.ID_NhaXuatBan).TenNhaXuatBan;
                item.SubItems.Add(publisherName);
                item.SubItems.Add(book.NamXuatBan);
                item.SubItems.Add(book.ViTri);
                item.SubItems.Add(book.GhiChu);
                count++;
            }
        }

        public void TaiTatCaSach()
        {
            SqlConnection conn = new SqlConnection(Utilities.ConnectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Sach";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            conn.Open();
            dataAdapter.Fill(dt);
            conn.Close();

            dgvAllBooks.DataSource = dt;
        }

        public string ThemTheLoai()
        {
            try
            {
                string categoryID = "";

                SqlConnection conn = new SqlConnection(Utilities.ConnectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertCategory @id OUTPUT, @tenTheLoai";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@tenTheLoai", SqlDbType.NVarChar, 50);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                cmd.Parameters["@tenTheLoai"].Value = cbCategory.Text;

                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    categoryID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show($"Đã thêm thể loại mới. ID = {categoryID}");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Không thể thêm thể loại.");
                }

                conn.Close();
                conn.Dispose();

                return categoryID;
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ThemTacGia()
        {
            try
            {
                string authorID = "";

                SqlConnection conn = new SqlConnection(Utilities.ConnectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertAuthor @id OUTPUT, @tenTacGia";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@tenTacGia", SqlDbType.NVarChar, 50);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                cmd.Parameters["@tenTacGia"].Value = cbAuthor.Text;

                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    authorID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show($"Đã thêm tác giả mới. ID = {authorID}");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Không thể thêm tác giả.");
                }

                conn.Close();
                conn.Dispose();

                return authorID;
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        private void bAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Utilities.ConnectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertBook @id OUTPUT, @loaiSach, @id_theLoai, @tenSach, @id_tacGia, " +
                    "@namXuatBan, @id_nhaXuatBan, @viTri, @tenTrangThai, @ghiChu";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@loaiSach", SqlDbType.Int);
                cmd.Parameters.Add("@id_theLoai", SqlDbType.Int);
                cmd.Parameters.Add("@tenSach", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@id_tacGia", SqlDbType.Int);
                cmd.Parameters.Add("@namXuatBan", SqlDbType.NChar, 4);
                cmd.Parameters.Add("@id_nhaXuatBan", SqlDbType.Int);
                cmd.Parameters.Add("@viTri", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@tenTrangThai", SqlDbType.SmallInt);
                cmd.Parameters.Add("@ghiChu", SqlDbType.NText);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                cmd.Parameters["@loaiSach"].Value = rbSingleVolume.Checked ? 0 : 1;

                if (cbCategory.SelectedValue != null)
                    cmd.Parameters["@id_theLoai"].Value = cbCategory.SelectedValue;
                else
                {
                    string theLoai = ThemTheLoai();
                    if (theLoai.All(char.IsDigit))
                        cmd.Parameters["@id_theLoai"].Value = Convert.ToInt32(theLoai);
                    else MessageBox.Show(theLoai, "Error");
                }

                cmd.Parameters["@tenSach"].Value = tbBookName.Text;

                if (cbAuthor.SelectedValue != null)
                    cmd.Parameters["@id_tacGia"].Value = cbAuthor.SelectedValue;
                else
                {
                    string tacGia = ThemTacGia();
                    if (tacGia.All(char.IsDigit))
                        cmd.Parameters["@id_tacGia"].Value = Convert.ToInt32(tacGia);
                    else MessageBox.Show(tacGia, "Error");
                }

                cmd.Parameters["@namXuatBan"].Value = mtbPublishedYear.Text;
                cmd.Parameters["@id_nhaXuatBan"].Value = cbPublisher.SelectedValue;
                cmd.Parameters["@viTri"].Value = tbLocation.Text;
                cmd.Parameters["@tenTrangThai"].Value = 0;
                cmd.Parameters["@ghiChu"].Value = tbNotes.Text;

                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    string bookID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show($"Đã thêm sách/bộ sách mới. ID = {bookID}");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Không thể thêm sách.");
                }

                conn.Close();
                conn.Dispose();

                TaiTatCaSach();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

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
            cbAuthor.SelectedValue = currentBook.ID_TacGia;
            mtbPublishedYear.Text = currentBook.NamXuatBan;
            cbPublisher.SelectedValue = currentBook.ID_NhaXuatBan;
            tbLocation.Text = currentBook.ViTri;
            tbNotes.Text = currentBook.GhiChu;
        }

        private void bSaveBook_Click(object sender, EventArgs e)
        {

        }
    }
}
