using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Supermarket_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ProductData> inventory = new Dictionary<string, ProductData>();

            while (true) {

                string[] input = Console.ReadLine().Trim().Split();
                if (input[0] == "stocked") break;

                string productName = input[0];
                float productPrice = float.Parse(input[1]);
                int productQuantity = int.Parse(input[2]);

                if (!inventory.ContainsKey(productName)) {
                    inventory[productName] = new ProductData(productPrice, productQuantity);
                }
                else {
                    inventory[productName].price = productPrice;
                    inventory[productName].quantity += productQuantity;
                }
            }

            float grandTotal = 0.0f;

            foreach (KeyValuePair<string, ProductData> item in inventory) {
                float itemPrice = item.Value.price * item.Value.quantity;
                Console.WriteLine($"{item.Key}: ${item.Value.price:F2} * {item.Value.quantity} = ${itemPrice:F2}");
                grandTotal += itemPrice;
            }

            Console.WriteLine($"{new string('-', 30)}");
            Console.WriteLine($"Grand Total: ${grandTotal:F2}");
        }
    }

    class ProductData
    {
        public float price;
        public int quantity;

        public ProductData(float price,int quantity)
        {
            this.price = price;
            this.quantity = quantity;
        }
    }
}
