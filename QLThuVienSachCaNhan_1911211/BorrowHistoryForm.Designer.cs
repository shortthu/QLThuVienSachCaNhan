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
            this.components = new System.ComponentModel.Container();
            this.Label1 = new System.Windows.Forms.Label();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmHistoryRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmHistoryRightClick.SuspendLayout();
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
            // lvHistory
            // 
            this.lvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.GridLines = true;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(17, 37);
            this.lvHistory.MultiSelect = false;
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(546, 569);
            this.lvHistory.TabIndex = 3;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.SelectedIndexChanged += new System.EventHandler(this.lvHistory_SelectedIndexChanged);
            this.lvHistory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvHistory_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên sách";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hình thức";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Người mượn/cho mượn";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số điện thoại mượn";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ngày";
            // 
            // cmHistoryRightClick
            // 
            this.cmHistoryRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delHistoryToolStripMenuItem});
            this.cmHistoryRightClick.Name = "cmHistoryRightClick";
            this.cmHistoryRightClick.Size = new System.Drawing.Size(104, 26);
            // 
            // delHistoryToolStripMenuItem
            // 
            this.delHistoryToolStripMenuItem.Name = "delHistoryToolStripMenuItem";
            this.delHistoryToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.delHistoryToolStripMenuItem.Text = "Xoá...";
            this.delHistoryToolStripMenuItem.Click += new System.EventHandler(this.delHistoryToolStripMenuItem_Click);
            // 
            // BorrowHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 618);
            this.Controls.Add(this.lvHistory);
            this.Controls.Add(this.Label1);
            this.Name = "BorrowHistoryForm";
            this.Text = "Lịch sử mượn";
            this.Load += new System.EventHandler(this.BorrowHistoryForm_Load);
            this.cmHistoryRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip cmHistoryRightClick;
        private System.Windows.Forms.ToolStripMenuItem delHistoryToolStripMenuItem;
    }
}