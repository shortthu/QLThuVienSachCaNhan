namespace QLThuVienSachCaNhan_1911211
{
    partial class QLThuVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tCategory = new System.Windows.Forms.TabPage();
            this.tBorrowed = new System.Windows.Forms.TabPage();
            this.tBorrowing = new System.Windows.Forms.TabPage();
            this.tAllBooks = new System.Windows.Forms.TabPage();
            this.lvBook = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvAllBooks = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bEditPublisher = new System.Windows.Forms.Button();
            this.bEditAuthor = new System.Windows.Forms.Button();
            this.bEditCategory = new System.Windows.Forms.Button();
            this.bNew = new System.Windows.Forms.Button();
            this.bSaveBook = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mtbPublishedYear = new System.Windows.Forms.MaskedTextBox();
            this.cbPublisher = new System.Windows.Forms.ComboBox();
            this.cbAuthor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tbBookName = new System.Windows.Forms.TextBox();
            this.pTypes = new System.Windows.Forms.Panel();
            this.rbSingleVolume = new System.Windows.Forms.RadioButton();
            this.rbSeries = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tAllBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBooks)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tCategory);
            this.tabControl1.Controls.Add(this.tBorrowed);
            this.tabControl1.Controls.Add(this.tBorrowing);
            this.tabControl1.Controls.Add(this.tAllBooks);
            this.tabControl1.Location = new System.Drawing.Point(501, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(767, 453);
            this.tabControl1.TabIndex = 0;
            // 
            // tCategory
            // 
            this.tCategory.Location = new System.Drawing.Point(4, 22);
            this.tCategory.Name = "tCategory";
            this.tCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tCategory.Size = new System.Drawing.Size(759, 427);
            this.tCategory.TabIndex = 0;
            this.tCategory.Text = "Theo thể loại";
            this.tCategory.UseVisualStyleBackColor = true;
            // 
            // tBorrowed
            // 
            this.tBorrowed.Location = new System.Drawing.Point(4, 22);
            this.tBorrowed.Name = "tBorrowed";
            this.tBorrowed.Size = new System.Drawing.Size(759, 427);
            this.tBorrowed.TabIndex = 2;
            this.tBorrowed.Text = "Sách cho mượn";
            this.tBorrowed.UseVisualStyleBackColor = true;
            // 
            // tBorrowing
            // 
            this.tBorrowing.Location = new System.Drawing.Point(4, 22);
            this.tBorrowing.Name = "tBorrowing";
            this.tBorrowing.Size = new System.Drawing.Size(759, 427);
            this.tBorrowing.TabIndex = 3;
            this.tBorrowing.Text = "Sách mượn";
            this.tBorrowing.UseVisualStyleBackColor = true;
            // 
            // tAllBooks
            // 
            this.tAllBooks.Controls.Add(this.lvBook);
            this.tAllBooks.Controls.Add(this.dgvAllBooks);
            this.tAllBooks.Location = new System.Drawing.Point(4, 22);
            this.tAllBooks.Name = "tAllBooks";
            this.tAllBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tAllBooks.Size = new System.Drawing.Size(759, 427);
            this.tAllBooks.TabIndex = 1;
            this.tAllBooks.Text = "Tất cả sách";
            this.tAllBooks.UseVisualStyleBackColor = true;
            // 
            // lvBook
            // 
            this.lvBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader9,
            this.columnHeader6,
            this.columnHeader7});
            this.lvBook.FullRowSelect = true;
            this.lvBook.GridLines = true;
            this.lvBook.HideSelection = false;
            this.lvBook.Location = new System.Drawing.Point(6, 6);
            this.lvBook.MultiSelect = false;
            this.lvBook.Name = "lvBook";
            this.lvBook.Size = new System.Drawing.Size(745, 215);
            this.lvBook.TabIndex = 1;
            this.lvBook.UseCompatibleStateImageBehavior = false;
            this.lvBook.View = System.Windows.Forms.View.Details;
            this.lvBook.SelectedIndexChanged += new System.EventHandler(this.lvBook_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên sách";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Loại sách";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Trạng thái";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Thể loại";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tác giả";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nhà xuất bản";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Năm xuất bản";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Vị trí";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ghi chú";
            // 
            // dgvAllBooks
            // 
            this.dgvAllBooks.AllowUserToAddRows = false;
            this.dgvAllBooks.AllowUserToDeleteRows = false;
            this.dgvAllBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvAllBooks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllBooks.Location = new System.Drawing.Point(6, 227);
            this.dgvAllBooks.MultiSelect = false;
            this.dgvAllBooks.Name = "dgvAllBooks";
            this.dgvAllBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllBooks.Size = new System.Drawing.Size(198, 117);
            this.dgvAllBooks.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "Mã số";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LoaiSach";
            this.Column2.HeaderText = "Loại sách";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ID_TheLoai";
            this.Column3.HeaderText = "Thể loại";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TenSach";
            this.Column4.HeaderText = "Tên sách";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ID_TacGia";
            this.Column5.HeaderText = "Tác giả";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NamXuatBan";
            this.Column6.HeaderText = "Năm xuất bản";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "ID_NhaXuatBan";
            this.Column7.HeaderText = "Nhà xuất bản";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "ViTri";
            this.Column8.HeaderText = "Vị trí";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "TenTrangThai";
            this.Column9.HeaderText = "Tên trạng thái";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "GhiChu";
            this.Column10.HeaderText = "Ghi chú";
            this.Column10.Name = "Column10";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bEditPublisher);
            this.groupBox2.Controls.Add(this.bEditAuthor);
            this.groupBox2.Controls.Add(this.bEditCategory);
            this.groupBox2.Controls.Add(this.bNew);
            this.groupBox2.Controls.Add(this.bSaveBook);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbNotes);
            this.groupBox2.Controls.Add(this.tbID);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.mtbPublishedYear);
            this.groupBox2.Controls.Add(this.cbPublisher);
            this.groupBox2.Controls.Add(this.cbAuthor);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbLocation);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbCategory);
            this.groupBox2.Controls.Add(this.tbBookName);
            this.groupBox2.Controls.Add(this.pTypes);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 453);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thêm/Sửa";
            // 
            // bEditPublisher
            // 
            this.bEditPublisher.Location = new System.Drawing.Point(440, 178);
            this.bEditPublisher.Name = "bEditPublisher";
            this.bEditPublisher.Size = new System.Drawing.Size(35, 23);
            this.bEditPublisher.TabIndex = 40;
            this.bEditPublisher.Text = "Sửa";
            this.bEditPublisher.UseVisualStyleBackColor = true;
            // 
            // bEditAuthor
            // 
            this.bEditAuthor.Location = new System.Drawing.Point(440, 126);
            this.bEditAuthor.Name = "bEditAuthor";
            this.bEditAuthor.Size = new System.Drawing.Size(35, 23);
            this.bEditAuthor.TabIndex = 39;
            this.bEditAuthor.Text = "Sửa";
            this.bEditAuthor.UseVisualStyleBackColor = true;
            // 
            // bEditCategory
            // 
            this.bEditCategory.Location = new System.Drawing.Point(440, 100);
            this.bEditCategory.Name = "bEditCategory";
            this.bEditCategory.Size = new System.Drawing.Size(35, 23);
            this.bEditCategory.TabIndex = 38;
            this.bEditCategory.Text = "Sửa";
            this.bEditCategory.UseVisualStyleBackColor = true;
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(278, 372);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 23);
            this.bNew.TabIndex = 37;
            this.bNew.Text = "Mới";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bSaveBook
            // 
            this.bSaveBook.Location = new System.Drawing.Point(359, 372);
            this.bSaveBook.Name = "bSaveBook";
            this.bSaveBook.Size = new System.Drawing.Size(75, 23);
            this.bSaveBook.TabIndex = 0;
            this.bSaveBook.Text = "Lưu";
            this.bSaveBook.UseVisualStyleBackColor = true;
            this.bSaveBook.Click += new System.EventHandler(this.bSaveBook_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Ghi chú";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(143, 233);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(291, 133);
            this.tbNotes.TabIndex = 0;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(143, 18);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(291, 20);
            this.tbID.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "ID";
            // 
            // mtbPublishedYear
            // 
            this.mtbPublishedYear.Location = new System.Drawing.Point(143, 155);
            this.mtbPublishedYear.Mask = "0000";
            this.mtbPublishedYear.Name = "mtbPublishedYear";
            this.mtbPublishedYear.Size = new System.Drawing.Size(291, 20);
            this.mtbPublishedYear.TabIndex = 3;
            // 
            // cbPublisher
            // 
            this.cbPublisher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPublisher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPublisher.FormattingEnabled = true;
            this.cbPublisher.Location = new System.Drawing.Point(143, 180);
            this.cbPublisher.Name = "cbPublisher";
            this.cbPublisher.Size = new System.Drawing.Size(291, 21);
            this.cbPublisher.TabIndex = 4;
            // 
            // cbAuthor
            // 
            this.cbAuthor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbAuthor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAuthor.FormattingEnabled = true;
            this.cbAuthor.Location = new System.Drawing.Point(143, 128);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(291, 21);
            this.cbAuthor.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Loại";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(143, 207);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(291, 20);
            this.tbLocation.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Vị trí";
            // 
            // cbCategory
            // 
            this.cbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(143, 102);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(291, 21);
            this.cbCategory.TabIndex = 1;
            // 
            // tbBookName
            // 
            this.tbBookName.Location = new System.Drawing.Point(143, 76);
            this.tbBookName.Name = "tbBookName";
            this.tbBookName.Size = new System.Drawing.Size(291, 20);
            this.tbBookName.TabIndex = 0;
            // 
            // pTypes
            // 
            this.pTypes.Controls.Add(this.rbSingleVolume);
            this.pTypes.Controls.Add(this.rbSeries);
            this.pTypes.Location = new System.Drawing.Point(143, 44);
            this.pTypes.Name = "pTypes";
            this.pTypes.Size = new System.Drawing.Size(155, 23);
            this.pTypes.TabIndex = 24;
            // 
            // rbSingleVolume
            // 
            this.rbSingleVolume.AutoSize = true;
            this.rbSingleVolume.Checked = true;
            this.rbSingleVolume.Location = new System.Drawing.Point(3, 3);
            this.rbSingleVolume.Name = "rbSingleVolume";
            this.rbSingleVolume.Size = new System.Drawing.Size(72, 17);
            this.rbSingleVolume.TabIndex = 0;
            this.rbSingleVolume.TabStop = true;
            this.rbSingleVolume.Text = "Sách đơn";
            this.rbSingleVolume.UseVisualStyleBackColor = true;
            // 
            // rbSeries
            // 
            this.rbSeries.AutoSize = true;
            this.rbSeries.Location = new System.Drawing.Point(81, 3);
            this.rbSeries.Name = "rbSeries";
            this.rbSeries.Size = new System.Drawing.Size(65, 17);
            this.rbSeries.TabIndex = 1;
            this.rbSeries.TabStop = true;
            this.rbSeries.Text = "Sách bộ";
            this.rbSeries.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Nhà xuất bản";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Năm xuất bản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tác giả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tên sách/Tên bộ sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Thể loại";
            // 
            // QLThuVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 482);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Name = "QLThuVien";
            this.Text = "Quản lý thư viện sách cá nhân";
            this.Load += new System.EventHandler(this.QLThuVien_Load);
            this.tabControl1.ResumeLayout(false);
            this.tAllBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBooks)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pTypes.ResumeLayout(false);
            this.pTypes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tCategory;
        private System.Windows.Forms.TabPage tBorrowed;
        private System.Windows.Forms.TabPage tBorrowing;
        private System.Windows.Forms.TabPage tAllBooks;
        private System.Windows.Forms.DataGridView dgvAllBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.ListView lvBook;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bSaveBook;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mtbPublishedYear;
        private System.Windows.Forms.ComboBox cbPublisher;
        private System.Windows.Forms.ComboBox cbAuthor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox tbBookName;
        private System.Windows.Forms.Panel pTypes;
        private System.Windows.Forms.RadioButton rbSingleVolume;
        private System.Windows.Forms.RadioButton rbSeries;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bEditCategory;
        private System.Windows.Forms.Button bEditAuthor;
        private System.Windows.Forms.Button bEditPublisher;
    }
}

