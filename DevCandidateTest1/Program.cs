using System;
using System.Collections.Generic;
using System.Linq;
using DevCandidateTest1.Models;
using static System.Console;

namespace DevCandidateTest1
{
    class Program
    {
        private static readonly ShoppingCart Cart = new();
        private static List<Item> _itemsForSale;

        static void Main(string[] args)
        {
            InicializeItems();
            var optionMenu = "1";
            do
            {
                optionMenu = "1";
                WriteLine($"{new string('*', 10)} MENU {new string('*', 10)}");
                WriteLine("1.- Add to cart (default)");
                WriteLine("2.- Quantity of items in the cart");
                WriteLine("3.- Total cost");
                WriteLine("4.- Finalize purchase");
                WriteLine("5.- Exit");
                Write("Select a option: ");
                optionMenu = ReadLine();
                if (string.IsNullOrWhiteSpace(optionMenu)) optionMenu = "1";
                switch (optionMenu)
                {
                    case "1":
                        WriteLine();
                        WriteLine($"{new string('*', 10)} Items: {new string('*', 10)}");
                        for (var i = 0; i < _itemsForSale.Count; i++)
                        {
                            WriteLine($"{i+1}.- {_itemsForSale[i].Nombre} - ${_itemsForSale[i].Precio}");
                        }

                        Write("Select a item: ");
                        string optionItem = ReadLine();
                        if (!int.TryParse(optionItem, out int intOptionItem))
                        {
                            WriteLine("Wrong option");
                            break;
                        }

                        var item = _itemsForSale.ElementAtOrDefault(intOptionItem - 1);
                        if (item == null)
                        {
                            WriteLine("Wrong option");
                            break;
                        }

                        Write("Select quantity (default is 1): ");
                        string quantity = ReadLine();
                        if (string.IsNullOrWhiteSpace(quantity)) quantity = "1";

                        if (!int.TryParse(quantity, out int intQuantity))
                        {
                            WriteLine("Quantity not available");
                            break;
                        }

                        if (intQuantity < 1)
                        {
                            WriteLine("Quantity not available");
                            break;
                        }

                        item.Cantidad = intQuantity;
                        Cart.AgregarItem(item);
                        WriteLine($"{item.Cantidad} {item.Nombre} has been added to cart");
                        break;
                    case "2":
                        WriteLine($"You have {Cart.ObtenerCantidadItems()} items in your cart");
                        break;
                    case "3":
                        WriteLine($"Your cart total is ${Cart.ObtenerTotalCompra()}");
                        break;
                    case "4":
                        Cart.Comprar();
                        break;
                    case "5":
                        WriteLine("See you later, have a nice day");
                        break;
                    default:
                        WriteLine("Wrong option");
                        break;
                }
                WriteLine(Environment.NewLine);
            } while (optionMenu != "5");
        }

        private static void InicializeItems()
        {
            _itemsForSale = new List<Item>
            {
                new()
                {
                    Nombre = "Item001",
                    Cantidad = 1,
                    Precio = 15.5M
                },
                new()
                {
                    Nombre = "Item002",
                    Cantidad = 1,
                    Precio = 2.17M
                },
                new()
                {
                    Nombre = "Item003",
                    Cantidad = 1,
                    Precio = 10
                },
            };
        }
    }
}
