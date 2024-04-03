namespace QLThuVienSachCaNhan_1911211
{
    partial class OtherStuffManagement
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
            this.lbList = new System.Windows.Forms.ListBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.lID = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbProp1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.tbProp2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbList
            // 
            this.lbList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbList.FormattingEnabled = true;
            this.lbList.Location = new System.Drawing.Point(12, 37);
            this.lbList.Name = "lbList";
            this.lbList.Size = new System.Drawing.Size(206, 212);
            this.lbList.TabIndex = 0;
            this.lbList.SelectedIndexChanged += new System.EventHandler(this.lbList_SelectedIndexChanged);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(12, 9);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(64, 25);
            this.lTitle.TabIndex = 1;
            this.lTitle.Text = "label1";
            // 
            // lID
            // 
            this.lID.AutoSize = true;
            this.lID.Location = new System.Drawing.Point(224, 37);
            this.lID.Name = "lID";
            this.lID.Size = new System.Drawing.Size(18, 13);
            this.lID.TabIndex = 3;
            this.lID.Text = "ID";
            // 
            // tbID
            // 
            this.tbID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbID.Location = new System.Drawing.Point(329, 34);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(215, 20);
            this.tbID.TabIndex = 1;
            // 
            // tbProp1
            // 
            this.tbProp1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProp1.Location = new System.Drawing.Point(329, 60);
            this.tbProp1.Name = "tbProp1";
            this.tbProp1.Size = new System.Drawing.Size(215, 20);
            this.tbProp1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSave.Location = new System.Drawing.Point(389, 226);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 6;
            this.bSave.Text = "Lưu";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bDelete
            // 
            this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDelete.ForeColor = System.Drawing.Color.Red;
            this.bDelete.Location = new System.Drawing.Point(308, 226);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 5;
            this.bDelete.Text = "Xoá";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // tbProp2
            // 
            this.tbProp2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProp2.Location = new System.Drawing.Point(329, 86);
            this.tbProp2.Name = "tbProp2";
            this.tbProp2.Size = new System.Drawing.Size(215, 20);
            this.tbProp2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // bNew
            // 
            this.bNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bNew.Location = new System.Drawing.Point(227, 226);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 23);
            this.bNew.TabIndex = 4;
            this.bNew.Text = "Mới";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // OtherStuffManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 261);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.tbProp2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbProp1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.lID);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lbList);
            this.MinimumSize = new System.Drawing.Size(572, 300);
            this.Name = "OtherStuffManagement";
            this.Text = "Quản lý";
            this.Load += new System.EventHandler(this.OtherStuffManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbList;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbProp1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.TextBox tbProp2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bNew;
    }
}