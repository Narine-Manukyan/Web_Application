using System.Collections.Generic;
using MyDAL;

namespace MyBL
{
    /// <summary>
    /// Repository pattern for BL.
    /// </summary>
    public class ProductRepository : ICrudOperations
    {
        /// <summary>
        /// DAL object.
        /// </summary>
        private DAL dal;

        /// <summary>
        /// The parameterless constructor.
        /// </summary>
        public ProductRepository()
        {
            this.dal = new DAL();
        }

        /// <summary>
        /// Insert new product in Products
        /// </summary>
        /// <param name="product">new product</param>
        public bool Add(Product product)
        {
            return this.dal.Add(product);
        }

        /// <summary>
        /// Delete the specified product from Products.
        /// </summary>
        /// <param name="id">id of product</param>
        public bool Delete(int id)
        {
            return this.dal.Delete(id);
        }

        /// <summary>
        /// Get all elements from Products.
        /// </summary>
        public IEnumerable<Product> GetAll()
        {
            var DalProducts = dal.GetProducts();
            var products = new List<Product>();
            foreach(var item in DalProducts)
            {
                products.Add((Product)item);
            }
            return products;
        }

        /// <summary>
        /// Gets the product by ID.
        /// </summary>
        /// <param name="id">Product's id</param>
        /// <returns>product</returns>
        public Product GetProductByID(int id)
        {
            var item = dal.GetProductById(id);
            return (Product)item;
        }

        /// <summary>
        /// Update the specified product with new product.
        /// </summary>
        /// <param name="product">Old product</param>
        /// <param name="newProduct">New product</param>
        public bool Update(int id, Product newProduct)
        {
            return this.dal.Update(id, newProduct);
        }
    }
}
