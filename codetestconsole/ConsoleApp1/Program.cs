using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<ProductData> productList = Product.ListProducts();
            Order orders = new Order(productList);
            List<OrderData> orderDetails = orders.TakeOrder();
            List<PromotionData> promotionList = Promotion.ActivePromotions();

            Console.WriteLine("The total cost is: " + Calculator.CalculateCost(orderDetails, promotionList));
            Console.ReadKey();

            //Note: Please note my laptop was extremely slow. Hence i had to take multiple breaks.

        }        
    }
}
