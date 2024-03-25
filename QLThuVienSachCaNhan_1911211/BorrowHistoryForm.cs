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
    public partial class BorrowHistoryForm : Form
    {
        public BorrowHistoryForm()
        {
            InitializeComponent();
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        private void LoadHistory()
        {
            BorrowHistoryBL borrowHistoryBL = new BorrowHistoryBL();
            List<BorrowHistory> borrowHistories = new List<BorrowHistory>();
            BorrowBL borrowBL = new BorrowBL();
            List<Borrow> borrowList = borrowBL.GetAll();
            BookBL bookBL = new BookBL();
            List<Book> bookList = bookBL.GetAll();

            borrowHistories = borrowHistoryBL.GetAll();
            int count = 1;
            lvHistory.Items.Clear();
            foreach (var entry in borrowHistories)
            {
                ListViewItem item = lvHistory.Items.Add(count.ToString());
                string bookName = bookList.Find(x => x.ID == entry.ID_Sach).TenSach;
                string person = borrowList.Find(x => x.ID == entry.ID_Muon).Ten;
                string phoneNum = borrowList.Find(x => x.ID == entry.ID_Muon).SoDienThoai;
                string type;
                switch (entry.HinhThuc)
                {
                    case 0:
                        type = "Cho mượn";
                        break;
                    case 1:
                        type = "Mượn";
                        break;
                    case 2:
                        type = "Người khác trả";
                        break;
                    case 3:
                        type = "Trả người khác";
                        break;
                    default:
                        type = "Unknown";
                        break;
                }
                item.SubItems.Add(bookName);
                item.SubItems.Add(type);
                item.SubItems.Add(person);
                item.SubItems.Add(phoneNum);
                item.SubItems.Add(entry.ThoiGian.ToString());
                count++;
            }

            ResizeListViewColumns(lvHistory);
        }

        private void BorrowHistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }
    }
}
