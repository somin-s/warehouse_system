namespace BKHandy
{
    partial class MainForm
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
            this.btn_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_menu1 = new System.Windows.Forms.Button();
            this.btn_menu2 = new System.Windows.Forms.Button();
            this.btn_menu3 = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblTerminal = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_close.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btn_close.Location = new System.Drawing.Point(15, 479);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(195, 54);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "[F1] CLOSE";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 92);
            this.label1.Text = "Product Control";
            // 
            // btn_menu1
            // 
            this.btn_menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_menu1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btn_menu1.Location = new System.Drawing.Point(96, 210);
            this.btn_menu1.Name = "btn_menu1";
            this.btn_menu1.Size = new System.Drawing.Size(287, 49);
            this.btn_menu1.TabIndex = 1;
            this.btn_menu1.Text = "1. Part Test";
            this.btn_menu1.Click += new System.EventHandler(this.btn_menu1_Click);
            // 
            // btn_menu2
            // 
            this.btn_menu2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_menu2.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btn_menu2.Location = new System.Drawing.Point(96, 274);
            this.btn_menu2.Name = "btn_menu2";
            this.btn_menu2.Size = new System.Drawing.Size(287, 49);
            this.btn_menu2.TabIndex = 2;
            this.btn_menu2.Text = "2. Paint Meterial";
            this.btn_menu2.Click += new System.EventHandler(this.btn_menu2_Click);
            // 
            // btn_menu3
            // 
            this.btn_menu3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_menu3.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btn_menu3.Location = new System.Drawing.Point(95, 339);
            this.btn_menu3.Name = "btn_menu3";
            this.btn_menu3.Size = new System.Drawing.Size(287, 49);
            this.btn_menu3.TabIndex = 3;
            this.btn_menu3.Text = "3. Test Panel";
            this.btn_menu3.Click += new System.EventHandler(this.btn_menu3_Click);
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_send.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btn_send.Location = new System.Drawing.Point(265, 479);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(195, 54);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "[F4] SEND";
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lblVersion.Location = new System.Drawing.Point(381, 62);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(94, 27);
            this.lblVersion.Text = "Ver. 1.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTerminal
            // 
            this.lblTerminal.BackColor = System.Drawing.Color.White;
            this.lblTerminal.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lblTerminal.Location = new System.Drawing.Point(3, 103);
            this.lblTerminal.Name = "lblTerminal";
            this.lblTerminal.Size = new System.Drawing.Size(139, 27);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(96, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(287, 49);
            this.button1.TabIndex = 10;
            this.button1.Text = "4. Setting";
            this.button1.Click += new System.EventHandler(this.btn_menu5_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.radioButton2.Location = new System.Drawing.Point(232, 144);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(120, 35);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = false;
            this.radioButton2.Text = "Issue";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.radioButton1.Location = new System.Drawing.Point(99, 144);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(111, 35);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.Text = "Recieve";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(478, 615);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTerminal);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_menu3);
            this.Controls.Add(this.btn_menu2);
            this.Controls.Add(this.btn_menu1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Bright Keeper & Co.";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closed += new System.EventHandler(this.MainForm_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_menu1;
        private System.Windows.Forms.Button btn_menu2;
        private System.Windows.Forms.Button btn_menu3;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblTerminal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

