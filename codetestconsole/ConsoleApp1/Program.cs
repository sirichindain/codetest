using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<ProductData> productList = Product.ListProducts();
            Order orders = new Order(productList);
            List<OrderData> orderDetails = orders.TakeOrder();
            List<PromotionData> promotionList = Promotion.ActivePromotions();

            int costOfPurchase = 0;
            //foreach(PromotionData promo in promotionList)
            //{
            //    orderDetails.Where(o => o.ProductDetails.ProductName)
            //}
            foreach (OrderData ord in orderDetails)
            {
                PromotionData promo = promotionList.Where(p => p.PromoProduct.ContainsKey(ord.ProductDetails.ProductName)).FirstOrDefault();

                if(promo.PromoProduct.Count > 1)
                { 

                }
                else
                {
                    int qunatity = promo.PromoProduct[ord.ProductDetails.ProductName];
                    if (ord.Qunatity > qunatity)
                    {
                        costOfPurchase += Convert.ToInt32(ord.Qunatity / qunatity) * promo.PromotionPrice + (ord.Qunatity % qunatity) * ord.ProductDetails.Price;
                    }
                    else
                    {
                        costOfPurchase += ord.ProductDetails.Price * qunatity;
                    }
                }
            }
            
                
            
        }

        

        
    }
}
