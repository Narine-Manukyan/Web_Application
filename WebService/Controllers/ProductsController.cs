using System.Collections.Generic;
using System.Web.Http;
using MyBL;

namespace WebService.Controllers
{
    /// <summary>
    /// Controller for action with Products.
    /// </summary>
    public class ProductsController : ApiController
    {
        public ProductRepository productRepository;

        /// <summary>
        /// Parameterfull Constructor.
        /// </summary>
        public ProductsController()
        {
            this.productRepository = new ProductRepository();
        }
        
        /// <summary>
        /// Getter for all Products.
        /// </summary>
        public IEnumerable<Product> Get()
        {
            return this.productRepository.GetAll();
        }

        /// <summary>
        /// Gets the Product by ID.
        /// </summary>
        /// <param name="id">Product's id</param>
        /// <returns>product</returns>
        public Product Get(int id)
        {
            return this.productRepository.GetProductByID(id);
        }

        /// <summary>
        /// Insert new Product.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Post(Product product)
        {
            this.productRepository.Add(product);
        }

        /// <summary>
        /// Update product.
        /// </summary>
        /// <param name="id">Old product</param>
        /// <param name="value">new product</param>
        /// <returns></returns>
        public void Put(int id, Product newProduct)
        {
            this.productRepository.Update(id, newProduct);
        }

        /// <summary>
        /// Delete Product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(int id)
        {
            this.productRepository.Delete(id);
        }
    }
}
