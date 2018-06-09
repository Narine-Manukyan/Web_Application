using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MyDAL
{
    /// <summary>
    /// For accessing database data and doing CRUD operations.
    /// </summary>
    public class DAL
    {
        /// <summary>
        /// Provides a simple way to create and manage the contents of connection strings used by the SqlConnection class.
        /// </summary>
        private string connectionString;

        /// <summary>
        /// The parameterFull constructor.
        /// </summary>
        /// <param name="filePath">Represents the sql query's file path.</param>
        public DAL()
        {
            this.connectionString =
                ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Insert the specified item in products.
        /// </summary>
        /// <param name="product">product that will be inserted.</param>
        public bool Add(Product product)
        {
            string query = "INSERT INTO Products (Name, Category, Price)" +
                " VALUES (@name, @category, @price)";
            using (var connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = product.Name;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50).Value = product.Category;
                cmd.Parameters.Add("@Price", SqlDbType.Money).Value = product.Price;
                if (cmd.ExecuteNonQuery() == 0)
                    return false;
                else return true;
            }
        }

        /// <summary>
        /// Delete the specified item from products.
        /// </summary>
        public bool Delete(int id)
        {
            string query = "delete from Products where ID=" + id;
            using (var connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                if (cmd.ExecuteNonQuery() == 0)
                    return false;
                else return true;
            }
        }

        /// <summary>
        /// Update the specified item with new item in Products.
        /// </summary>
        public bool Update(int id, Product newProduct)
        {
            string query = "update Products set Name = @Name,"
                + "Category = @Category, Price = @Price" +
                " where ID = " + id;
            using (var connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", newProduct.Name);
                cmd.Parameters.AddWithValue("@Category", newProduct.Category);
                cmd.Parameters.AddWithValue("@Price", newProduct.Price);
                connection.Open();
                if (cmd.ExecuteNonQuery() == 0)
                    return false;
                else return true;
            }
        }

        /// <summary>
        /// Get all products from Products. 
        /// </summary>
        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>();
            string query = "select * from Products";
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ID = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Category = (string)reader["Category"],
                            Price = (decimal)reader["Price"]
                        });
                    }
                }
            }
            return products;
        }

        /// <summary>
        /// Get product by from Products. 
        /// </summary>
        public Product GetProductById(int ID)
        {
            Product product = new Product();
            string query = "select * from Products where ID = "+ ID;
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product = new Product
                        {
                            ID = (int)reader["ID"],
                            Name = (string)reader["Name"],
                            Category = (string)reader["Category"],
                            Price = (decimal)reader["Price"]
                        };
                    }
                }
            }
            return product;
        }
    }
}
