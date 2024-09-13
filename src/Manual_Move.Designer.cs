namespace BrightKeeper
{
    partial class Manual_Move
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
            this.gpDetail = new System.Windows.Forms.GroupBox();
            this.ut_date = new ProManApp.UltraDateTimePicker();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_location2 = new System.Windows.Forms.ComboBox();
            this.cmb_location = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_worker = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ut_date)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(484, 6);
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
            this.label3.Size = new System.Drawing.Size(240, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "MOVE STOCK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(409, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "BRIGHT KEEPER";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.gpDetail);
            this.panel1.Location = new System.Drawing.Point(2, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 287);
            this.panel1.TabIndex = 4;
            // 
            // gpDetail
            // 
            this.gpDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gpDetail.Controls.Add(this.ut_date);
            this.gpDetail.Controls.Add(this.txtLot);
            this.gpDetail.Controls.Add(this.label8);
            this.gpDetail.Controls.Add(this.groupBox1);
            this.gpDetail.Controls.Add(this.txtItemName);
            this.gpDetail.Controls.Add(this.txtItemID);
            this.gpDetail.Controls.Add(this.btn_search);
            this.gpDetail.Controls.Add(this.txt_qty);
            this.gpDetail.Controls.Add(this.txt_remark);
            this.gpDetail.Controls.Add(this.label10);
            this.gpDetail.Controls.Add(this.label9);
            this.gpDetail.Controls.Add(this.label11);
            this.gpDetail.Controls.Add(this.label7);
            this.gpDetail.Controls.Add(this.cmb_worker);
            this.gpDetail.Controls.Add(this.label5);
            this.gpDetail.Controls.Add(this.label4);
            this.gpDetail.Location = new System.Drawing.Point(3, 3);
            this.gpDetail.Name = "gpDetail";
            this.gpDetail.Size = new System.Drawing.Size(686, 281);
            this.gpDetail.TabIndex = 5;
            this.gpDetail.TabStop = false;
            // 
            // ut_date
            // 
            this.ut_date.CustomFormat = "yyyy/MM/dd   HH:mm";
            this.ut_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ut_date.Location = new System.Drawing.Point(110, 17);
            this.ut_date.Name = "ut_date";
            this.ut_date.Size = new System.Drawing.Size(137, 20);
            this.ut_date.TabIndex = 7;
            this.ut_date.Value = new System.DateTime(2015, 6, 29, 0, 0, 0, 0);
            // 
            // txtLot
            // 
            this.txtLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLot.Location = new System.Drawing.Point(109, 183);
            this.txtLot.MaxLength = 30;
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(172, 20);
            this.txtLot.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(2, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 21);
            this.label8.TabIndex = 20;
            this.label8.Text = "Lot";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.cmb_location2);
            this.groupBox1.Controls.Add(this.cmb_location);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(14, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 51);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // cmb_location2
            // 
            this.cmb_location2.BackColor = System.Drawing.Color.White;
            this.cmb_location2.FormattingEnabled = true;
            this.cmb_location2.Location = new System.Drawing.Point(357, 19);
            this.cmb_location2.Name = "cmb_location2";
            this.cmb_location2.Size = new System.Drawing.Size(174, 21);
            this.cmb_location2.TabIndex = 14;
            // 
            // cmb_location
            // 
            this.cmb_location.BackColor = System.Drawing.Color.White;
            this.cmb_location.FormattingEnabled = true;
            this.cmb_location.Location = new System.Drawing.Point(96, 19);
            this.cmb_location.Name = "cmb_location";
            this.cmb_location.Size = new System.Drawing.Size(174, 21);
            this.cmb_location.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(279, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 21);
            this.label12.TabIndex = 13;
            this.label12.Text = "To";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "From";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemName
            // 
            this.txtItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtItemName.Location = new System.Drawing.Point(371, 146);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(309, 20);
            this.txtItemName.TabIndex = 18;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // txtItemID
            // 
            this.txtItemID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtItemID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtItemID.Location = new System.Drawing.Point(110, 145);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(172, 20);
            this.txtItemID.TabIndex = 16;
            this.txtItemID.TextChanged += new System.EventHandler(this.txtItemID_TextChanged);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(568, 167);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(111, 23);
            this.btn_search.TabIndex = 19;
            this.btn_search.Text = "Item Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_qty
            // 
            this.txt_qty.BackColor = System.Drawing.Color.White;
            this.txt_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_qty.Location = new System.Drawing.Point(568, 236);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(112, 29);
            this.txt_qty.TabIndex = 25;
            this.txt_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_remark
            // 
            this.txt_remark.BackColor = System.Drawing.Color.White;
            this.txt_remark.Location = new System.Drawing.Point(109, 236);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(387, 20);
            this.txt_remark.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(502, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 21);
            this.label10.TabIndex = 24;
            this.label10.Text = "Qty";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(3, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "Remark";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(288, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 21);
            this.label11.TabIndex = 17;
            this.label11.Text = "Item Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(3, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "Item ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_worker
            // 
            this.cmb_worker.BackColor = System.Drawing.Color.White;
            this.cmb_worker.FormattingEnabled = true;
            this.cmb_worker.Location = new System.Drawing.Point(109, 43);
            this.cmb_worker.Name = "cmb_worker";
            this.cmb_worker.Size = new System.Drawing.Size(174, 21);
            this.cmb_worker.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(3, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Person in charge";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(2, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_save.Image = global::BrightKeeper.Properties.Resources.database;
            this.btn_save.Location = new System.Drawing.Point(448, 352);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(120, 40);
            this.btn_save.TabIndex = 26;
            this.btn_save.Text = "Save";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_close.Image = global::BrightKeeper.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(574, 352);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(120, 40);
            this.btn_close.TabIndex = 27;
            this.btn_close.Text = "Close";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Manual_Move
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(696, 395);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Manual_Move";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRIGHT KEEPER";
            this.panel1.ResumeLayout(false);
            this.gpDetail.ResumeLayout(false);
            this.gpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ut_date)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.GroupBox gpDetail;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cmb_worker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_location;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_location2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.Label label8;
        private ProManApp.UltraDateTimePicker ut_date;
    }
}