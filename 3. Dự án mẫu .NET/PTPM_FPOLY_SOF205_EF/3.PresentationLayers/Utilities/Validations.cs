using _2.BUS.IServices;
using _2.BUS.Services;
using System;
using System.Linq;

namespace _3.PresentationLayers.Utilities
{
    public class Validations
    {
        //ở mục Utilities này sẽ là nơi chứa các validate của các chức năng ở tầng 3 các bạn sẽ triển khai
        private IQuanLyHangHoaServices _IQlHangHoa;
        private IQuanLyNhaSanXuat _IOLnsx;
        public Validations()
        {
            _IQlHangHoa = new QuanLyProducts();
            _IOLnsx = new QuanLyNhaSanXuat();
        }
        public bool HangHoaValidate(Guid maHangHoa)
        {
            // lấy 1 ví dụ về validate kiểm tra xem mã
            // màng hóa mà mình muốn update,delete... có tồn tại trongdatabase hay không
            if (_IQlHangHoa.getlstHanghoafromDB().Any(c => c.MaHangHoa == maHangHoa) == false)
            {
                return false;
            }



            return true;
        }
        public bool NSXValidate(string tenNSX)
        {
            // lấy 1 ví dụ về validate kiểm tra xem mã
            // màng hóa mà mình muốn update,delete... có tồn tại trongdatabase hay không
            if (_IOLnsx.getlNSXfromDB().Any(c => c.TenNhaSanXuat == tenNSX) == false)
            {
                return false;
            }



            return true;
        }


    }
}
