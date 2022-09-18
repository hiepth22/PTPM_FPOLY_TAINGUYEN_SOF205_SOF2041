using _1.DAL.DomainModels;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModels;
using _3.PresentationLayers.Utilities;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace _3.PresentationLayers
{
    public partial class FrmProducts : Form
    {
        private ViewHienThiSanPham _viewSanPham;
        private IQuanLyHangHoaServices _IQlHangHoa;
        private IQuanLyNhaSanXuat _IOLnsx;
        private Product _hanghoa;
        private Validations _validate;

        public FrmProducts()
        {
            InitializeComponent();
            _viewSanPham = new ViewHienThiSanPham();
            _IQlHangHoa = new QuanLyProducts();
            _IOLnsx = new QuanLyNhaSanXuat();
            _hanghoa = new Product();
            _validate = new Validations();
            LoadData();
            dgrid_SanPham.AllowUserToAddRows = false;
        }


        void LoadData()
        {

            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");


            dgrid_SanPham.ColumnCount = 4;
            dgrid_SanPham.Columns[0].Name = "Mã Sản Phẩm";
            dgrid_SanPham.Columns[0].Visible = false;

            dgrid_SanPham.Columns[1].Name = "Tên Sản Phẩm";
            dgrid_SanPham.Columns[2].Name = "Đơn Giá Nhập";
            dgrid_SanPham.Columns[3].Name = "Dơn Giá Bán";
            //xử lý add vào combobox
            DataGridViewComboBoxColumn cboNSX = new DataGridViewComboBoxColumn();
            cboNSX.HeaderText = "Tên Nhà Sản Xuất";
            cboNSX.Name = "cbo_nsx";
            foreach (var x in _IOLnsx.getlNSXfromDB())
            {

                cboNSX.Items.Insert(0, x.TenNhaSanXuat);
            }

            dgrid_SanPham.Columns.Add(cboNSX);

            //  ADD CONTROLS TO DATAGRIDVIEW nhìn sẽ được sạch hơn là gán sự kiện vào các button
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgrid_SanPham.Columns.Add(cbo);

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgrid_SanPham.Columns.Add(btn);
            dgrid_SanPham.Rows.Clear();
            //hiển thị các sản phẩm với trạng thái là true(đang hoạt động)
            foreach (var x in _IQlHangHoa.getViewHangHoa().Where(c => c.sp.Status == true))
            {
                dgrid_SanPham.Rows.Add(x.sp.MaHangHoa, x.sp.TenHangHoa, x.sp.DonGiaNhap, x.sp.DonGiaBan);
            }


        }


        private void dgrid_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgrid_SanPham.AllowUserToAddRows = true;
            int rd = e.RowIndex;
            // khi mà bấm vào dòng không có gì 
            if (rd == _IQlHangHoa.getViewHangHoa().Count || rd == -1)
            {
                return;
            }
            //khai báo ra 1 biến để nhận tham số khi click vào 1 dòng bất kì trong trường hợp dòng đấy có cell bị null
            Guid preValues;
            if (String.IsNullOrEmpty(Convert.ToString(dgrid_SanPham.Rows[rd].Cells[0].Value)))
            {
                preValues = Guid.NewGuid();
                return;
            }
            preValues = Guid.Parse(Convert.ToString(dgrid_SanPham.Rows[rd].Cells[0].Value));


            _hanghoa = _IQlHangHoa.getlstHanghoafromDB().Where(c => c.MaHangHoa == preValues).FirstOrDefault();

        }

        private void dgrid_SanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            string tenNSX = Convert.ToString(dgrid_SanPham.Rows[rd].Cells[4].Value);
            //tìm cột đang chứa combobox các chức năng và tìm đến cell chứa noust xác nhận
            if (e.ColumnIndex == 6 && string.IsNullOrEmpty(dgrid_SanPham.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgrid_SanPham.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Thêm")
                {

                    if (_validate.NSXValidate(tenNSX) == false)
                    {
                        MessageBox.Show("Tên Nhà Sản Xuất Không Hợp Lệ");
                        return;
                    }

                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        //tự sinh mã bằng kiểu guid
                        _hanghoa.MaHangHoa = Guid.NewGuid();
                        _hanghoa.TenHangHoa = Convert.ToString(dgrid_SanPham.Rows[e.RowIndex].Cells[1].Value.ToString());
                        _hanghoa.DonGiaNhap = Convert.ToDouble(dgrid_SanPham.Rows[e.RowIndex].Cells[2].Value.ToString());
                        _hanghoa.DonGiaBan = Convert.ToDouble(dgrid_SanPham.Rows[e.RowIndex].Cells[3].Value.ToString());
                        _hanghoa.Status = true;
                        _hanghoa.IdnhaSanXuat = _IOLnsx.getlNSXfromDB()
                        .Where(c => c.TenNhaSanXuat == Convert.ToString(dgrid_SanPham.Rows[e.RowIndex].Cells[4].Value)).Select(c => c.IdnhaSanXuat).FirstOrDefault();
                        _IQlHangHoa.addHangHoa(_hanghoa);
                        LoadData();

                        return;
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            //sửa
            if (e.ColumnIndex == 6 && string.IsNullOrEmpty(dgrid_SanPham.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgrid_SanPham.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Sửa")
                {
                    if (_validate.NSXValidate(tenNSX) == false)
                    {
                        MessageBox.Show("Tên Nhà Sản Xuất Không Hợp Lệ");
                        return;
                    }
                    //kiểm tra nếu không
                    //có mã hoàng hóa trong db thì sẽ trả false và dừng lại hiển thị ra thông báo

                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Guid preValues;
                        if (String.IsNullOrEmpty(Convert.ToString(dgrid_SanPham.Rows[rd].Cells[0].Value)))
                        {
                            preValues = Guid.NewGuid();
                            if (_validate.HangHoaValidate(preValues) == false)
                            {
                                MessageBox.Show("Bạn Chưa Chọn Đúng Hàng Hóa Cần Sửa");
                                return;
                            }
                        }


                        //tự sinh mã bằng kiểu guid

                        _hanghoa.TenHangHoa = Convert.ToString(dgrid_SanPham.Rows[e.RowIndex].Cells[1].Value.ToString());
                        _hanghoa.DonGiaNhap = Convert.ToDouble(dgrid_SanPham.Rows[e.RowIndex].Cells[2].Value.ToString());
                        _hanghoa.DonGiaBan = Convert.ToDouble(dgrid_SanPham.Rows[e.RowIndex].Cells[3].Value.ToString());
                        _hanghoa.Status = true;
                        _hanghoa.IdnhaSanXuat = _IOLnsx.getlNSXfromDB()
                        .Where(c => c.TenNhaSanXuat == Convert.ToString(dgrid_SanPham.Rows[e.RowIndex].Cells[4].Value)).Select(c => c.IdnhaSanXuat).FirstOrDefault();
                        _IQlHangHoa.updateHangHoa(_hanghoa);
                        LoadData();

                        return;
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            //xóa

            if (e.ColumnIndex == 6 && string.IsNullOrEmpty(dgrid_SanPham.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgrid_SanPham.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Xóa")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Xóa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Guid preValues;
                        if (String.IsNullOrEmpty(Convert.ToString(dgrid_SanPham.Rows[rd].Cells[0].Value)))
                        {
                            preValues = Guid.NewGuid();
                            if (_validate.HangHoaValidate(preValues) == false)
                            {
                                MessageBox.Show("Bạn Chưa Chọn Hàng Hàng Hóa Cần Xóa");
                                return;
                            }
                        }

                        //chức năng xóa này không được
                        //phép xóa bay sản phẩm đó mà chỉ
                        //cần chuyển trạng thái từ hoạt động sang không hoạt động(còn lý do học dự án 1 sẽ rõ)
                        foreach (var x in _IQlHangHoa.getlstHanghoafromDB().Where(c => c.MaHangHoa == Guid.Parse(Convert.ToString(dgrid_SanPham.Rows[e.RowIndex].Cells[0].Value))))
                        {
                            x.Status = false;
                            _IQlHangHoa.updateHangHoa(x);
                        }

                        LoadData();

                        return;
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

        private void dgrid_SanPham_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {


            //if (e.ColumnIndex == 4)
            //{
            //    e.Value = "--Select--";
            //}
        }
    }
}
