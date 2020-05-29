using Microsoft.EntityFrameworkCore;
using NatureStoreWebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatureStoreWebApp.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> SelectAll()
        {
            return  _context.Products.ToList();
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
            /*Product p = productDto.Product;

            List<Disease> diseases = productDto.Diseases;
            List<Ingredient> ingredients = productDto.Ingredients;
            p.ProductDisease = new List<ProductDisease>();
            p.ProductIngredient = new List<ProductIngredient>();

            foreach (Disease d in diseases)
            {
                p.ProductDisease.Add(new ProductDisease(p.Id_product, d.Id_disease));

            }

            foreach (Ingredient i in ingredients)
            {
                p.ProductIngredient.Add(new ProductIngredient(p.Id_product, i.Id_ingredient));

            }*/

            _context.Products.Add(product);
            _context.SaveChanges();
        }
        
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id_product == id);
        }
       
    }
}
