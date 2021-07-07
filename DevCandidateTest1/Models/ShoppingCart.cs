using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCandidateTest1.Models
{
    internal class ShoppingCart
    {
        private DateTime FechaCompra { get; set; }
        private List<Item> Items { get; } = new();

        private decimal TotalCompra => Items.Sum(i => i.Cantidad * i.Precio);

        internal void AgregarItem(Item item)
        {
            int index = Items.FindIndex(i => i.Nombre == item.Nombre);
            if (index >= 0)
            {
                Items[index].Cantidad += item.Cantidad;
            }
            else
            {
                Items.Add(item);
            }
        }

        internal void Comprar()
        {
            if (Items.Count < 1)
            {
                Console.WriteLine($"Your Cart is Empty");
                return;
            }
            FechaCompra = DateTime.Now;
            var message = $"{FechaCompra} - You have bought {ObtenerCantidadItems()} items. ${TotalCompra} has been charged from your primary payment method.";
            Items.Clear();
            FechaCompra = DateTime.MinValue;
            Console.WriteLine(message);
        }

        internal int ObtenerCantidadItems()
        {
            return Items.Sum(i => i.Cantidad);
        }

        internal decimal ObtenerTotalCompra()
        {
            return TotalCompra;
        }
    }
}
