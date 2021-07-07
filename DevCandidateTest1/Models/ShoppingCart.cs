using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCandidateTest1.Models
{
    internal class ShoppingCart
    {
        public DateTime FechaCompra { get; set; }
        public Item Items  { get; set; }
        public decimal TotalCompra { get; set; }
    }
}
