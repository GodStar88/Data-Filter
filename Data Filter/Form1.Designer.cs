namespace Data_Filter
{
    partial class FrmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.checkBox_Profile = new System.Windows.Forms.CheckBox();
            this.dataGridView_Profile = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Open = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstResultsDGV = new System.Windows.Forms.ListBox();
            this.comboBox_Search = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Profile)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_Profile
            // 
            this.checkBox_Profile.AutoSize = true;
            this.checkBox_Profile.Location = new System.Drawing.Point(17, 17);
            this.checkBox_Profile.Name = "checkBox_Profile";
            this.checkBox_Profile.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Profile.TabIndex = 170;
            this.checkBox_Profile.UseVisualStyleBackColor = true;
            this.checkBox_Profile.Visible = false;
            this.checkBox_Profile.CheckedChanged += new System.EventHandler(this.checkBox_Profile_CheckedChanged);
            // 
            // dataGridView_Profile
            // 
            this.dataGridView_Profile.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_Profile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Profile.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Profile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Profile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Profile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Name,
            this.Title,
            this.Service,
            this.Email1,
            this.Email2,
            this.Email3,
            this.Phone1,
            this.Phone2,
            this.Phone3,
            this.Website});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Profile.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Profile.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Profile.Name = "dataGridView_Profile";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Profile.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Profile.RowHeadersVisible = false;
            this.dataGridView_Profile.RowHeadersWidth = 20;
            this.dataGridView_Profile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Profile.Size = new System.Drawing.Size(1160, 608);
            this.dataGridView_Profile.TabIndex = 169;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 30;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.Width = 130;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.FillWeight = 200F;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.Width = 170;
            // 
            // Service
            // 
            this.Service.DataPropertyName = "Service";
            this.Service.HeaderText = "Service";
            this.Service.Name = "Service";
            // 
            // Email1
            // 
            this.Email1.DataPropertyName = "Email1";
            this.Email1.HeaderText = "Email1";
            this.Email1.Name = "Email1";
            this.Email1.Width = 120;
            // 
            // Email2
            // 
            this.Email2.DataPropertyName = "Email2";
            this.Email2.HeaderText = "Email2";
            this.Email2.Name = "Email2";
            this.Email2.Width = 120;
            // 
            // Email3
            // 
            this.Email3.DataPropertyName = "Email3";
            this.Email3.HeaderText = "Email3";
            this.Email3.Name = "Email3";
            // 
            // Phone1
            // 
            this.Phone1.DataPropertyName = "Phone1";
            this.Phone1.HeaderText = "Phone1";
            this.Phone1.Name = "Phone1";
            this.Phone1.Width = 80;
            // 
            // Phone2
            // 
            this.Phone2.DataPropertyName = "Phone2";
            this.Phone2.HeaderText = "Phone2";
            this.Phone2.Name = "Phone2";
            this.Phone2.Width = 80;
            // 
            // Phone3
            // 
            this.Phone3.DataPropertyName = "Phone3";
            this.Phone3.HeaderText = "Phone3";
            this.Phone3.Name = "Phone3";
            this.Phone3.Width = 80;
            // 
            // Website
            // 
            this.Website.DataPropertyName = "Website";
            this.Website.FillWeight = 130F;
            this.Website.HeaderText = "Website";
            this.Website.Name = "Website";
            this.Website.Width = 150;
            // 
            // Btn_Open
            // 
            this.Btn_Open.Location = new System.Drawing.Point(714, 629);
            this.Btn_Open.Name = "Btn_Open";
            this.Btn_Open.Size = new System.Drawing.Size(75, 23);
            this.Btn_Open.TabIndex = 171;
            this.Btn_Open.Text = "Open";
            this.Btn_Open.UseVisualStyleBackColor = true;
            this.Btn_Open.Click += new System.EventHandler(this.Btn_Open_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(807, 629);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(75, 23);
            this.Btn_Save.TabIndex = 172;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Location = new System.Drawing.Point(900, 629);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.Btn_Delete.TabIndex = 173;
            this.Btn_Delete.Text = "Delete";
            this.Btn_Delete.UseVisualStyleBackColor = true;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(430, 630);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(170, 20);
            this.textBox_Search.TabIndex = 174;
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(621, 629);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 23);
            this.Btn_Search.TabIndex = 175;
            this.Btn_Search.Text = "Search";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 634);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 176;
            // 
            // lstResultsDGV
            // 
            this.lstResultsDGV.FormattingEnabled = true;
            this.lstResultsDGV.Location = new System.Drawing.Point(757, 45);
            this.lstResultsDGV.Name = "lstResultsDGV";
            this.lstResultsDGV.Size = new System.Drawing.Size(393, 95);
            this.lstResultsDGV.TabIndex = 177;
            this.lstResultsDGV.Visible = false;
            // 
            // comboBox_Search
            // 
            this.comboBox_Search.FormattingEnabled = true;
            this.comboBox_Search.Items.AddRange(new object[] {
            "Name",
            "Title",
            "Service",
            "Email",
            "Phone",
            "Website"});
            this.comboBox_Search.Location = new System.Drawing.Point(276, 629);
            this.comboBox_Search.Name = "comboBox_Search";
            this.comboBox_Search.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Search.TabIndex = 178;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.comboBox_Search);
            this.Controls.Add(this.lstResultsDGV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.Btn_Delete);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Open);
            this.Controls.Add(this.checkBox_Profile);
            this.Controls.Add(this.dataGridView_Profile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            // this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Filter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Profile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Profile;
        private System.Windows.Forms.DataGridView dataGridView_Profile;
        private System.Windows.Forms.Button Btn_Open;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstResultsDGV;
        private System.Windows.Forms.ComboBox comboBox_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Website;
    }
}

