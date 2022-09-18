using _1.DAL.Context;
using _1.DAL.DomainModels;
using _1.DAL.Repositories.IServices;
using System.Collections.Generic;
using System.Linq;

namespace _1.DAL.Repositories
{
    public class NhaSanXuatServices : INhaSanXuatServices
    {
        //khai báo biến toàn cục là DatabaseContext ở folder Context
        private DatabaseContext _DBcontext;
        private List<NhaSanXuat> _lstNSX;
        public NhaSanXuatServices()
        {

            //khới tạo ở constructor bắt buộc nếu không muốn bị đỏ lòm null
            _DBcontext = new DatabaseContext();
            _lstNSX = new List<NhaSanXuat>();

            getlNSXfromDB();
        }
        public bool addNSX(NhaSanXuat nhaSanXuat)
        {
            _DBcontext.NhaSanXuats.Add(nhaSanXuat);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deleteNSX(NhaSanXuat nhaSanXuat)
        {
            _DBcontext.NhaSanXuats.Remove(nhaSanXuat);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<NhaSanXuat> getlNSXfromDB()
        {
            // list chọc vào thẳng db để lấy dữ liệu và gọi lên constructor
            // trường hợp mà bảng nối với nhiều bảng khác nên sử dụng thêm
            // AsNoTracking() để bỏ theo dõi bảng đó(còn vì sao khi làm lên dự án 1 sẽ rõ)
            //var _ls = _DBcontext.NhaSanXuats.AsNoTracking().ToList();
            _lstNSX = _DBcontext.NhaSanXuats.ToList();
            return _lstNSX;
        }

        public bool updateNSX(NhaSanXuat nhaSanXuat)
        {
            _DBcontext.NhaSanXuats.Update(nhaSanXuat);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
