using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Product
    {
        
        public static List<ProductData> ListProducts()
        {
            List<ProductData> productList = new List<ProductData>();

            ProductData A = new ProductData("A", 50);
            ProductData B = new ProductData("B", 30);
            ProductData C = new ProductData("C", 20);
            ProductData D = new ProductData("D", 15);
            productList.AddRange(new ProductData[] { A, B, C, D });

            foreach(ProductData p in productList)
            {
                Console.WriteLine("Product Name: " + p.ProductName + ";  Price: " + p.Price);
            }

            return productList;

        }        
    }

    public class ProductData
    {
        public string ProductName { get; set; }
        public int Price { get; set; }

        public ProductData(string productName, int price)
        {
            this.ProductName = productName;
            this.Price = price;
        }
    }
}
