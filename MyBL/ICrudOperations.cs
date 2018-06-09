using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBL
{
    /// <summary>
    /// Interface that represents  CRUD Operations.
    /// </summary>
    public interface ICrudOperations
    {
        /// <summary>
        /// Get all Products from storage.
        /// </summary>
        /// <returns>Product list</returns>
        IEnumerable<Product> GetAll();

        /// <summary>
        /// Insert a new product in storage.
        /// </summary>
        /// <param name="product">Product that will be inserted.</param>
        bool Add(Product product);

        /// <summary>
        /// Delete the specified product from storage.
        /// </summary>
        /// <param name="id">Product's id</param>
        bool Delete(int id);

        /// <summary>
        /// Updating the specified product in storage.
        /// </summary>
        /// <param name="product">Product that will be updated.</param>
        /// <param name="newProduct">New product.</param>
        bool Update(int id, Product newProduct);
    }
}
