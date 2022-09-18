namespace _3.PresentationLayers
{
    partial class FrmProducts
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgrid_SanPham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_SanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(230, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Hoàng Hóa";
            // 
            // dgrid_SanPham
            // 
            this.dgrid_SanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_SanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_SanPham.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgrid_SanPham.Location = new System.Drawing.Point(0, 171);
            this.dgrid_SanPham.Name = "dgrid_SanPham";
            this.dgrid_SanPham.RowHeadersWidth = 51;
            this.dgrid_SanPham.RowTemplate.Height = 29;
            this.dgrid_SanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_SanPham.Size = new System.Drawing.Size(800, 279);
            this.dgrid_SanPham.TabIndex = 1;
            this.dgrid_SanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_SanPham_CellClick);
            this.dgrid_SanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_SanPham_CellContentClick);
            this.dgrid_SanPham.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgrid_SanPham_CellFormatting_1);
            // 
            // FrmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgrid_SanPham);
            this.Controls.Add(this.label1);
            this.Name = "FrmProducts";
            this.Text = "FrmProducts";
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_SanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgrid_SanPham;
    }
}