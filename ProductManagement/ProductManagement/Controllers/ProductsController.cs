using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data;
using ProductManagement.Models;
using ProductManagement.Models.Entities;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllProducst()
        {
            var allProducts = dbContext.Products.ToList();
            return Ok(allProducts);
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddProduct(AddProductDTO addProductDTO)
        {
            var productEntity = new Product()
            {
                Name = addProductDTO.Name,
                ManufacturerEmail = addProductDTO.ManufacturerEmail,
                ManufacturerPhone = addProductDTO.ManufacturerPhone,
                ManufacturerDate = addProductDTO.ManufacturerDate,
                IsAvailable = addProductDTO.IsAvailable

            };

            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();

            return Ok(productEntity);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getProductById(Guid id)
        {
            var product = dbContext.Products.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        [Route("{id:guid}")]
        public IActionResult UpdateProduct(Guid id, UpdateProductDTO updateProductDTO) {
            var product = dbContext.Products.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            product.Name = updateProductDTO.Name;
            product.ManufacturerPhone = updateProductDTO.ManufacturerPhone;
            product.ManufacturerEmail = updateProductDTO.ManufacturerEmail;
            product.ManufacturerDate = updateProductDTO.ManufacturerDate;

            dbContext.SaveChanges();
            return Ok(product);
        }
        [HttpDelete]
        [Authorize]
        
        [Route("{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = dbContext.Products.Find(id);

            if(product is null)
            {
                return NotFound();
            }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();

            return Ok();
        }


    }
}
