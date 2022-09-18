using _1.DAL.DomainModels;
using System.Collections.Generic;

namespace _2.BUS.IServices
{
    public interface IQuanLyNhaSanXuat
    {

        List<NhaSanXuat> getlNSXfromDB();
        bool addNSX(NhaSanXuat nhaSanXuat);
        bool deleteNSX(NhaSanXuat nhaSanXuat);
        bool updateNSX(NhaSanXuat nhaSanXuat);
    }
}
