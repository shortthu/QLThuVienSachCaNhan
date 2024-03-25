namespace QLThuVienSachCaNhan_1911211
{
    partial class BorrowHistoryForm
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
            this.Label1 = new System.Windows.Forms.Label();
            this.lvBorrowed = new System.Windows.Forms.ListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(128, 25);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Lịch sử mượn";
            // 
            // lvBorrowed
            // 
            this.lvBorrowed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBorrowed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26});
            this.lvBorrowed.FullRowSelect = true;
            this.lvBorrowed.GridLines = true;
            this.lvBorrowed.HideSelection = false;
            this.lvBorrowed.Location = new System.Drawing.Point(17, 37);
            this.lvBorrowed.MultiSelect = false;
            this.lvBorrowed.Name = "lvBorrowed";
            this.lvBorrowed.Size = new System.Drawing.Size(546, 569);
            this.lvBorrowed.TabIndex = 3;
            this.lvBorrowed.UseCompatibleStateImageBehavior = false;
            this.lvBorrowed.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "STT";
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Tên sách";
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Hình thức";
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Người mượn/cho mượn";
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Số điện thoại mượn";
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Ngày";
            // 
            // BorrowHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 618);
            this.Controls.Add(this.lvBorrowed);
            this.Controls.Add(this.Label1);
            this.Name = "BorrowHistoryForm";
            this.Text = "Lịch sử mượn";
            this.Load += new System.EventHandler(this.BorrowHistoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ListView lvBorrowed;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
    }
}