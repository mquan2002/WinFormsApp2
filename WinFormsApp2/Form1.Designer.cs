namespace QuanLySanPham
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
            txtThanhTien = new TextBox();
            txtMaPN = new TextBox();
            txtNgayNhap = new TextBox();
            cmbMaNCC = new ComboBox();
            cmbMaPN = new ComboBox();
            cmbMaSP = new ComboBox();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            dgvChiTietPhieuNhap = new DataGridView();
            btnTaoPhieuNhap = new Button();
            btnThemSanPham = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieuNhap).BeginInit();
            SuspendLayout();
            // 
            // txtThanhTien
            // 
            txtThanhTien.Location = new Point(150, 100);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.Size = new Size(200, 27);
            txtThanhTien.TabIndex = 1;
            // 
            // txtMaPN
            // 
            txtMaPN.Location = new Point(150, 130);
            txtMaPN.Name = "txtMaPN";
            txtMaPN.Size = new Size(200, 27);
            txtMaPN.TabIndex = 2;
            // 
            // txtNgayNhap
            // 
            txtNgayNhap.Location = new Point(150, 160);
            txtNgayNhap.Name = "txtNgayNhap";
            txtNgayNhap.Size = new Size(200, 27);
            txtNgayNhap.TabIndex = 3;
            // 
            // cmbMaNCC
            // 
            cmbMaNCC.FormattingEnabled = true;
            cmbMaNCC.Location = new Point(150, 190);
            cmbMaNCC.Name = "cmbMaNCC";
            cmbMaNCC.Size = new Size(200, 28);
            cmbMaNCC.TabIndex = 4;
            // 
            // cmbMaPN
            // 
            cmbMaPN.FormattingEnabled = true;
            cmbMaPN.Location = new Point(150, 220);
            cmbMaPN.Name = "cmbMaPN";
            cmbMaPN.Size = new Size(200, 28);
            cmbMaPN.TabIndex = 5;
            // 
            // cmbMaSP
            // 
            cmbMaSP.FormattingEnabled = true;
            cmbMaSP.Location = new Point(150, 250);
            cmbMaSP.Name = "cmbMaSP";
            cmbMaSP.Size = new Size(200, 28);
            cmbMaSP.TabIndex = 6;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(150, 280);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(200, 27);
            txtDonGia.TabIndex = 7;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(150, 310);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(200, 27);
            txtSoLuong.TabIndex = 8;
            // 
            // dgvChiTietPhieuNhap
            // 
            dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietPhieuNhap.Location = new Point(400, 30);
            dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            dgvChiTietPhieuNhap.RowHeadersWidth = 51;
            dgvChiTietPhieuNhap.Size = new Size(400, 300);
            dgvChiTietPhieuNhap.TabIndex = 9;
            // 
            // btnTaoPhieuNhap
            // 
            btnTaoPhieuNhap.Location = new Point(20, 350);
            btnTaoPhieuNhap.Name = "btnTaoPhieuNhap";
            btnTaoPhieuNhap.Size = new Size(150, 30);
            btnTaoPhieuNhap.TabIndex = 10;
            btnTaoPhieuNhap.Text = "Tạo Phiếu Nhập";
            // 
            // btnThemSanPham
            // 
            btnThemSanPham.Location = new Point(200, 350);
            btnThemSanPham.Name = "btnThemSanPham";
            btnThemSanPham.Size = new Size(150, 30);
            btnThemSanPham.TabIndex = 11;
            btnThemSanPham.Text = "Thêm Sản Phẩm";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 103);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 12;
            label1.Text = "Thành tiền";
            label1.Click += label1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(txtThanhTien);
            Controls.Add(txtMaPN);
            Controls.Add(txtNgayNhap);
            Controls.Add(cmbMaNCC);
            Controls.Add(cmbMaPN);
            Controls.Add(cmbMaSP);
            Controls.Add(txtDonGia);
            Controls.Add(txtSoLuong);
            Controls.Add(dgvChiTietPhieuNhap);
            Controls.Add(btnTaoPhieuNhap);
            Controls.Add(btnThemSanPham);
            Name = "MainForm";
            Text = "Quản Lý Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieuNhap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}
