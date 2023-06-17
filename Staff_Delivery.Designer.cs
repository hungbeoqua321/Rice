namespace Rice
{
    partial class Staff_Delivery
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.DataGridView();
            this.Capnhat = new System.Windows.Forms.Button();
            this.Done = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Failure = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 75);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(205, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHÂN VIÊN GIAO HÀNG";
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Done,
            this.Failure});
            this.table.Location = new System.Drawing.Point(14, 254);
            this.table.Margin = new System.Windows.Forms.Padding(4);
            this.table.Name = "table";
            this.table.RowHeadersWidth = 51;
            this.table.Size = new System.Drawing.Size(902, 306);
            this.table.TabIndex = 4;
            this.table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellContentClick);
            // 
            // Capnhat
            // 
            this.Capnhat.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Capnhat.Location = new System.Drawing.Point(13, 200);
            this.Capnhat.Margin = new System.Windows.Forms.Padding(4);
            this.Capnhat.Name = "Capnhat";
            this.Capnhat.Size = new System.Drawing.Size(183, 46);
            this.Capnhat.TabIndex = 5;
            this.Capnhat.Text = "Cập nhật";
            this.Capnhat.UseVisualStyleBackColor = true;
            this.Capnhat.Click += new System.EventHandler(this.Staff_Delivery_Load);
            // 
            // Done
            // 
            this.Done.HeaderText = "Giao thành công";
            this.Done.MinimumWidth = 6;
            this.Done.Name = "Done";
            this.Done.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Done.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Failure
            // 
            this.Failure.HeaderText = "Giao thất bại";
            this.Failure.MinimumWidth = 6;
            this.Failure.Name = "Failure";
            this.Failure.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Staff_Delivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rice.Properties.Resources.a0438c57ea6a316cba91b2071b187467;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(929, 642);
            this.Controls.Add(this.Capnhat);
            this.Controls.Add(this.table);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Staff_Delivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao hàng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Staff_Delivery_FormClosed);
            this.Load += new System.EventHandler(this.Staff_Delivery_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button Capnhat;
        private System.Windows.Forms.DataGridViewButtonColumn Done;
        private System.Windows.Forms.DataGridViewButtonColumn Failure;
    }
}