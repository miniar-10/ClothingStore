using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clothingStore
{
    class Product
    {   public int productId { get; set; } 
        public string productName { get; set; }
        public string productColor { get; set; }
        public String productPrice { get; set; }

        public int Quantity { get; set; }

        public Product(int productId ,string productName, string productColor, String productPrice,int Quantity)
        {
            this.productId = productId;
            this.productName = productName;
            this.productColor = productColor;
            this.productPrice = productPrice;
            this.Quantity = Quantity;
        }

        public bool Equals(Product product)
        {
            // If parameter is null return false:
            if ((object)product == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this.productName.Equals(product.productName) );
        }
    }

}
