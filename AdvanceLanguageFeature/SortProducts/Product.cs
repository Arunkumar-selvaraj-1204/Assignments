using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortProducts
{
    public class Product
    {
        /// <summary>
        /// Holds the product's name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Holds the product's category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Holds the product's price
        /// </summary>
        public double Price { get; set; }
    }
}
