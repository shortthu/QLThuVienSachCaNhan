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
        List<Book> lendingBooksList = new List<Book>();
        List<Book> borrowingBooksList = new List<Book>();
        List<Book> AvailableBooksList = new List<Book>();
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

        public void ReloadAllLists()
        {
            LoadPublisher();
            LoadAuthor();
            LoadCategory();
            LoadBorrow();
            allBooksList = LoadBook(lvBook, 0, ""); // Load all books
            lendingBooksList = LoadBook(lvLending, 3, null);
            borrowingBooksList = LoadBook(lvBorrowing, 4, null);
            AvailableBooksList = LoadBook(lvAvailable, 5, null);
        }

        public void ResetAllFields()
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

        private Book GetFormsData(int func)
        {
            Book book = new Book();
            // Insert: func = 0; Update: func = 1
            switch (func)
            {
                case 0:
                    book.ID = 0;
                    book.TrangThai = 0;
                    break;
                case 1:
                    book.ID = selectedBook.ID;
                    book.TrangThai = selectedBook.TrangThai;
                    break;
            }
            book.LoaiSach = GetBookType();
            book.TenSach = tbBookName.Text;
            book.NamXuatBan = mtbPublishedYear.Text;
            book.ViTri = tbLocation.Text;
            book.GhiChu = tbNotes.Text;
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
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        private void ShowContextMenu(ListView list, MouseEventArgs e)
        {
            var focusedItem = list.FocusedItem;
            if (e.Button == MouseButtons.Right)
            {
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    switch (selectedBook.TrangThai)
                    {
                        case 0:
                            lendingToolStripMenuItem.Visible = true;
                            borrowingToolStripMenuItem.Visible = true;
                            returnBookToolStripMenuItem.Visible = false;
                            break;
                        case 1:
                            lendingToolStripMenuItem.Visible = false;
                            borrowingToolStripMenuItem.Visible = false;
                            returnBookToolStripMenuItem.Visible = true;
                            break;
                        case 2:
                            borrowingToolStripMenuItem.Visible = false;
                            lendingToolStripMenuItem.Visible = false;
                            returnBookToolStripMenuItem.Visible = true;
                            break;
                    }
                    cmBookItemRightClick.Show(Cursor.Position);
                }
            }
        }

        private void ShowSelectedBook(ListView list, List<Book> bookList)
        {
            if (list.SelectedItems.Count == 0) return;

            int currentIndex = Convert.ToInt32(list.SelectedItems[0].Text) - 1;

            selectedBook = bookList[currentIndex];
            SetFormsData();
        }

        private List<Book> ShowBooksOnSelectedCategory(ListBox categoryList, ListView bookListView)
        {
            List<Book> bookList = new List<Book>();
            if (categoryList.SelectedItems.Count == 0) return null;
            if (int.TryParse(categoryList.SelectedValue.ToString(), out _))
            {
                int selectedCategoryID = Convert.ToInt32(categoryList.SelectedValue);
                bookList = LoadBook(bookListView, 2, selectedCategoryID.ToString());
            }
            return bookList;
        }

        private void LoadManagementForm(int function)
        {
            OtherStuffManagement otherStuffManagement = new OtherStuffManagement(function);
            otherStuffManagement.Show();
        }

        private void LoadBorrowForm(int function)
        {
            BorrowDialogue borrowDialogue = new BorrowDialogue(function, selectedBook);
            borrowDialogue.Show();
        }

        private void LoadHistoryForm()
        {
            BorrowHistoryForm borrowHistoryForm = new BorrowHistoryForm();
            borrowHistoryForm.Show();
        }

        private int HandleBookReturn()
        {
            BookBL bookBL = new BookBL();
            Book book = new Book();
            BorrowHistoryBL borrowHistoryBL = new BorrowHistoryBL();
            BorrowHistory borrowHistory = new BorrowHistory();
            book = selectedBook;
            borrowHistory.ID_Sach = selectedBook.ID;
            borrowHistory.ID_Muon = (int)selectedBook.ID_Muon;
            borrowHistory.ThoiGian = DateTime.Now;
            // 1: Lending books -> change TrangThai to 3 & save history HinhThuc = 2
            // 2: (other ppl) borrowing books -> change TrangThai to 1 & save history HinhThuc = 3
            switch (selectedBook.TrangThai)
            {
                case 1:
                    book.TrangThai = 3;
                    borrowHistory.HinhThuc = 2;
                    break;
                case 2:
                    book.TrangThai = 1;
                    borrowHistory.HinhThuc = 3;
                    break;
            }
            borrowHistoryBL.Insert(borrowHistory);
            return bookBL.Update(book);
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
        }

        private List<Book> LoadBook(ListView bookListView, int func, string key)
        {
            BookBL bookBL = new BookBL();
            List<Book> booksList = new List<Book>();
            // func = 0: Get all; func = 1: find; func = 2: filter by category;
            // func = 3: lending books; func = 4: borrowing books; func = 5: available books
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
                    booksList = bookBL.FindLending();
                    break;
                case 4:
                    booksList = bookBL.FindBorrowing();
                    break;
                case 5:
                    booksList = bookBL.FindAvailable();
                    break;
            }

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

            ResizeListViewColumns(bookListView);
            return booksList;
        }

        // Insert funcs
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
            ShowSelectedBook(lvBook, allBooksList);
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
            ShowContextMenu(lvBook, e);
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
            booksByCategoryList = ShowBooksOnSelectedCategory(lbCategory, lvBookCategory);
        }

        private void lvBookCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedBook(lvBookCategory, booksByCategoryList);
        }

        private void bEditCategory_Click(object sender, EventArgs e)
        {
            LoadManagementForm(0);
        }

        private void bEditAuthor_Click(object sender, EventArgs e)
        {
            LoadManagementForm(1);
        }

        private void bEditPublisher_Click(object sender, EventArgs e)
        {
            LoadManagementForm(2);
        }

        private void lvLending_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedBook(lvLending, lendingBooksList);
        }

        private void lvBorrowing_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedBook(lvBorrowing, borrowingBooksList);
        }

        private void lendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadBorrowForm(0);
        }

        private void borrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadBorrowForm(1);
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int result = HandleBookReturn();
            if (result > 0)
            {
                ReloadAllLists();
                MessageBox.Show("Trả thành công");
            }
            else MessageBox.Show("Thao tác không thành công");
        }

        private void lvBookCategory_MouseClick(object sender, MouseEventArgs e)
        {
            ShowContextMenu(lvBookCategory, e);
        }

        private void lvLending_MouseClick(object sender, MouseEventArgs e)
        {
            ShowContextMenu(lvLending, e);
        }

        private void lvBorrowing_MouseClick(object sender, MouseEventArgs e)
        {
            ShowContextMenu(lvBorrowing, e);
        }

        private void lvAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedBook(lvAvailable, AvailableBooksList);
        }

        private void lvAvailable_MouseClick(object sender, MouseEventArgs e)
        {
            ShowContextMenu(lvAvailable, e);
        }

        private void bBorrower2_Click(object sender, EventArgs e)
        {
            LoadManagementForm(3);
        }

        private void bBorrower_Click(object sender, EventArgs e)
        {
            LoadManagementForm(3);
        }

        private void bHistory_Click(object sender, EventArgs e)
        {
            LoadHistoryForm();
        }

        private void bHistory2_Click(object sender, EventArgs e)
        {
            LoadHistoryForm();
        }
    }
}
