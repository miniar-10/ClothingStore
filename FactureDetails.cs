using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clothingStore
{
    class FactureDetails
    {
        public Facture facture;
        public List<Product>ProductsList=new List<Product>();

        public FactureDetails(Facture facture, List<Product> productsList)
            
        {
            this.facture = facture;
            this.ProductsList = productsList;
        }

        
    }
}
