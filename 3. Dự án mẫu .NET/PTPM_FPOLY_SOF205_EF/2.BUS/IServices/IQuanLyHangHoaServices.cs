using _1.DAL.DomainModels;
using _2.BUS.ViewModels;
using System.Collections.Generic;

namespace _2.BUS.IServices
{
    public interface IQuanLyHangHoaServices
    {

        //IService ở tầng 2 này sẽ gọi ngược lại phương thức ở tầng 1 
        List<Product> getlstHanghoafromDB();
        List<ViewHienThiSanPham> getViewHangHoa();
        bool addHangHoa(Product product);
        bool deleteHangHoa(Product product);
        bool updateHangHoa(Product product);

    }
}
