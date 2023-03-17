using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Customer
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<Card> Cards { get; set; }
        public decimal Balance { get; set; }
        public string ImgPath { get; set; }
    }
}
