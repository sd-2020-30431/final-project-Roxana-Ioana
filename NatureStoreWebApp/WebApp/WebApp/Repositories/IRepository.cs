using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> SelectAll();
        Product SelectById(int id);
        void Save(Product product);
        bool Update(int id, Product product);
        bool Delete(int id);
        IEnumerable<Product> SelectAllByDisease(int idDisease);
    }
}
