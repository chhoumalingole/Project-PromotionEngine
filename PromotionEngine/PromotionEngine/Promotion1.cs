using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PromotionEngine
{
    class Promotion1 : IPromotion
    {
        private List<Cart> _cart;
        private List<Product> _product;

        public Promotion1(List<Product> products, List<Cart> carts)
        {
            _product = products;
            _cart = carts;
        }

        public int ApplyPromotionAndCalculatePrice()
        {
            int TotalPrice = 0;

            int SKUAPrice = 0;
            int SKUBPrice = 0;
            int SKUC_DPrice = 0;

            int SKUAQuantity = 0;
            int SKUBQuantity = 0;
            int SKUCQuantity = 0;
            int SKUDQuantity = 0;

            int SKUAPricePerItem = 0;
            int SKUBPricePerItem = 0;
            int SKUCPricePerItem = 0;
            int SKUDPricePerItem = 0;

            SKUAQuantity = FetchSKUQuantityDetails("A");
            SKUBQuantity = FetchSKUQuantityDetails("B");
            SKUCQuantity = FetchSKUQuantityDetails("C");
            SKUDQuantity = FetchSKUQuantityDetails("D");

            SKUAPricePerItem = FetchSKUPricePerItem("A");
            SKUBPricePerItem = FetchSKUPricePerItem("B");
            SKUCPricePerItem = FetchSKUPricePerItem("C");
            SKUDPricePerItem = FetchSKUPricePerItem("D");
            
            // Calculation Promotion for SKU A
            if(SKUAQuantity < 3)
            {
                SKUAPrice = SKUAQuantity * SKUAPricePerItem;
            }
            else
            {
                int promotionQuantity = SKUAQuantity / 3;
                int remainingQuantity = SKUAQuantity % 3;

                SKUAPrice = (promotionQuantity * 130) + (remainingQuantity * SKUAPricePerItem);
            }

            

            if (SKUBQuantity < 2)
            {
                SKUBPrice = SKUBQuantity * SKUBPricePerItem;
            }
            else
            {
                int promotionQuantity = SKUBQuantity / 2;
                int remainingQuantity = SKUBQuantity % 2;

                SKUBPrice = (promotionQuantity * 45) + (remainingQuantity * SKUBPricePerItem);
            }

            

            //Applying Promotion for SKU C + SKU D

            if(SKUCQuantity < SKUDQuantity)
            {
                int quantityDiff = SKUDQuantity - SKUCQuantity;

                SKUC_DPrice = ((SKUDQuantity - quantityDiff) * 30) + (quantityDiff * SKUDPricePerItem);

            }
            else if(SKUCQuantity > SKUDQuantity)
            {
                int quantityDiff = SKUCQuantity - SKUDQuantity;

                SKUC_DPrice = ((SKUCQuantity - quantityDiff) * 30) + (quantityDiff * SKUCPricePerItem);
            }
            else
            {
                SKUC_DPrice = SKUCQuantity * 30;
            }

            Console.WriteLine("\n");

            Console.WriteLine("***********************Cart Pricing Summary***********************");

            Console.WriteLine("SKU A Price: " + SKUAPrice);
            Console.WriteLine("SKU B Price: " + SKUBPrice);
            Console.WriteLine("SKU C & SKU D Combined Price: " + SKUC_DPrice);

            TotalPrice = SKUAPrice + SKUBPrice + SKUC_DPrice;

            return TotalPrice;
        }

        private int FetchSKUPricePerItem(string SKUName)
        {
            int SKUPricePerItem = 0;

            SKUPricePerItem = Convert.ToInt32(_product.Where(q => q.SKUName == SKUName).Select(q => q.SKUPrice).FirstOrDefault());

            return SKUPricePerItem;
        }

        private int FetchSKUQuantityDetails(string SKUName)
        {
            int SKUQuantity = 0;

            SKUQuantity = Convert.ToInt32(_cart.Where(q => q.SKUName == SKUName).Select(q => q.SKUQuantity).FirstOrDefault());

            return SKUQuantity;
        }


    }
}
