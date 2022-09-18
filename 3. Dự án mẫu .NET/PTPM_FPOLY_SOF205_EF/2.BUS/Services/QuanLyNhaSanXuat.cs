using _1.DAL.DomainModels;
using _1.DAL.Repositories;
using _1.DAL.Repositories.IServices;
using _2.BUS.IServices;
using System.Collections.Generic;

namespace _2.BUS.Services
{
    public class QuanLyNhaSanXuat : IQuanLyNhaSanXuat
    {
        private INhaSanXuatServices _IQlNhaSanXuat;
        private List<NhaSanXuat> _lstNSX;
        public QuanLyNhaSanXuat()
        {
            _IQlNhaSanXuat = new NhaSanXuatServices();
            _lstNSX = new List<NhaSanXuat>();
            getlNSXfromDB();
        }

        public bool addNSX(NhaSanXuat nhaSanXuat)
        {
            _IQlNhaSanXuat.addNSX(nhaSanXuat);
            return true;
        }

        public bool deleteNSX(NhaSanXuat nhaSanXuat)
        {
            _IQlNhaSanXuat.deleteNSX(nhaSanXuat);
            return true;
        }

        public List<NhaSanXuat> getlNSXfromDB()
        {
            return _lstNSX = _IQlNhaSanXuat.getlNSXfromDB();
        }

        public bool updateNSX(NhaSanXuat nhaSanXuat)
        {
            _IQlNhaSanXuat.updateNSX(nhaSanXuat);
            return true;
        }
    }
}
