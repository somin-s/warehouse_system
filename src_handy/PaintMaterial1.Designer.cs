namespace BKHandy
{
    partial class PaintMaterial1
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
            this.txtRequestNo = new System.Windows.Forms.TextBox();
            this.lbl_operator = new System.Windows.Forms.Label();
            this.lbl_F2 = new System.Windows.Forms.Label();
            this.txtRequester = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaterialType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_menu
            // 
            this.btn_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_menu.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btn_menu.Location = new System.Drawing.Point(20, 472);
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
            this.lblTitle.Text = "Paint Material 1st";
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
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMessage.Enabled = false;
            this.txtMessage.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.txtMessage.Location = new System.Drawing.Point(20, 44);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(440, 90);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.TabStop = false;
            this.txtMessage.Text = "Must read a barcode or input all data item!";
            // 
            // txtRequestNo
            // 
            this.txtRequestNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRequestNo.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.txtRequestNo.Location = new System.Drawing.Point(185, 164);
            this.txtRequestNo.Name = "txtRequestNo";
            this.txtRequestNo.Size = new System.Drawing.Size(275, 39);
            this.txtRequestNo.TabIndex = 1;
            // 
            // lbl_operator
            // 
            this.lbl_operator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.lbl_operator.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_operator.ForeColor = System.Drawing.Color.Black;
            this.lbl_operator.Location = new System.Drawing.Point(3, 164);
            this.lbl_operator.Name = "lbl_operator";
            this.lbl_operator.Size = new System.Drawing.Size(176, 39);
            this.lbl_operator.Text = "Request No.";
            this.lbl_operator.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_F2
            // 
            this.lbl_F2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.lbl_F2.Location = new System.Drawing.Point(176, 479);
            this.lbl_F2.Name = "lbl_F2";
            this.lbl_F2.Size = new System.Drawing.Size(126, 43);
            this.lbl_F2.Text = "[F2] Log";
            this.lbl_F2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRequester
            // 
            this.txtRequester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRequester.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.txtRequester.Location = new System.Drawing.Point(185, 226);
            this.txtRequester.Name = "txtRequester";
            this.txtRequester.Size = new System.Drawing.Size(275, 39);
            this.txtRequester.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 39);
            this.label1.Text = "Requester";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPlant
            // 
            this.txtPlant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPlant.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.txtPlant.Location = new System.Drawing.Point(185, 292);
            this.txtPlant.Name = "txtPlant";
            this.txtPlant.Size = new System.Drawing.Size(275, 39);
            this.txtPlant.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 39);
            this.label2.Text = "Plant";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaterialName.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.txtMaterialName.Location = new System.Drawing.Point(185, 410);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(275, 39);
            this.txtMaterialName.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 39);
            this.label3.Text = "Material Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMaterialType
            // 
            this.txtMaterialType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaterialType.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.txtMaterialType.Location = new System.Drawing.Point(185, 348);
            this.txtMaterialType.Name = "txtMaterialType";
            this.txtMaterialType.Size = new System.Drawing.Size(275, 39);
            this.txtMaterialType.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 39);
            this.label4.Text = "Material Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PaintMaterial1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(478, 615);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaterialType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPlant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRequester);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_F2);
            this.Controls.Add(this.txtRequestNo);
            this.Controls.Add(this.lbl_operator);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_menu);
            this.Controls.Add(this.lblTitle);
            this.KeyPreview = true;
            this.Name = "PaintMaterial1";
            this.Text = "Receive Product";
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
        internal System.Windows.Forms.TextBox txtRequestNo;
        internal System.Windows.Forms.Label lbl_operator;
        private System.Windows.Forms.Label lbl_F2;
        internal System.Windows.Forms.TextBox txtRequester;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtPlant;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtMaterialName;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtMaterialType;
        internal System.Windows.Forms.Label label4;
    }
}