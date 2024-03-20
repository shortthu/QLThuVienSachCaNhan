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
    public partial class OtherStuffManagement : Form
    {
        int function;
        // 0: CategoryMan; 1: AuthorMan; 2: PublisherMan; 3: PeopleMan
        List<Category> categoryList = new List<Category>();
        Category selectedCategory;
        List<Author> authorList = new List<Author>();
        Author selectedAuthor;
        List<Publisher> publisherList = new List<Publisher>();
        Publisher selectedPublisher;

        QLThuVien mainForm = (QLThuVien)Application.OpenForms["QLThuVien"];

        public OtherStuffManagement(int func)
        {
            InitializeComponent();
            function = func;
        }

        private void HideExtraControls()
        {
            label3.Visible = false;
            tbProp2.Visible = false;
        }

        private void ClearAllControls()
        {
            tbID.Text = null;
            tbProp1.Text = null;
            tbProp2.Text = null;
        }

        private void LoadData()
        {
            switch (function)
            {
                case 0:
                    CategoryBL categoryBL = new CategoryBL();
                    categoryList = categoryBL.GetAll();

                    lTitle.Text = "Quản lý thể loại";
                    label2.Text = "Tên thể loại";
                    lbList.DataSource = categoryList;
                    lbList.DisplayMember = "TenTheLoai";
                    lbList.ValueMember = "ID";
                    lbList.ClearSelected();

                    HideExtraControls();
                    break;
                case 1:
                    AuthorBL authorBL = new AuthorBL();
                    authorList = authorBL.GetAll();

                    lTitle.Text = "Quản lý tác giả";
                    label2.Text = "Tên tác giả";
                    lbList.DataSource = authorList;
                    lbList.DisplayMember = "TenTacGia";
                    lbList.ValueMember = "ID";
                    lbList.ClearSelected();

                    HideExtraControls();
                    break;
                case 2:
                    PublisherBL publisherBL = new PublisherBL();
                    publisherList = publisherBL.GetAll();

                    lTitle.Text = "Quản lý nhà xuất bản";
                    label2.Text = "Tên nhà xuất bản";
                    lbList.DataSource = publisherList;
                    lbList.DisplayMember = "TenNhaXuatBan";
                    lbList.ValueMember = "ID";
                    lbList.ClearSelected();

                    HideExtraControls();
                    break;
            }
        }

        private void LoadDataToControls()
        {
            switch (function)
            {
                case 0:
                    tbID.Text = selectedCategory.ID.ToString();
                    tbProp1.Text = selectedCategory.TenTheLoai.ToString();
                    break;
                case 1:
                    tbID.Text = selectedAuthor.ID.ToString();
                    tbProp1.Text = selectedAuthor.TenTacGia.ToString();
                    break;
                case 2:
                    tbID.Text = selectedPublisher.ID.ToString();
                    tbProp1.Text = selectedPublisher.TenNhaXuatBan.ToString();
                    break;
            }
        }

        private void ReloadDataOnMainForm()
        {
            //switch (function)
            //{
            //    case 0:
            //        mainForm.LoadCategory();
            //        break;
            //    case 1:
            //        mainForm.LoadAuthor();
            //        break;
            //    case 2:
            //        mainForm.LoadPublisher();
            //        break;
            //}

            mainForm.ReloadAllLists();
        }

        private int AddData()
        {
            int result = -1;
            if (tbProp1.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu vài ô cần thiết. Vui lòng nhập lại");
            else
            {
                switch (function)
                {
                    case 0:
                        Category newCategory = new Category();
                        newCategory.ID = 0;
                        newCategory.TenTheLoai = tbProp1.Text;
                        CategoryBL category = new CategoryBL();
                        result = category.Insert(newCategory);
                        ReloadDataOnMainForm();
                        return result;
                    case 1:
                        Author newAuthor = new Author();
                        newAuthor.ID = 0;
                        newAuthor.TenTacGia = tbProp1.Text;
                        AuthorBL authorBL = new AuthorBL();
                        result = authorBL.Insert(newAuthor);
                        ReloadDataOnMainForm();
                        return result;
                    case 2:
                        Publisher newPublisher = new Publisher();
                        newPublisher.ID = 0;
                        newPublisher.TenNhaXuatBan = tbProp1.Text;
                        PublisherBL publisherBL = new PublisherBL();
                        result = publisherBL.Insert(newPublisher);
                        ReloadDataOnMainForm();
                        return result;
                }
            }
            return result;
        }

        private int UpdateData()
        {
            int result = -1;
            if (tbProp1.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu vài ô cần thiết. Vui lòng nhập lại");
            else
            {
                switch (function)
                {
                    case 0:
                        CategoryBL categoryBL = new CategoryBL();
                        Category category = new Category();
                        category.ID = selectedCategory.ID;
                        category.TenTheLoai = tbProp1.Text;
                        result = categoryBL.Update(category);
                        ReloadDataOnMainForm();
                        return result;
                    case 1:
                        AuthorBL authorBL = new AuthorBL();
                        Author author = new Author();
                        author.ID = selectedAuthor.ID;
                        author.TenTacGia = tbProp1.Text;
                        result = authorBL.Update(author);
                        ReloadDataOnMainForm();
                        return result;
                    case 2:
                        PublisherBL publisherBL = new PublisherBL();
                        Publisher publisher = new Publisher();
                        publisher.ID = selectedPublisher.ID;
                        publisher.TenNhaXuatBan = tbProp1.Text;
                        result = publisherBL.Update(publisher);
                        ReloadDataOnMainForm();
                        return result;
                }
            }
            return result;
        }

        private void DeleteData()
        {
            if (MessageBox.Show("Bạn có muốn xoá mục này?", "Thông báo",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                switch (function)
                {
                    case 0:
                        CategoryBL categoryBL = new CategoryBL();
                        if (categoryBL.Delete(selectedCategory) > 0)
                        {
                            MessageBox.Show("Xoá thành công.");
                            LoadData();
                            ClearAllControls();
                        }
                        else MessageBox.Show("Xoá không thành công.");
                        break;
                    case 1:
                        AuthorBL authorBL = new AuthorBL();
                        if (authorBL.Delete(selectedAuthor) > 0)
                        {
                            MessageBox.Show("Xoá thành công.");
                            LoadData();
                            ClearAllControls();
                        }
                        else MessageBox.Show("Xoá không thành công.");
                        break;
                    case 2:
                        PublisherBL publisherBL = new PublisherBL();
                        if (publisherBL.Delete(selectedPublisher) > 0)
                        {
                            MessageBox.Show("Xoá thành công.");
                            LoadData();
                            ClearAllControls();
                        }
                        else MessageBox.Show("Xoá không thành công.");
                        break;
                }
                ReloadDataOnMainForm();
            }
        }

        private void OtherStuffManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbList.SelectedItems.Count == 0)
                return;
            if (int.TryParse(lbList.SelectedValue.ToString(), out _))
            {
                int currentIndex = Convert.ToInt32(lbList.SelectedIndex);
                switch (function)
                {
                    case 0:
                        selectedCategory = categoryList[currentIndex];
                        LoadDataToControls();
                        break;
                    case 1:
                        selectedAuthor = authorList[currentIndex];
                        LoadDataToControls();
                        break;
                    case 2:
                        selectedPublisher = publisherList[currentIndex];
                        LoadDataToControls();
                        break;
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (tbID.Text == "")
            {
                int result = AddData();
                if (result > 0)
                {
                    MessageBox.Show($"Đã thêm, ID = {result}");
                    LoadData();
                }
                else MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại.");
            }
            else
            {
                int result = UpdateData();
                if (result > 0)
                {
                    MessageBox.Show($"Chỉnh sửa ID {result} thành công.");
                    LoadData();
                }
                else MessageBox.Show("Sửa dữ liệu không thành công. Vui lòng kiểm tra lại.");
            }
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            ClearAllControls();
        }
    }
}
