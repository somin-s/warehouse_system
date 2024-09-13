namespace BrightKeeper
{
    partial class Manual_Input
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
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Move = new System.Windows.Forms.Button();
            this.btn_Iss = new System.Windows.Forms.Button();
            this.btn_Rec = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(365, 6);
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
            this.label3.Size = new System.Drawing.Size(269, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "MANUAL INPUT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(287, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "BRIGHT KEEPER";
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_close.Image = global::BrightKeeper.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(452, 327);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(120, 40);
            this.btn_close.TabIndex = 9;
            this.btn_close.Text = "Close";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btn_Move);
            this.panel1.Controls.Add(this.btn_Iss);
            this.panel1.Controls.Add(this.btn_Rec);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(2, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 262);
            this.panel1.TabIndex = 4;
            // 
            // btn_Move
            // 
            this.btn_Move.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Move.Location = new System.Drawing.Point(164, 188);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(240, 37);
            this.btn_Move.TabIndex = 8;
            this.btn_Move.Text = "Move Stock Manual Input";
            this.btn_Move.UseVisualStyleBackColor = false;
            this.btn_Move.Click += new System.EventHandler(this.btn_Move_Click);
            // 
            // btn_Iss
            // 
            this.btn_Iss.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Iss.Location = new System.Drawing.Point(164, 131);
            this.btn_Iss.Name = "btn_Iss";
            this.btn_Iss.Size = new System.Drawing.Size(240, 37);
            this.btn_Iss.TabIndex = 7;
            this.btn_Iss.Text = "Issue Stock Manual Input";
            this.btn_Iss.UseVisualStyleBackColor = false;
            this.btn_Iss.Click += new System.EventHandler(this.btn_Iss_Click);
            // 
            // btn_Rec
            // 
            this.btn_Rec.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Rec.Location = new System.Drawing.Point(164, 75);
            this.btn_Rec.Name = "btn_Rec";
            this.btn_Rec.Size = new System.Drawing.Size(240, 37);
            this.btn_Rec.TabIndex = 6;
            this.btn_Rec.Text = "Receive Stock Manual Input";
            this.btn_Rec.UseVisualStyleBackColor = false;
            this.btn_Rec.Click += new System.EventHandler(this.btn_Rec_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(52, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(464, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Please select your work type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Manual_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(578, 376);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Manual_Input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRIGHT KEEPER";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.Button btn_Iss;
        private System.Windows.Forms.Button btn_Rec;
    }
}