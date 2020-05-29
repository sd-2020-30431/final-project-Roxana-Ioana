using NatureStoreWebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatureStoreWebApp.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> SelectAll();
        Product SelectById(int id);
        void Save(Product product);
        bool Update(int id, Product product);
        bool Delete(int id);
      
    }
}
