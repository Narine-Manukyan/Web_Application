namespace MyDAL
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
    }
}
