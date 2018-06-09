namespace MyBL
{
    /// <summary>
    /// Class that represents the product structure.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product ID.
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// Product Name.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// product Category.
        /// </summary>
        public string Category { set; get; }

        /// <summary>
        /// Product Price.
        /// </summary>
        public decimal Price { set; get; }
        
        /// <summary>
        /// Coverter for Dal.Product To Product.
        /// </summary>
        /// <param name="product">Dal Product</param>
        public static explicit operator Product(MyDAL.Product product)
        {
            return new Product
            {
                ID = product.ID,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price
            };
        }

        /// <summary>
        /// Coverter for BL.Product To DAL.Product.
        /// </summary>
        /// <param name="product">BL Product</param>
        public static implicit operator MyDAL.Product(Product product)
        {
            return new MyDAL.Product
            {
                ID = product.ID,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price
            };
        }
    }
}
