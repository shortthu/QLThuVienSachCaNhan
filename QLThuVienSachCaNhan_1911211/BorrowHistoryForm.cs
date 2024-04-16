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
        BorrowHistory selectedHistory = new BorrowHistory();
        BorrowHistoryBL borrowHistoryBL = new BorrowHistoryBL();
        List<BorrowHistory> borrowHistory = new List<BorrowHistory>();
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
            borrowHistory = borrowHistoryBL.GetAll();
            int count = 1;
            lvHistory.Items.Clear();
            foreach (var entry in borrowHistory)
            {
                ListViewItem item = lvHistory.Items.Add(count.ToString());
                string bookName = entry.TenSach;
                string person = entry.TenNguoiMuon;
                string phoneNum = entry.SoDienThoaiMuon;
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

        private void DeleteHistory()
        {
            if (MessageBox.Show("Bạn có muốn xoá?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BorrowHistoryBL borrowHistoryBL = new BorrowHistoryBL();
                if (borrowHistoryBL.Delete(selectedHistory) > 0)
                {
                    MessageBox.Show("Xoá thành công.");
                    LoadHistory();
                }
                else MessageBox.Show("Xoá không thành công.");
            }
        }

        private void SelectHistoryEntry(ListView list)
        {
            if (list.SelectedItems.Count == 0) return;

            int currentIndex = Convert.ToInt32(list.SelectedItems[0].Text) - 1;

            selectedHistory = borrowHistory[currentIndex];
        }

        private void BorrowHistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void delHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteHistory();
        }

        private void lvHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectHistoryEntry(lvHistory);
        }

        private void lvHistory_MouseClick(object sender, MouseEventArgs e)
        {
            var focusedItem = lvHistory.FocusedItem;
            if (e.Button == MouseButtons.Right)
            {
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    cmHistoryRightClick.Show(Cursor.Position);
                }
            }
        }
    }
}
