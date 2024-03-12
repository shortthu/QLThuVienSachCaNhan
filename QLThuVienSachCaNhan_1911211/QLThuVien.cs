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
            ReloadAllLists();
        }

        // Utils

        private int GetBookType()
        {
            return rbSingleVolume.Checked ? 0 : 1;
        }

        private void ReloadAllLists()
        {
            LoadBook(lvBook);
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

        private void LoadBook(ListView bookListView)
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
        private int InsertMinorProperty(int property)
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

        private Book GetFormsData()
        {
            Book book = new Book();
            book.ID = 0;

            book.LoaiSach = GetBookType();
            book.TenSach = tbBookName.Text;
            book.NamXuatBan = mtbPublishedYear.Text;
            book.ViTri = tbLocation.Text;
            book.GhiChu = tbNotes.Text;
            book.TenTrangThai = 0;
            if (cbCategory.SelectedValue != null)
                book.ID_TheLoai = Convert.ToInt32(cbCategory.SelectedValue);
            else
            {
                int result = InsertMinorProperty(0);
                if (result > 0)
                {
                    MessageBox.Show($"Đã thêm thể loại, ID = {result}");
                    book.ID_TheLoai = result;
                    LoadCategory();
                }
                else MessageBox.Show("Không thể thêm thể loại");
            }
            if (cbAuthor.SelectedValue != null)
                book.ID_TacGia = Convert.ToInt32(cbAuthor.SelectedValue);
            else if (cbAuthor.Text != "")
            {
                int result = InsertMinorProperty(1);
                if (result > 0)
                {
                    MessageBox.Show($"Đã thêm tác giả, ID = {result}");
                    book.ID_TacGia = result;
                    LoadAuthor();
                }
                else MessageBox.Show("Không thể thêm tác giả");
            }
            else book.ID_TacGia = null;
            if (cbPublisher.SelectedValue != null)
                book.ID_NhaXuatBan = Convert.ToInt32(cbPublisher.SelectedValue);
            else if (cbPublisher.Text != "")
            {
                int result = InsertMinorProperty(2);
                if (result > 0)
                {
                    MessageBox.Show($"Đã thêm nhà xuất bản, ID = {result}");
                    book.ID_NhaXuatBan = result;
                    LoadPublisher();
                }
                else MessageBox.Show("Không thể thêm nhà xuất bản");
            }
            else book.ID_NhaXuatBan = null;
            return book;
        }

        private int InsertBook()
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

        private void DeleteBook()
        {
            if (MessageBox.Show("Bạn có muốn xoá sách này?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BookBL bookBL = new BookBL();
                if (bookBL.Delete(selectedBook) > 0)
                {
                    MessageBox.Show("Xoá thành công.");
                    ReloadAllLists();
                }
                else MessageBox.Show("Xoá không thành công.");
            }
        }

        private int UpdateBook()
        {
            Book tempBook = selectedBook;
            if (cbCategory.Text == "" || tbBookName.Text == "" || (!rbSingleVolume.Checked && !rbSeries.Checked))
                MessageBox.Show("Chưa nhập dữ liệu vài ô cần thiết. Vui lòng nhập lại");
            else
            {

            }
        }
        // Events

        private void lvBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBook.SelectedItems.Count == 0)
                return;

            int currentIndex = Convert.ToInt32(lvBook.SelectedItems[0].Text) - 1;
            //MessageBox.Show(currentIndex);

            selectedBook = booksList[currentIndex];
            tbID.Text = selectedBook.ID.ToString();
            _ = (selectedBook.LoaiSach == 0) ? rbSingleVolume.Checked = true : rbSeries.Checked = true;
            tbBookName.Text = selectedBook.TenSach;
            cbCategory.SelectedValue = selectedBook.ID_TheLoai;
            if (selectedBook.ID_TacGia != null) cbAuthor.SelectedValue = selectedBook.ID_TacGia;
            mtbPublishedYear.Text = selectedBook.NamXuatBan;
            if (selectedBook.ID_NhaXuatBan != null) cbPublisher.SelectedValue = selectedBook.ID_NhaXuatBan;
            tbLocation.Text = selectedBook.ViTri;
            tbNotes.Text = selectedBook.GhiChu;
        }

        private void bSaveBook_Click(object sender, EventArgs e)
        {
            if (tbID.Text == "")
            {
                int result = InsertBook();
                if (result > 0)
                {
                    MessageBox.Show($"Thêm sách thành công. ID = {result}");
                    ReloadAllLists();
                }
                else MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại.");
            }
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            tbID.Text = null;
            rbSingleVolume.Checked = true;
            tbBookName.Text = null;
            cbCategory.Text = null;
            cbAuthor.Text = null;
            mtbPublishedYear.Text = null;
            cbPublisher.Text = null;
            tbLocation.Text = null;
            tbNotes.Text = null;
        }
    }
}
