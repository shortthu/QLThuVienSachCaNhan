using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVienSachCaNhan_1911211
{
    public partial class BorrowDialogue : Form
    {
        int function;
        Book selectedBook = new Book();
        List<Borrow> borrowList = new List<Borrow>();

        QLThuVien mainForm = (QLThuVien)Application.OpenForms["QLThuVien"];

        // func = 0: borrowed; func = 1: borrowing

        public BorrowDialogue(int function, Book selectedBook)
        {
            InitializeComponent();
            this.function = function;
            this.selectedBook = selectedBook;
        }

        private void ReloadDataOnMainForm()
        {
            mainForm.ReloadAllLists();
            mainForm.ResetAllFields();
        }

        private void LoadBorrow()
        {
            BorrowBL borrowBL = new BorrowBL();
            borrowList = borrowBL.GetAll();

            cbName.DataSource = borrowList;
            cbName.DisplayMember = "Ten";
            cbName.ValueMember = "ID";
            tbBookID.Text = selectedBook.ID.ToString();
            tbBookName.Text = selectedBook.TenSach;
            switch (function)
            {
                case 0:
                    Text = "Cho mượn";
                    break;
                case 1:
                    Text = "Mượn";
                    break;
            }
        }

        private int UpdateBorrow()
        {
            BookBL bookBL = new BookBL();
            Book book = new Book();
            book = selectedBook;
            book.TrangThai = function + 1;
            book.ID_Muon = Convert.ToInt32(cbName.SelectedValue);
            return bookBL.Update(book);
        }

        private void BorrowDialogue_Load(object sender, EventArgs e)
        {
            LoadBorrow();
        }

        private void bEditBorrow_Click(object sender, EventArgs e)
        {
            OtherStuffManagement borrowManagement = new OtherStuffManagement(3);
            borrowManagement.Show();
        }

        private void cbName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbName.SelectedValue.ToString(), out _))
                tbPhoneNum.Text = borrowList.Find(x => x.ID == Convert.ToInt32(cbName.SelectedValue)).SoDienThoai;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            int result = UpdateBorrow();
            if (result > 0)
            {
                switch (function)
                {
                    case 0:
                        MessageBox.Show($"Đã cho {cbName.Text} mượn sách {selectedBook.TenSach}.");
                        break;
                    case 1:
                        MessageBox.Show($"Đã mượn sách {selectedBook.TenSach} của {cbName.Text}.");
                        break;
                }
                ReloadDataOnMainForm();
                Close();
            }
            else MessageBox.Show("Sửa dữ liệu không thành công. Vui lòng kiểm tra lại.");
        }
    }
}
