namespace BrightKeeper
{
    partial class MasterMain
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
            this.label3 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_unit = new System.Windows.Forms.Button();
            this.btn_currency = new System.Windows.Forms.Button();
            this.btn_Item = new System.Windows.Forms.Button();
            this.btn_vendor = new System.Windows.Forms.Button();
            this.btn_Customer = new System.Windows.Forms.Button();
            this.btn_User = new System.Windows.Forms.Button();
            this.btn_Location = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.IndianRed;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(411, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "MASTER MAINTENANCE";
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_close.Image = global::BrightKeeper.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(394, 338);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(120, 40);
            this.btn_close.TabIndex = 10;
            this.btn_close.Text = "Close";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btn_unit);
            this.panel1.Controls.Add(this.btn_currency);
            this.panel1.Controls.Add(this.btn_Item);
            this.panel1.Controls.Add(this.btn_vendor);
            this.panel1.Controls.Add(this.btn_Customer);
            this.panel1.Controls.Add(this.btn_User);
            this.panel1.Controls.Add(this.btn_Location);
            this.panel1.Location = new System.Drawing.Point(2, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 273);
            this.panel1.TabIndex = 2;
            // 
            // btn_unit
            // 
            this.btn_unit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_unit.Location = new System.Drawing.Point(275, 87);
            this.btn_unit.Name = "btn_unit";
            this.btn_unit.Size = new System.Drawing.Size(200, 40);
            this.btn_unit.TabIndex = 8;
            this.btn_unit.Text = "Unit Master";
            this.btn_unit.UseVisualStyleBackColor = false;
            this.btn_unit.Click += new System.EventHandler(this.btn_unit_Click);
            // 
            // btn_currency
            // 
            this.btn_currency.BackColor = System.Drawing.SystemColors.Control;
            this.btn_currency.Location = new System.Drawing.Point(32, 199);
            this.btn_currency.Name = "btn_currency";
            this.btn_currency.Size = new System.Drawing.Size(200, 40);
            this.btn_currency.TabIndex = 6;
            this.btn_currency.Text = "Currency Master";
            this.btn_currency.UseVisualStyleBackColor = false;
            this.btn_currency.Click += new System.EventHandler(this.btn_currency_Click);
            // 
            // btn_Item
            // 
            this.btn_Item.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Item.Location = new System.Drawing.Point(275, 144);
            this.btn_Item.Name = "btn_Item";
            this.btn_Item.Size = new System.Drawing.Size(200, 40);
            this.btn_Item.TabIndex = 9;
            this.btn_Item.Text = "Item Master";
            this.btn_Item.UseVisualStyleBackColor = false;
            this.btn_Item.Click += new System.EventHandler(this.btn_Item_Click);
            // 
            // btn_vendor
            // 
            this.btn_vendor.BackColor = System.Drawing.SystemColors.Control;
            this.btn_vendor.Location = new System.Drawing.Point(275, 32);
            this.btn_vendor.Name = "btn_vendor";
            this.btn_vendor.Size = new System.Drawing.Size(200, 40);
            this.btn_vendor.TabIndex = 7;
            this.btn_vendor.Text = "Vendor Master";
            this.btn_vendor.UseVisualStyleBackColor = false;
            this.btn_vendor.Click += new System.EventHandler(this.btn_vendor_Click);
            // 
            // btn_Customer
            // 
            this.btn_Customer.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Customer.Location = new System.Drawing.Point(32, 144);
            this.btn_Customer.Name = "btn_Customer";
            this.btn_Customer.Size = new System.Drawing.Size(200, 40);
            this.btn_Customer.TabIndex = 5;
            this.btn_Customer.Text = "Customer Master";
            this.btn_Customer.UseVisualStyleBackColor = false;
            this.btn_Customer.Click += new System.EventHandler(this.btn_Customer_Click);
            // 
            // btn_User
            // 
            this.btn_User.BackColor = System.Drawing.SystemColors.Control;
            this.btn_User.Location = new System.Drawing.Point(32, 32);
            this.btn_User.Name = "btn_User";
            this.btn_User.Size = new System.Drawing.Size(200, 40);
            this.btn_User.TabIndex = 3;
            this.btn_User.Text = "User Master";
            this.btn_User.UseVisualStyleBackColor = false;
            this.btn_User.Click += new System.EventHandler(this.btn_User_Click);
            // 
            // btn_Location
            // 
            this.btn_Location.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Location.Location = new System.Drawing.Point(32, 87);
            this.btn_Location.Name = "btn_Location";
            this.btn_Location.Size = new System.Drawing.Size(200, 40);
            this.btn_Location.TabIndex = 4;
            this.btn_Location.Text = "Location Master";
            this.btn_Location.UseVisualStyleBackColor = false;
            this.btn_Location.Click += new System.EventHandler(this.btn_Location_Click);
            // 
            // MasterMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(525, 381);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MasterMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRIGHT KEEPER";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Item;
        private System.Windows.Forms.Button btn_Customer;
        private System.Windows.Forms.Button btn_Location;
        private System.Windows.Forms.Button btn_User;
        private System.Windows.Forms.Button btn_vendor;
        private System.Windows.Forms.Button btn_unit;
        private System.Windows.Forms.Button btn_currency;
    }
}