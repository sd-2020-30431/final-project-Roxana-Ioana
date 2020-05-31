using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> SelectAll()
        {
            return _context.Products.ToList();
        }

        public Product SelectById(int id)
        {
            var product = _context.Products.Find(id);

            return product;
        }


        public bool Update(int id, Product product)
        {
            if (id != product.Id_product)
            {
                return false; //Bad Request
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public bool Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return true;
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id_product == id);
        }

        public IEnumerable<Product> SelectAllByDisease(int idDisease)
        {
            /*var result = _context.Products
                 .Include(x => x.ProductDisease)
                 .ThenInclude(x => x.Id_disease)
                 .ToList();*/

            return null;
        }
    }
}
