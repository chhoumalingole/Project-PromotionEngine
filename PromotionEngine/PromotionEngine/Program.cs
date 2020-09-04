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

            Console.WriteLine("***********************Promotion Engine***********************");
            Console.WriteLine("***********************SKU List***********************");

            Console.WriteLine("\n");

            foreach (var item in products)
            {
                Console.WriteLine("SKU: " + item.SKUName + " Price: " + item.SKUPrice);
            }

            Console.ReadKey();
        }
    }
}
