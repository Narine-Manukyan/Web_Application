using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        /// <summary>
        /// Method for showing the product.
        /// </summary>
        /// <param name="product"></param>
        static void DisplayProduct(Product product)
        {
            Console.WriteLine($"ID: {product.ID}\tName: {product.Name}\tPrice: " +
                $"{product.Price}\tCategory: {product.Category}");
        }

        static void Main(string[] args)
        {
            //GetAll().Wait();
            //GetByID(2).Wait();

            // Creating new Product.
            Product product = new Product
            {
                Name = "Guitar",
                Category = "Music",
                Price = 80000,
            };

            Post(product).Wait();

            Console.ReadLine();


        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>task</returns>
        public static async Task GetAll()
        {
            // Doing HTTP request due to HttpClient.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.GetAsync("api/products");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                    foreach (var product in result)
                    {
                        DisplayProduct(product);
                    }
                }
            }
        }

        /// <summary>
        /// Get Product by ID.
        /// </summary>
        /// <returns>task</returns>
        public static async Task GetByID(int id)
        {
            // Doing HTTP request due to HttpClient.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.GetAsync("api/products/"+id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<Product>();
                    DisplayProduct(result);
                }
            }
        }

        /// <summary>
        /// Insert new Product in products.
        /// </summary>
        /// <returns>task</returns>
        public static async Task Post(Product product)
        {
            // Doing HTTP request due to HttpClient.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.PostAsJsonAsync("api/products",product);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<bool>();
                    Console.WriteLine(result);
                }
            }
        }

        /// <summary>
        /// Update the specific Product.
        /// </summary>
        /// <returns>task</returns>
        public static async Task Put(int id, Product newProduct)
        {
            // Doing HTTP request due to HttpClient.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.PutAsJsonAsync("api/Products/"+id, newProduct);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<bool>();
                    Console.WriteLine(result);
                }
            }
        }

        /// <summary>
        /// Delete The specified Product.
        /// </summary>
        /// <returns>task</returns>
        public static async Task Delete(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49252/");
                var response = await client.DeleteAsync("api/Products/" + ID);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<bool>();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
