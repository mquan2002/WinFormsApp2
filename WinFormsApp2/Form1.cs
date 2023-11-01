using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySanPham
{
    public partial class MainForm : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet dataSet;

        // Thêm các control còn thiếu
        TextBox txtThanhTien;
        TextBox txtMaPN;
        TextBox txtNgayNhap;
        ComboBox cmbMaNCC;
        ComboBox cmbMaSP;
        ComboBox cmbMaPN;
        TextBox txtDonGia;
        TextBox txtSoLuong;
        DataGridView dgvChiTietPhieuNhap;
        Button btnTaoPhieuNhap;
        Button btnThemSanPham;

        public MainForm()
        {
            InitializeComponent();
            InitializeDatabase();
            InitializeForm();
        }

        private void InitializeDatabase()
        {
            // Thay đổi chuỗi kết nối dựa trên cấu hình của bạn
            string connectionString = "Data Source=MSI\\MINHQUAN;Initial Catalog=QuanLySanPhamDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();

            // Khởi tạo DataSet
            dataSet = new DataSet();

            // Tải dữ liệu vào DataSet
            LoadData();
        }

        private void LoadData()
        {
            // Load dữ liệu từ bảng NhaCungCap
            adapter.SelectCommand = new SqlCommand("SELECT * FROM NhaCungCap", connection);
            adapter.Fill(dataSet, "NhaCungCap");

            // Load dữ liệu từ bảng PhieuNhap
            adapter.SelectCommand = new SqlCommand("SELECT * FROM PhieuNhap", connection);
            adapter.Fill(dataSet, "PhieuNhap");

            // Load dữ liệu từ bảng ChiTietPhieuNhap
            adapter.SelectCommand = new SqlCommand("SELECT * FROM ChiTietPhieuNhap", connection);
            adapter.Fill(dataSet, "ChiTietPhieuNhap");

            // Load dữ liệu từ bảng SanPham
            adapter.SelectCommand = new SqlCommand("SELECT * FROM SanPham", connection);
            adapter.Fill(dataSet, "SanPham");
        }

        private void InitializeForm()
        {
            InitializeComponent();

            txtMaPN = new TextBox();
            txtNgayNhap = new TextBox();
            cmbMaNCC = new ComboBox();
            cmbMaSP = new ComboBox();
            cmbMaPN = new ComboBox();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            txtThanhTien = new TextBox();
            dgvChiTietPhieuNhap = new DataGridView();
            btnTaoPhieuNhap = new Button();
            btnThemSanPham = new Button();

            txtMaPN.Text = "";
            txtNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cmbMaNCC.DataSource = dataSet.Tables["NhaCungCap"];
            cmbMaNCC.DisplayMember = "MaNCC";
            cmbMaNCC.ValueMember = "MaNCC";

            txtThanhTien.Text = "0";

            cmbMaPN.DataSource = dataSet.Tables["PhieuNhap"];
            cmbMaPN.DisplayMember = "MaPN";
            cmbMaPN.ValueMember = "MaPN";

            cmbMaSP.DataSource = dataSet.Tables["SanPham"];
            cmbMaSP.DisplayMember = "MaSP";
            cmbMaSP.ValueMember = "MaSP";

            txtDonGia.Enabled = false;
            txtSoLuong.Text = "0";

            dgvChiTietPhieuNhap.DataSource = dataSet.Tables["ChiTietPhieuNhap"];

            btnTaoPhieuNhap.Click += BtnTaoPhieuNhap_Click;
            cmbMaPN.SelectedIndexChanged += CmbMaPN_SelectedIndexChanged;
            cmbMaSP.SelectedIndexChanged += CmbMaSP_SelectedIndexChanged;
            dgvChiTietPhieuNhap.CellClick += DgvChiTietPhieuNhap_CellClick;
            btnThemSanPham.Click += BtnThemSanPham_Click;
        }

        private void BtnTaoPhieuNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPN.Text))
            {
                MessageBox.Show("Mã phiếu nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xử lý sự kiện khi chọn button Tạo phiếu nhập
            DataRow newRow = dataSet.Tables["PhieuNhap"].NewRow();
            newRow["MaPN"] = txtMaPN.Text;
            newRow["NgayNhap"] = DateTime.ParseExact(txtNgayNhap.Text, "dd/MM/yyyy", null);
            newRow["MaNCC"] = cmbMaNCC.SelectedValue;
            newRow["ThanhTien"] = 0; // Giá trị ban đầu là 0

            dataSet.Tables["PhieuNhap"].Rows.Add(newRow);
            adapter.Update(dataSet, "PhieuNhap");

            // Load lại ComboBox MaPN trong groupBox Chi tiết phiếu nhập
            LoadMaPNComboBox();

            txtThanhTien.Text = "0"; // Vô hiệu hóa TextBox Thành tiền

            MessageBox.Show("Tạo phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbMaPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi chọn một mã phiếu nhập trong ComboBox MaPN trong groupBox Chi tiết phiếu nhập
            DataRow[] rows = dataSet.Tables["PhieuNhap"].Select($"MaPN = '{cmbMaPN.SelectedValue}'");

            if (rows.Length > 0)
            {
                txtMaPN.Text = rows[0]["MaPN"].ToString();
                txtNgayNhap.Text = ((DateTime)rows[0]["NgayNhap"]).ToString("dd/MM/yyyy");
                cmbMaNCC.SelectedValue = rows[0]["MaNCC"];
                txtThanhTien.Text = rows[0]["ThanhTien"].ToString();
            }

            // Hiển thị thông tin về chi tiết phiếu nhập tương ứng trong DataGridView Chi tiết phiếu nhập
            LoadChiTietPhieuNhapGrid();
        }

        private void CmbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi chọn một mã sản phẩm trong ComboBox MaSP trong groupBox Chi tiết phiếu nhập
            DataRow[] rows = dataSet.Tables["SanPham"].Select($"MaSP = '{cmbMaSP.SelectedValue}'");

            if (rows.Length > 0)
            {
                txtDonGia.Text = rows[0]["DonGia"].ToString();
            }

            // Cập nhật lại TextBox Thành tiền
            UpdateTextBoxThanhTien();
        }

        private void UpdateTextBoxThanhTien()
        {
            // Cập nhật lại TextBox Thành tiền dựa trên thông tin hiện tại
            double donGia = 0;
            int soLuong = 0;

            if (double.TryParse(txtDonGia.Text, out donGia) && int.TryParse(txtSoLuong.Text, out soLuong))
            {
                double thanhTien = donGia * soLuong;
                txtThanhTien.Text = thanhTien.ToString();
            }
            else
            {
                txtThanhTien.Text = "0";
            }
        }

        private void DgvChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi chọn một dòng trong DataGridView Chi tiết phiếu nhập
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChiTietPhieuNhap.Rows[e.RowIndex];

                cmbMaSP.SelectedValue = row.Cells["MaSP"].Value;
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
            }
        }

        private void BtnThemSanPham_Click(object sender, EventArgs e)
        {

            // Bây giờ bạn có thể sử dụng cmbMaPN ở đây
            if (string.IsNullOrWhiteSpace(cmbMaPN.Text))
            {
                MessageBox.Show("Mã phiếu nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Xử lý sự kiện khi chọn button Thêm sản phẩm
            if (string.IsNullOrWhiteSpace(txtMaPN.Text))
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập trước khi thêm sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow[] existingRows = dataSet.Tables["ChiTietPhieuNhap"].Select($"MaPN = '{cmbMaPN.SelectedValue}' AND MaSP = '{cmbMaSP.SelectedValue}'");

            if (existingRows.Length > 0)
            {
                // Nếu sản phẩm đã tồn tại trong chi tiết phiếu nhập, cập nhật số lượng
                existingRows[0]["SoLuong"] = int.Parse(existingRows[0]["SoLuong"].ToString()) + int.Parse(txtSoLuong.Text);
            }
            else
            {
                // Nếu sản phẩm chưa tồn tại, thêm mới
                DataRow newRow = dataSet.Tables["ChiTietPhieuNhap"].NewRow();
                newRow["MaPN"] = cmbMaPN.SelectedValue;
                newRow["MaSP"] = cmbMaSP.SelectedValue;
                newRow["DonGia"] = double.Parse(txtDonGia.Text);
                newRow["SoLuong"] = int.Parse(txtSoLuong.Text);

                dataSet.Tables["ChiTietPhieuNhap"].Rows.Add(newRow);
            }

            // Cập nhật Thành tiền vào bảng PhieuNhap
            double thanhTien = double.Parse(txtThanhTien.Text);
            DataRow[] phieuNhapRows = dataSet.Tables["PhieuNhap"].Select($"MaPN = '{cmbMaPN.SelectedValue}'");
            phieuNhapRows[0]["ThanhTien"] = thanhTien;

            // Cập nhật dữ liệu vào Database
            adapter.Update(dataSet, "ChiTietPhieuNhap");
            adapter.Update(dataSet, "PhieuNhap");

            // Load lại DataGridView Chi tiết phiếu nhập
            LoadChiTietPhieuNhapGrid();

            // Hiển thị thông báo khi thêm sản phẩm thành công
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadChiTietPhieuNhapGrid()
        {
            // Load dữ liệu từ bảng ChiTietPhieuNhap tương ứng với MaPN được chọn vào DataGridView
            string maPN = cmbMaPN.SelectedValue.ToString();
            string query = $"SELECT * FROM ChiTietPhieuNhap WHERE MaPN = '{maPN}'";
            SqlDataAdapter chiTietAdapter = new SqlDataAdapter(query, connection);
            DataTable chiTietTable = new DataTable();
            chiTietAdapter.Fill(chiTietTable);
            dgvChiTietPhieuNhap.DataSource = chiTietTable;
        }

        private void LoadMaPNComboBox()
        {
            // Load lại ComboBox MaPN trong groupBox Chi tiết phiếu nhập
            string query = "SELECT * FROM PhieuNhap";
            SqlDataAdapter maPNAdapter = new SqlDataAdapter(query, connection);
            DataTable maPNTable = new DataTable();
            maPNAdapter.Fill(maPNTable);
            cmbMaPN.DataSource = maPNTable;
            cmbMaPN.DisplayMember = "MaPN";
            cmbMaPN.ValueMember = "MaPN";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
