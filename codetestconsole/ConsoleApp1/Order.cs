using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        List<ProductData> productList;
        
        public Order(List<ProductData> products)
        {
            this.productList = products;
        }
        public List<OrderData> TakeOrder()
        {
            List<OrderData> OrderDetails = new List<OrderData>();
            foreach (ProductData p in productList)
            {
                Console.WriteLine("Please enter the quantity of product " + p.ProductName + " required");
                OrderData data = new OrderData(p, Convert.ToInt32(Console.ReadLine()));
                OrderDetails.Add(data);
            }

            return OrderDetails;
        }
    }

    public class OrderData
    {
        public ProductData ProductDetails { get; set; }
        public int Qunatity { get; set; }

        public OrderData(ProductData productDetails, int qunatity)
        {
            this.ProductDetails = productDetails;
            this.Qunatity = qunatity;
        }
    }
}
