namespace BrightKeeper
{
    partial class Master_Location
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.gpData = new System.Windows.Forms.GroupBox();
            this.lbl_Cnt = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpDetail = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.chb_name = new System.Windows.Forms.CheckBox();
            this.chb_id = new System.Windows.Forms.CheckBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gpDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(572, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Barcode Scanner Support Software";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.IndianRed;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "LOCATION MASTER";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(497, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "BRIGHT KEEPER";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.gpData);
            this.panel1.Controls.Add(this.gpDetail);
            this.panel1.Controls.Add(this.chb_name);
            this.panel1.Controls.Add(this.chb_id);
            this.panel1.Controls.Add(this.btn_clear);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(2, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 574);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(397, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Search Condition :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gpData
            // 
            this.gpData.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gpData.Controls.Add(this.lbl_Cnt);
            this.gpData.Controls.Add(this.lblItem);
            this.gpData.Controls.Add(this.btn_select);
            this.gpData.Controls.Add(this.btn_delete);
            this.gpData.Controls.Add(this.btn_new);
            this.gpData.Controls.Add(this.dataGridView1);
            this.gpData.Location = new System.Drawing.Point(3, 122);
            this.gpData.Name = "gpData";
            this.gpData.Size = new System.Drawing.Size(774, 449);
            this.gpData.TabIndex = 18;
            this.gpData.TabStop = false;
            // 
            // lbl_Cnt
            // 
            this.lbl_Cnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Cnt.Location = new System.Drawing.Point(58, 423);
            this.lbl_Cnt.Name = "lbl_Cnt";
            this.lbl_Cnt.Size = new System.Drawing.Size(78, 13);
            this.lbl_Cnt.TabIndex = 21;
            this.lbl_Cnt.Text = "999,999,999";
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblItem.Location = new System.Drawing.Point(0, 423);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(55, 13);
            this.lblItem.TabIndex = 20;
            this.lblItem.Text = "Item :";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(699, 426);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 23);
            this.btn_select.TabIndex = 24;
            this.btn_select.Text = "Select";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(537, 426);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 22;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(618, 426);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 23;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(774, 420);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "LOCATION_ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LOCATION_NAME";
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 240;
            // 
            // gpDetail
            // 
            this.gpDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gpDetail.Controls.Add(this.lblName);
            this.gpDetail.Controls.Add(this.lblID);
            this.gpDetail.Controls.Add(this.txtName);
            this.gpDetail.Controls.Add(this.txtID);
            this.gpDetail.Controls.Add(this.btn_cancel);
            this.gpDetail.Controls.Add(this.btn_save);
            this.gpDetail.Enabled = false;
            this.gpDetail.Location = new System.Drawing.Point(3, 40);
            this.gpDetail.Name = "gpDetail";
            this.gpDetail.Size = new System.Drawing.Size(774, 76);
            this.gpDetail.TabIndex = 11;
            this.gpDetail.TabStop = false;
            this.gpDetail.Text = "Detail";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblName.Location = new System.Drawing.Point(6, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 21);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblID.Location = new System.Drawing.Point(6, 22);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(65, 21);
            this.lblID.TabIndex = 12;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 48);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(266, 20);
            this.txtName.TabIndex = 15;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(77, 22);
            this.txtID.MaxLength = 30;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(150, 20);
            this.txtID.TabIndex = 13;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(693, 47);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(612, 47);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 16;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // chb_name
            // 
            this.chb_name.AutoSize = true;
            this.chb_name.Checked = true;
            this.chb_name.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_name.Location = new System.Drawing.Point(572, 7);
            this.chb_name.Name = "chb_name";
            this.chb_name.Size = new System.Drawing.Size(54, 17);
            this.chb_name.TabIndex = 10;
            this.chb_name.Text = "Name";
            this.chb_name.UseVisualStyleBackColor = true;
            // 
            // chb_id
            // 
            this.chb_id.AutoSize = true;
            this.chb_id.Checked = true;
            this.chb_id.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_id.Location = new System.Drawing.Point(516, 7);
            this.chb_id.Name = "chb_id";
            this.chb_id.Size = new System.Drawing.Size(37, 17);
            this.chb_id.TabIndex = 9;
            this.chb_id.Text = "ID";
            this.chb_id.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(315, 2);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 7;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(234, 2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(227, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_close.Image = global::BrightKeeper.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(662, 639);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(120, 40);
            this.btn_close.TabIndex = 26;
            this.btn_close.Text = "Close";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_excel.Image = global::BrightKeeper.Properties.Resources.Excel;
            this.btn_excel.Location = new System.Drawing.Point(2, 639);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(120, 40);
            this.btn_excel.TabIndex = 35;
            this.btn_excel.Text = "Export";
            this.btn_excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_excel.UseVisualStyleBackColor = false;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.SystemColors.Control;
            this.btn_import.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_import.Image = global::BrightKeeper.Properties.Resources.database;
            this.btn_import.Location = new System.Drawing.Point(536, 639);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(120, 40);
            this.btn_import.TabIndex = 43;
            this.btn_import.Text = "Import";
            this.btn_import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // Master_Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(784, 681);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Master_Location";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRIGHT KEEPER";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gpDetail.ResumeLayout(false);
            this.gpDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.CheckBox chb_name;
        private System.Windows.Forms.CheckBox chb_id;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox gpDetail;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox gpData;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lbl_Cnt;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_import;
    }
}