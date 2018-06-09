using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ProductsController : Controller
    {
        //  [HttpGet]
        public async Task<ViewResult> GetAllProducts()
        {
            return View(await GetAll());
        }

        // [HttpGet("{id}")]
        public async Task<ViewResult> GetProductByID(int id = 0)
        {
            return View(await GetByID(id));
        }

        // http://localhost:49260/Products/PostProduct?Name=Pen&Category=Education&Price=200
        // [AcceptVerbs(HttpVerbs.Post)]
        // [HttpPost("{product}")]
        public async Task<ViewResult> PostProduct(Product product = null)
        {
            return View(await Post(product));
        }

        // http://localhost:49260/Products/PutProduct?1&Name=Pen&Category=Education&Price=200
        // [HttpPut("{id}","{newProduct}")]
        public async Task<ViewResult> PutProduct(int id = 0, Product newProduct = null)
        {
            return View(await Put(id, newProduct));
        }

        // [HttpDelete("{id}")]
        public async Task<ViewResult> DeleteProduct(int id = 0)
        {
            return View(await Delete(id));
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>task</returns>
        public static async Task<IEnumerable<Product>> GetAll()
        {
            // Doing HTTP request due to HttpClient.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.GetAsync("api/products");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// Get Product by ID.
        /// </summary>
        /// <returns>task</returns>
        public static async Task<Product> GetByID(int id)
        {
            // Doing HTTP request due to HttpClient.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.GetAsync("api/products/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<Product>();
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// Insert new Product in products.
        /// </summary>
        /// <returns>task</returns>
        public static async Task<bool> Post(Product product)
        {
            // Doing HTTP request due to HttpClient.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.PostAsJsonAsync("api/products", product);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<bool>();
            }
            return false;
        }

        /// <summary>
        /// Update the specific Product.
        /// </summary>
        /// <returns>task</returns>
        public static async Task<bool> Put(int id, Product newProduct)
        {
            // Doing HTTP request due to HttpClient.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.PutAsJsonAsync("api/Products/" + id, newProduct);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<bool>();
            }
            return false;
        }

        /// <summary>
        /// Delete The specified Product.
        /// </summary>
        /// <returns>task</returns>
        public static async Task<bool> Delete(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.DeleteAsync("api/Products/" + ID);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<bool>();
            }
            return false;
        }
    }
}
