using _1.DAL.DomainModels;
using _1.DAL.Repositories;
using _1.DAL.Repositories.IServices;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace _2.BUS.Services
{
    public class QuanLyProducts : IQuanLyHangHoaServices
    {
        //khai báo biến toàn cục của Interface ở tầng 1 để call các phương thức lên đây
        private IProductsServices _IQlHangHoa;
        private List<Product> _lsHangHoas;
        private INhaSanXuatServices _IQlNhaSanXuat;
        private List<ViewHienThiSanPham> _lstview;
        public QuanLyProducts()
        {
            //khởi tạo biến toàn cục của Interface và KHÔNG PHẢI new Interface mà là new TÊN CLASS MÀ NÓ KẾ THỪA ở tầng 1
            _IQlHangHoa = new ProductServices();
            _lsHangHoas = new List<Product>();
            _IQlNhaSanXuat = new NhaSanXuatServices();
            getlstHanghoafromDB();

            _lstview = new List<ViewHienThiSanPham>();

        }

        public bool addHangHoa(Product product)
        {
            //nhớ làm việc với các chức năng này quan tâm đến duy nhất là khóa chính để CRUD 
            _IQlHangHoa.addHangHoa(product);
            return true;
        }

        public bool deleteHangHoa(Product product)
        {
            _IQlHangHoa.deleteHangHoa(product);
            return true;
        }

        public List<Product> getlstHanghoafromDB()
        {
            return _lsHangHoas = _IQlHangHoa.getProductsFromDB();
        }

        public List<ViewHienThiSanPham> getViewHangHoa()
        {

            // đã là nối 2 bảng với nhau để tạo ra được viewmodel giúp hiển thị đầy đủ thông tin của sản phẩm
            _lstview = (from a in getlstHanghoafromDB()
                        join b in _IQlNhaSanXuat.getlNSXfromDB() on a.IdnhaSanXuat equals b.IdnhaSanXuat
                        select new ViewHienThiSanPham { sp = a, nsx = b }).ToList();
            return _lstview;
        }

        public bool updateHangHoa(Product product)
        {
            _IQlHangHoa.updateHangHoa(product);
            return true;
        }
    }
}
