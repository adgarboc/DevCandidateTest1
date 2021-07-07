﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCandidateTest1.Models
{
    internal class ShoppingCart
    {
        public DateTime FechaCompra { get; set; }
        public List<Item> Items { get; set; } = new();
        public decimal TotalCompra { get; set; }
    }
}
