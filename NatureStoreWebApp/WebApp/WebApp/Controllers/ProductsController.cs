using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Dto;
using WebApp.Model;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return new JsonResult(_productRepository.SelectAll());         //ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        /*ASP.NET Core automatically serializes the object to JSON and writes the JSON into the body of the response message.*/
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productRepository.SelectById(id);

            if (product == null)
            {
                return NotFound();
            }

            return new JsonResult(product);
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult<bool> PutProduct(int id, Product product)
        {
            bool succedded = _productRepository.Update(id, product);
            if (succedded)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Product
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult PostProduct(ProductDto productDto)
        {
            Product p = new Product(productDto.Name, productDto.Price, productDto.Stock, productDto.Description, productDto.Administration);

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

            }

            _productRepository.Save(p);

            return Ok();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteProduct(int id)
        {
            bool succedded = _productRepository.Delete(id);

            if (succedded)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("Disease/{id}")]
        public ActionResult<IEnumerable<Product>> SelectAllByDisease(int idDisease)
        {
            return new JsonResult(_productRepository.SelectAllByDisease(idDisease));
        }
    }
}
