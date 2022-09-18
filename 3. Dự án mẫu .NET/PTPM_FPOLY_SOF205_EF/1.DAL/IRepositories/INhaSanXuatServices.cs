using _1.DAL.DomainModels;
using System.Collections.Generic;

namespace _1.DAL.Repositories.IServices
{
    public interface INhaSanXuatServices
    {
        List<NhaSanXuat> getlNSXfromDB();
        bool addNSX(NhaSanXuat nhaSanXuat);
        bool deleteNSX(NhaSanXuat nhaSanXuat);
        bool updateNSX(NhaSanXuat nhaSanXuat);
    }
}
