namespace BrightKeeper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ManualInput = new System.Windows.Forms.Button();
            this.btn_Inventory = new System.Windows.Forms.Button();
            this.btn_DataLog = new System.Windows.Forms.Button();
            this.btn_DataView = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_SystemMain = new System.Windows.Forms.Button();
            this.btn_MasterMain = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbb_Lang = new System.Windows.Forms.ComboBox();
            this.rdb_Confirmed = new System.Windows.Forms.RadioButton();
            this.rdb_NotCinfirm = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(717, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "STORE IN OUT(Bright Keeper)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(38, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Barcode Scanner Support Software";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_ManualInput);
            this.panel2.Controls.Add(this.btn_Inventory);
            this.panel2.Controls.Add(this.btn_DataLog);
            this.panel2.Controls.Add(this.btn_DataView);
            this.panel2.Location = new System.Drawing.Point(446, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 106);
            this.panel2.TabIndex = 8;
            // 
            // btn_ManualInput
            // 
            this.btn_ManualInput.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ManualInput.Location = new System.Drawing.Point(210, 56);
            this.btn_ManualInput.Name = "btn_ManualInput";
            this.btn_ManualInput.Size = new System.Drawing.Size(135, 37);
            this.btn_ManualInput.TabIndex = 12;
            this.btn_ManualInput.Text = "Manual Input";
            this.btn_ManualInput.UseVisualStyleBackColor = false;
            this.btn_ManualInput.Click += new System.EventHandler(this.btn_ManualInput_Click);
            // 
            // btn_Inventory
            // 
            this.btn_Inventory.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Inventory.Location = new System.Drawing.Point(45, 56);
            this.btn_Inventory.Name = "btn_Inventory";
            this.btn_Inventory.Size = new System.Drawing.Size(135, 37);
            this.btn_Inventory.TabIndex = 11;
            this.btn_Inventory.Text = "Inventory Stock";
            this.btn_Inventory.UseVisualStyleBackColor = false;
            this.btn_Inventory.Click += new System.EventHandler(this.btn_Inventory_Click);
            // 
            // btn_DataLog
            // 
            this.btn_DataLog.BackColor = System.Drawing.SystemColors.Control;
            this.btn_DataLog.Location = new System.Drawing.Point(210, 13);
            this.btn_DataLog.Name = "btn_DataLog";
            this.btn_DataLog.Size = new System.Drawing.Size(135, 37);
            this.btn_DataLog.TabIndex = 10;
            this.btn_DataLog.Text = "Handy Data Log";
            this.btn_DataLog.UseVisualStyleBackColor = false;
            this.btn_DataLog.Click += new System.EventHandler(this.btn_DataLog_Click);
            // 
            // btn_DataView
            // 
            this.btn_DataView.BackColor = System.Drawing.SystemColors.Control;
            this.btn_DataView.Location = new System.Drawing.Point(45, 13);
            this.btn_DataView.Name = "btn_DataView";
            this.btn_DataView.Size = new System.Drawing.Size(135, 37);
            this.btn_DataView.TabIndex = 9;
            this.btn_DataView.Text = "Stock Data View";
            this.btn_DataView.UseVisualStyleBackColor = false;
            this.btn_DataView.Click += new System.EventHandler(this.btn_DataView_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(446, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stock Management";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_SystemMain);
            this.panel3.Controls.Add(this.btn_MasterMain);
            this.panel3.Location = new System.Drawing.Point(446, 284);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(393, 69);
            this.panel3.TabIndex = 14;
            // 
            // btn_SystemMain
            // 
            this.btn_SystemMain.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SystemMain.Location = new System.Drawing.Point(210, 14);
            this.btn_SystemMain.Name = "btn_SystemMain";
            this.btn_SystemMain.Size = new System.Drawing.Size(135, 37);
            this.btn_SystemMain.TabIndex = 16;
            this.btn_SystemMain.Text = "System Maintenance";
            this.btn_SystemMain.UseVisualStyleBackColor = false;
            this.btn_SystemMain.Click += new System.EventHandler(this.btn_SystemMain_Click);
            // 
            // btn_MasterMain
            // 
            this.btn_MasterMain.BackColor = System.Drawing.SystemColors.Control;
            this.btn_MasterMain.Location = new System.Drawing.Point(45, 14);
            this.btn_MasterMain.Name = "btn_MasterMain";
            this.btn_MasterMain.Size = new System.Drawing.Size(135, 37);
            this.btn_MasterMain.TabIndex = 15;
            this.btn_MasterMain.Text = "Master Maintenance";
            this.btn_MasterMain.UseVisualStyleBackColor = false;
            this.btn_MasterMain.Click += new System.EventHandler(this.btn_MasterMain_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(446, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Maintenance";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(2, 390);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(840, 209);
            this.dataGridView1.TabIndex = 19;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DESC";
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ITEM_ID";
            this.Column1.HeaderText = "Item ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ITEM_NAME";
            this.Column3.HeaderText = "Item Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "QTY";
            this.Column4.HeaderText = "Current Qty";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ORDER_POINT";
            this.Column5.HeaderText = "Order Point";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(787, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ver. 1.0";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Linen;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.cbb_Lang);
            this.panel4.Controls.Add(this.rdb_Confirmed);
            this.panel4.Controls.Add(this.rdb_NotCinfirm);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btn_Confirm);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(854, 633);
            this.panel4.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(692, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Language :";
            this.label7.Visible = false;
            // 
            // cbb_Lang
            // 
            this.cbb_Lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Lang.FormattingEnabled = true;
            this.cbb_Lang.Items.AddRange(new object[] {
            "English",
            "Japanese",
            "Thai"});
            this.cbb_Lang.Location = new System.Drawing.Point(756, 4);
            this.cbb_Lang.Name = "cbb_Lang";
            this.cbb_Lang.Size = new System.Drawing.Size(88, 21);
            this.cbb_Lang.TabIndex = 6;
            this.cbb_Lang.Visible = false;
            this.cbb_Lang.SelectedIndexChanged += new System.EventHandler(this.cbb_Lang_SelectedIndexChanged);
            // 
            // rdb_Confirmed
            // 
            this.rdb_Confirmed.AutoSize = true;
            this.rdb_Confirmed.Location = new System.Drawing.Point(87, 367);
            this.rdb_Confirmed.Name = "rdb_Confirmed";
            this.rdb_Confirmed.Size = new System.Drawing.Size(72, 17);
            this.rdb_Confirmed.TabIndex = 18;
            this.rdb_Confirmed.Text = "Confirmed";
            this.rdb_Confirmed.UseVisualStyleBackColor = true;
            // 
            // rdb_NotCinfirm
            // 
            this.rdb_NotCinfirm.AutoSize = true;
            this.rdb_NotCinfirm.Checked = true;
            this.rdb_NotCinfirm.Location = new System.Drawing.Point(8, 367);
            this.rdb_NotCinfirm.Name = "rdb_NotCinfirm";
            this.rdb_NotCinfirm.Size = new System.Drawing.Size(80, 17);
            this.rdb_NotCinfirm.TabIndex = 17;
            this.rdb_NotCinfirm.TabStop = true;
            this.rdb_NotCinfirm.Text = "Not Confirm";
            this.rdb_NotCinfirm.UseVisualStyleBackColor = true;
            this.rdb_NotCinfirm.CheckedChanged += new System.EventHandler(this.rdb_NotCinfirm_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BrightKeeper.Properties.Resources.TopImage;
            this.pictureBox1.Location = new System.Drawing.Point(18, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 260);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(2, 605);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 20;
            this.btn_Confirm.Text = "Confirm";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_close.Image = global::BrightKeeper.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(735, 640);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(120, 40);
            this.btn_close.TabIndex = 22;
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
            this.btn_excel.Location = new System.Drawing.Point(1, 640);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(120, 40);
            this.btn_excel.TabIndex = 21;
            this.btn_excel.Text = "Export";
            this.btn_excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_excel.UseVisualStyleBackColor = false;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(856, 681);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRIGHT KEEPER for Barcode Scanner Support";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_DataLog;
        private System.Windows.Forms.Button btn_DataView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_MasterMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdb_Confirmed;
        private System.Windows.Forms.RadioButton rdb_NotCinfirm;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_ManualInput;
        private System.Windows.Forms.Button btn_Inventory;
        private System.Windows.Forms.Button btn_SystemMain;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ComboBox cbb_Lang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}

