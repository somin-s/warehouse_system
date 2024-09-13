﻿namespace BKHandy
{
    partial class InputLocation2
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
            this.btn_menu = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.lbl_location = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lbl_F2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_menu
            // 
            this.btn_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_menu.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btn_menu.Location = new System.Drawing.Point(15, 472);
            this.btn_menu.Name = "btn_menu";
            this.btn_menu.Size = new System.Drawing.Size(150, 54);
            this.btn_menu.TabIndex = 2;
            this.btn_menu.Text = "[F1] MENU";
            this.btn_menu.Click += new System.EventHandler(this.btn_menu_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(478, 41);
            this.lblTitle.Text = "RECEIVE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_back.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btn_back.Location = new System.Drawing.Point(310, 472);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(150, 54);
            this.btn_back.TabIndex = 3;
            this.btn_back.Text = "[F4] BACK";
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMessage.Enabled = false;
            this.txtMessage.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.txtMessage.Location = new System.Drawing.Point(20, 44);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(440, 90);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.TabStop = false;
            this.txtMessage.Text = "Please read a barcode or input Destination Location Code";
            // 
            // txtScan
            // 
            this.txtScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtScan.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.txtScan.Location = new System.Drawing.Point(32, 201);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(415, 39);
            this.txtScan.TabIndex = 1;
            // 
            // lbl_location
            // 
            this.lbl_location.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.lbl_location.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lbl_location.ForeColor = System.Drawing.Color.Black;
            this.lbl_location.Location = new System.Drawing.Point(20, 158);
            this.lbl_location.Name = "lbl_location";
            this.lbl_location.Size = new System.Drawing.Size(225, 40);
            this.lbl_location.Text = "Destination";
            this.lbl_location.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOperator
            // 
            this.lblOperator.BackColor = System.Drawing.Color.White;
            this.lblOperator.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.lblOperator.Location = new System.Drawing.Point(161, 347);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(300, 30);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(15, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 30);
            this.label1.Text = "Operator :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(15, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 30);
            this.label2.Text = "Location :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.Color.White;
            this.lblLocation.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.lblLocation.Location = new System.Drawing.Point(161, 386);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(300, 30);
            // 
            // lbl_F2
            // 
            this.lbl_F2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.lbl_F2.Location = new System.Drawing.Point(173, 478);
            this.lbl_F2.Name = "lbl_F2";
            this.lbl_F2.Size = new System.Drawing.Size(126, 43);
            this.lbl_F2.Text = "[F2] Log";
            this.lbl_F2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InputLocation2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(478, 615);
            this.Controls.Add(this.lbl_F2);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.lbl_location);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_menu);
            this.Controls.Add(this.lblTitle);
            this.KeyPreview = true;
            this.Name = "InputLocation2";
            this.Text = "BRIGHT KEEPER";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closed += new System.EventHandler(this.MainForm_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_menu;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.TextBox txtMessage;
        internal System.Windows.Forms.TextBox txtScan;
        internal System.Windows.Forms.Label lbl_location;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lbl_F2;
    }
}

