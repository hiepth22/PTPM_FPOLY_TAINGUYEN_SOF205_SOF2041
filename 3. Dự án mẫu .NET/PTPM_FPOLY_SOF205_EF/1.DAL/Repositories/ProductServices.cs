using _1.DAL.Context;
using _1.DAL.DomainModels;
using _1.DAL.Repositories.IServices;
using System.Collections.Generic;
using System.Linq;

namespace _1.DAL.Repositories
{
    public class ProductServices : IProductsServices
    {
        private DatabaseContext _DBcontext;
        private List<Product> _lstProduct;
        public ProductServices()
        {
            _DBcontext = new DatabaseContext();

            _lstProduct = new List<Product>();

            getProductsFromDB();
        }
        public bool addHangHoa(Product product)
        {
            _DBcontext.Products.Add(product);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deleteHangHoa(Product product)
        {
            _DBcontext.Products.Remove(product);
            _DBcontext.SaveChanges();
            return true;
        }



        public List<Product> getProductsFromDB()
        {
            _lstProduct = _DBcontext.Products.ToList();
            return _lstProduct;
        }

        public bool updateHangHoa(Product product)
        {
            _DBcontext.Products.Update(product);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
