using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace QLThuVienSachCaNhan_1911211
{
    public partial class QLThuVien : Form
    {
        List<Publisher> publisherList = new List<Publisher>();
        List<Book> allBooksList = new List<Book>();
        List<Book> booksByCategoryList = new List<Book>();
        List<Book> borrowedBooksList = new List<Book>();
        List<Book> borrowingBooksList = new List<Book>();
        List<Author> authorList = new List<Author>();
        List<Category> categoryList = new List<Category>();
        List<Borrow> borrowList = new List<Borrow>();
        Book selectedBook = new Book();

        public QLThuVien()
        {
            InitializeComponent();
        }

        private void QLThuVien_Load(object sender, EventArgs e)
        {
            ReloadAllLists();
        }

        // Utils

        private int GetBookType()
        {
            return rbSingleVolume.Checked ? 0 : 1;
        }

        private int GetStatus()
        {
            return rbAvailable.Checked ? 0 : (rbBorrowed.Checked ? 1 : 2);
        }

        public void ReloadAllLists()
        {
            LoadPublisher();
            LoadAuthor();
            LoadCategory();
            LoadBorrow();
            allBooksList = LoadBook(lvBook, 0, ""); // Load all books
            borrowedBooksList = LoadBook(lvBorrowed, 3, null);
            borrowingBooksList = LoadBook(lvBorrowing, 4, null);
        }

        private void ResetAllFields()
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
            rbAvailable.Checked = true;
            cbName.SelectedIndex = 0;
        }

        private Book GetFormsData(int func)
        {
            Book book = new Book();
            // Insert: func = 0; Update: func = 1
            switch (func)
            {
                case 0:
                    book.ID = 0;
                    break;
                case 1:
                    book.ID = selectedBook.ID;
                    break;
            }

            book.LoaiSach = GetBookType();
            book.TenSach = tbBookName.Text;
            book.NamXuatBan = mtbPublishedYear.Text;
            book.ViTri = tbLocation.Text;
            book.GhiChu = tbNotes.Text;
            book.TrangThai = GetStatus();
            if (book.TrangThai > 0)
                book.ID_Muon = Convert.ToInt32(cbName.SelectedValue);
            else book.ID_Muon = null;
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

        private void SetFormsData()
        {
            tbID.Text = selectedBook.ID.ToString();
            _ = (selectedBook.LoaiSach == 0) ? rbSingleVolume.Checked = true : rbSeries.Checked = true;
            tbBookName.Text = selectedBook.TenSach;
            cbCategory.SelectedValue = selectedBook.ID_TheLoai;
            if (selectedBook.ID_TacGia != null)
                cbAuthor.SelectedValue = selectedBook.ID_TacGia;
            mtbPublishedYear.Text = selectedBook.NamXuatBan;
            if (selectedBook.ID_NhaXuatBan != null)
                cbPublisher.SelectedValue = selectedBook.ID_NhaXuatBan;
            tbLocation.Text = selectedBook.ViTri;
            tbNotes.Text = selectedBook.GhiChu;
            _ = (selectedBook.TrangThai == 0) ? rbAvailable.Checked = true
              : (selectedBook.TrangThai == 1 ? rbBorrowed.Checked = true : rbBorrowing.Checked = true);
            if (selectedBook.TrangThai > 0)
                cbName.SelectedValue = selectedBook.ID_Muon;
            //if (int.TryParse(cbName.SelectedValue.ToString(), out _))
            tbPhoneNum.Text = borrowList.Find(x => x.ID == Convert.ToInt32(cbName.SelectedValue)).SoDienThoai;
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        // Load funcs

        public void LoadPublisher()
        {
            PublisherBL publisherBL = new PublisherBL();
            publisherList = publisherBL.GetAll();

            cbPublisher.DataSource = publisherList;
            cbPublisher.DisplayMember = "TenNhaXuatBan";
            cbPublisher.ValueMember = "ID";
            cbPublisher.Text = null;
        }

        public void LoadAuthor()
        {
            AuthorBL authorBL = new AuthorBL();
            authorList = authorBL.GetAll();

            cbAuthor.DataSource = authorList;
            cbAuthor.DisplayMember = "TenTacGia";
            cbAuthor.ValueMember = "ID";
            cbAuthor.Text = null;
        }

        public void LoadCategory()
        {
            CategoryBL categoryBL = new CategoryBL();
            categoryList = categoryBL.GetAll();

            cbCategory.DataSource = categoryList;
            cbCategory.DisplayMember = "TenTheLoai";
            cbCategory.ValueMember = "ID";
            cbCategory.Text = null;

            lbCategory.DataSource = categoryList.ToList();
            lbCategory.DisplayMember = "TenTheLoai";
            lbCategory.ValueMember = "ID";
            lbCategory.ClearSelected();
        }

        private void LoadBorrow()
        {
            BorrowBL borrowBL = new BorrowBL();
            borrowList = borrowBL.GetAll();

            cbName.DataSource = borrowList;
            cbName.DisplayMember = "Ten";
            cbName.ValueMember = "ID";
        }

        private List<Book> LoadBook(ListView bookListView, int func, string key)
        {
            BookBL bookBL = new BookBL();
            List<Book> booksList = new List<Book>();
            // func = 0: Get all; func = 1: find; func = 2: filter by category;
            // func = 3 
            switch (func)
            {
                case 0:
                    booksList = bookBL.GetAll();
                    break;
                case 1:
                    booksList = bookBL.Find(key);
                    break;
                case 2:
                    booksList = bookBL.FilterBookByCategory(Convert.ToInt32(key));
                    break;
                case 3:
                    booksList = bookBL.FindBorrowed();
                    break;
                case 4:
                    booksList = bookBL.FindBorrowing();
                    break;
            }

            int count = 1;
            ResizeListViewColumns(bookListView);
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
                switch (book.TrangThai)
                {
                    case 0:
                        status = "Đang có sẵn";
                        break;
                    case 1:
                        status = "Cho mượn";
                        break;
                    case 2:
                        status = "Đang mượn";
                        break;
                    case 3:
                        status = "Đã trả";
                        break;
                    default:
                        status = "Unknown";
                        break;
                }
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
                string borrowName = (book.ID_Muon != null) ? borrowList.Find(x => x.ID == book.ID_Muon).Ten : null;
                item.SubItems.Add(borrowName);
                string borrowPhoneNum = (book.ID_Muon != null) ? borrowList.Find(x => x.ID == book.ID_Muon).SoDienThoai : null;
                item.SubItems.Add(borrowPhoneNum);
                count++;
            }

            return booksList;
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


        private int InsertBook()
        {
            if (cbCategory.Text == "" || tbBookName.Text == "" || (!rbSingleVolume.Checked && !rbSeries.Checked))
                MessageBox.Show("Chưa nhập dữ liệu vài ô cần thiết. Vui lòng nhập lại");
            else
            {
                BookBL bookBL = new BookBL();
                return bookBL.Insert(GetFormsData(0));
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
                    ResetAllFields();
                }
                else MessageBox.Show("Xoá không thành công.");
            }
        }

        private int UpdateBook()
        {
            if (cbCategory.Text == "" || tbBookName.Text == "" || (!rbSingleVolume.Checked && !rbSeries.Checked))
                MessageBox.Show("Chưa nhập dữ liệu vài ô cần thiết. Vui lòng nhập lại");
            else
            {
                BookBL bookBL = new BookBL();
                return bookBL.Update(GetFormsData(1));
            }
            return -1;
        }
        // Events

        private void lvBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBook.SelectedItems.Count == 0)
                return;

            int currentIndex = Convert.ToInt32(lvBook.SelectedItems[0].Text) - 1;
            //MessageBox.Show(currentIndex);

            selectedBook = allBooksList[currentIndex];
            SetFormsData();
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
                    ResetAllFields();
                }
                else MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại.");
            }
            else
            {
                int result = UpdateBook();
                if (result > 0)
                {
                    MessageBox.Show($"Chỉnh sửa ID {result} thành công.");
                    ReloadAllLists();
                    ResetAllFields();
                }
                else MessageBox.Show("Sửa dữ liệu không thành công. Vui lòng kiểm tra lại.");
            }
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            ResetAllFields();
        }

        private void lvBook_MouseClick(object sender, MouseEventArgs e)
        {
            var focusedItem = lvBook.FocusedItem;
            var currentIndex = lvBook.FocusedItem.Index;
            if (e.Button == MouseButtons.Right)
            {
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    cmBookItemRightClick.Show(Cursor.Position);
                }
            }
        }

        private void deleteBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBook();
        }

        private void tbSearchAll_TextChanged(object sender, EventArgs e)
        {
            allBooksList = LoadBook(lvBook, 1, tbSearchAll.Text);
        }

        private void lbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCategory.SelectedItems.Count == 0)
                return;
            if (int.TryParse(lbCategory.SelectedValue.ToString(), out _))
            {
                int selectedCategoryID = Convert.ToInt32(lbCategory.SelectedValue);
                booksByCategoryList = LoadBook(lvBookCategory, 2, selectedCategoryID.ToString());
            }
        }

        private void lvBookCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBookCategory.SelectedItems.Count == 0) return;

            int currentIndex = Convert.ToInt32(lvBookCategory.SelectedItems[0].Text) - 1;
            //MessageBox.Show(currentIndex);

            selectedBook = booksByCategoryList[currentIndex];
            SetFormsData();
        }

        private void bEditCategory_Click(object sender, EventArgs e)
        {
            OtherStuffManagement categoryManagement = new OtherStuffManagement(0);
            categoryManagement.Show();
        }

        private void bEditAuthor_Click(object sender, EventArgs e)
        {
            OtherStuffManagement authorManagement = new OtherStuffManagement(1);
            authorManagement.Show();
        }

        private void bEditPublisher_Click(object sender, EventArgs e)
        {
            OtherStuffManagement publisherManagement = new OtherStuffManagement(2);
            publisherManagement.Show();
        }

        private void rbAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAvailable.Checked)
            {
                cbName.Enabled = false;
            }
            else
            {
                cbName.Enabled = true;
            }
        }

        private void cbName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbName.SelectedValue.ToString(), out _))
                tbPhoneNum.Text = borrowList.Find(x => x.ID == Convert.ToInt32(cbName.SelectedValue)).SoDienThoai;
        }

        private void bEditBorrow_Click(object sender, EventArgs e)
        {
            OtherStuffManagement borrowManagement = new OtherStuffManagement(3);
            borrowManagement.Show();
        }

        private void lvBorrowed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBorrowed.SelectedItems.Count == 0) return;

            int currentIndex = Convert.ToInt32(lvBorrowed.SelectedItems[0].Text) - 1;

            selectedBook = borrowedBooksList[currentIndex];
            SetFormsData();
        }

        private void lvBorrowing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBorrowing.SelectedItems.Count == 0) return;

            int currentIndex = Convert.ToInt32(lvBorrowing.SelectedItems[0].Text) - 1;

            selectedBook = borrowingBooksList[currentIndex];
            SetFormsData();
        }
    }
}
