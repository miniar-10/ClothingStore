using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clothingStore
{
    class Facture
    {
        private static int InvoicesNumber = 0;
        public int id { get; set; }
        public DateTime date { get; set; }
        public String userName { get; set; }
        public String userPassword { get; set; }

        public Facture(string userName, string userPassword)
        {
            InvoicesNumber++;
            this.userName = userName;
            this.userPassword = userPassword;
            this.id = InvoicesNumber;
            this.date = DateTime.Now;
        }
    }
}
