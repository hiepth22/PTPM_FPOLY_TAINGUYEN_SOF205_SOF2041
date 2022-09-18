using _1.DAL.DomainModels;
using System.Collections.Generic;

namespace _1.DAL.Repositories.IServices
{
    public interface IProductsServices
    {

        //tạo ra các interface để xíu implement ở bên services

        bool addHangHoa(Product product);
        bool deleteHangHoa(Product product);
        bool updateHangHoa(Product product);
        List<Product> getProductsFromDB();



    }
}
