using _1.DAL.DomainModels;

namespace _2.BUS.ViewModels
{
    public class ViewHienThiSanPham
    {
        // ViewModel này là giúp mình tạo
        // ra các list tổng hợp của các bảng để
        // hiển thị nên được 1 Sản phẩm hay thông tin đầy đủ của bất kì đối tượng nào bỏi
        // vì không thể dùng 1 bảng để hiển thi được hết thông tin
        // (mà phải truy xuất ra từ rất nhiều bảng mới giúp hiển thị được thông tin của sản phẩm cũng như các đối tượng khác)
        public Product sp { get; set; }
        public NhaSanXuat nsx { get; set; }
        //



    }
}
