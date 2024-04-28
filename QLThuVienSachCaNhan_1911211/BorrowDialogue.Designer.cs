namespace QLThuVienSachCaNhan_1911211
{
    partial class BorrowDialogue
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
            this.cbName = new System.Windows.Forms.ComboBox();
            this.bEditBorrow = new System.Windows.Forms.Button();
            this.tbPhoneNum = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bConfirm = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBookID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBookName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbName
            // 
            this.cbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(88, 59);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(261, 21);
            this.cbName.TabIndex = 2;
            this.cbName.SelectedValueChanged += new System.EventHandler(this.cbName_SelectedValueChanged);
            // 
            // bEditBorrow
            // 
            this.bEditBorrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bEditBorrow.Location = new System.Drawing.Point(355, 57);
            this.bEditBorrow.Name = "bEditBorrow";
            this.bEditBorrow.Size = new System.Drawing.Size(24, 23);
            this.bEditBorrow.TabIndex = 4;
            this.bEditBorrow.Text = "+";
            this.bEditBorrow.UseVisualStyleBackColor = true;
            this.bEditBorrow.Click += new System.EventHandler(this.bEditBorrow_Click);
            // 
            // tbPhoneNum
            // 
            this.tbPhoneNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhoneNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPhoneNum.Location = new System.Drawing.Point(88, 86);
            this.tbPhoneNum.Name = "tbPhoneNum";
            this.tbPhoneNum.ReadOnly = true;
            this.tbPhoneNum.Size = new System.Drawing.Size(291, 13);
            this.tbPhoneNum.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Số điện thoại";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Tên";
            // 
            // bConfirm
            // 
            this.bConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bConfirm.Location = new System.Drawing.Point(304, 112);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(75, 23);
            this.bConfirm.TabIndex = 6;
            this.bConfirm.Text = "OK";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(223, 112);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Huỷ";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "ID sách";
            // 
            // tbBookID
            // 
            this.tbBookID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBookID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBookID.Location = new System.Drawing.Point(88, 7);
            this.tbBookID.Name = "tbBookID";
            this.tbBookID.ReadOnly = true;
            this.tbBookID.Size = new System.Drawing.Size(291, 13);
            this.tbBookID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Tên sách";
            // 
            // tbBookName
            // 
            this.tbBookName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBookName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBookName.Location = new System.Drawing.Point(88, 33);
            this.tbBookName.Name = "tbBookName";
            this.tbBookName.ReadOnly = true;
            this.tbBookName.Size = new System.Drawing.Size(291, 13);
            this.tbBookName.TabIndex = 1;
            // 
            // BorrowDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 145);
            this.Controls.Add(this.tbBookName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBookID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bConfirm);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.bEditBorrow);
            this.Controls.Add(this.tbPhoneNum);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Name = "BorrowDialogue";
            this.Text = "Mượn";
            this.Load += new System.EventHandler(this.BorrowDialogue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Button bEditBorrow;
        private System.Windows.Forms.TextBox tbPhoneNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bConfirm;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBookID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBookName;
    }
}