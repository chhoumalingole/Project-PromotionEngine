using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = new List<Product>
            {
                new Product{ SKUName="A", SKUPrice=50 },
                new Product{ SKUName="B", SKUPrice=30 },
                new Product{ SKUName="C", SKUPrice=20 },
                new Product{ SKUName="D", SKUPrice=15 },

            };

            List<Cart> cartItems = new List<Cart>();

            Console.WriteLine("***********************Promotion Engine***********************");
            Console.WriteLine("***********************SKU List***********************");

            Console.WriteLine("\n");

            foreach (var item in products)
            {
                Console.WriteLine("SKU: " + item.SKUName + " Price: " + item.SKUPrice);
            }

            Console.WriteLine("\n");

            Console.WriteLine("***********************Building Shopping Cart***********************");

            foreach (var item in products)
            {
                string userInput;
                Console.WriteLine("Enter SKU " + item.SKUName + " Quantity:");
                userInput = Console.ReadLine();
                int SKUQuantity;

                while(!int.TryParse(userInput, out SKUQuantity))
                {
                    Console.WriteLine("Please enter integer value only");
                    Console.WriteLine("Enter SKU " + item.SKUName + " Quantity:");
                    userInput = Console.ReadLine();
                }

                Cart cartItem = new Cart()
                {
                    SKUName = item.SKUName,
                    SKUQuantity = SKUQuantity
                };

                cartItems.Add(cartItem);
            }

            Console.WriteLine("\n");

            Console.WriteLine("***********************Cart Summary***********************");

            foreach (var item in cartItems)
            {
                Console.WriteLine("SKU Name: " + item.SKUName + " SKU Quantity: " + item.SKUQuantity);
            }

            Promotion1 obj = new Promotion1(products, cartItems);
            int totalPrice = obj.ApplyPromotionAndCalculatePrice();

            Console.WriteLine("Total Price: " + totalPrice);

            Console.ReadKey();
        }
    }
}
