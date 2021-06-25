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

            Console.WriteLine("The total cost is: " + CalculateCost(orderDetails, promotionList));
            Console.ReadKey();

        }

        private static int CalculateCost(List<OrderData> orderDetails, List<PromotionData> promotionList)
        {
            int costOfPurchase = 0;

            foreach (OrderData ord in orderDetails)
            {
                if (ord.Qunatity == 0)
                    break;
                PromotionData promo = promotionList.Where(p => p.PromoProduct.ContainsKey(ord.ProductDetails.ProductName)).FirstOrDefault();

                int qunatity = promo.PromoProduct[ord.ProductDetails.ProductName];
                if (ord.Qunatity >= qunatity)
                {
                    if (promo.PromoProduct.Count > 1)
                    {

                        List<OrderData> promoLinkedOrder = new List<OrderData>();
                        foreach (string key in promo.PromoProduct.Keys)
                        {
                            OrderData promoLinkedOrderData = orderDetails.Where(o => o.ProductDetails.ProductName == key).FirstOrDefault();
                            promoLinkedOrder.Add(promoLinkedOrderData);
                        }

                        bool exit = false;
                        while (exit == false)
                        {
                            bool applyPromo = false;
                            foreach (OrderData pOrder in promoLinkedOrder)
                            {
                                if (pOrder.Qunatity >= promo.PromoProduct[pOrder.ProductDetails.ProductName])
                                    applyPromo = true;
                                else
                                {
                                    applyPromo = false;
                                    break;
                                }
                                
                            }
                            if (applyPromo == true)
                            {
                                costOfPurchase += (Convert.ToInt32(promoLinkedOrder.FirstOrDefault().Qunatity / promo.PromoProduct[promoLinkedOrder.FirstOrDefault().ProductDetails.ProductName])) * promo.PromotionPrice;
                                foreach (OrderData promoOrder in promoLinkedOrder)
                                {
                                    promoOrder.Qunatity -= promo.PromoProduct[promoOrder.ProductDetails.ProductName];
                                    OrderData originalData = orderDetails.Where(o => o.ProductDetails.ProductName == promoOrder.ProductDetails.ProductName).FirstOrDefault();
                                    int index = orderDetails.IndexOf(originalData);
                                    orderDetails[index].Qunatity = promoOrder.Qunatity;
                                }
                                applyPromo = false;
                            }
                            else
                            {
                                exit = true;
                                foreach (OrderData promoOrder in promoLinkedOrder)
                                {
                                    costOfPurchase += promoOrder.Qunatity * promoOrder.ProductDetails.Price;
                                }
                            }
                        }
                    }
                    else
                    {
                        costOfPurchase += ((Convert.ToInt32(ord.Qunatity / qunatity) * promo.PromotionPrice) + (ord.Qunatity % qunatity) * ord.ProductDetails.Price);
                    }
                }
                else
                {
                    costOfPurchase += (ord.ProductDetails.Price * qunatity);
                }                
            }
            return costOfPurchase;
        }
        

        
    }
}
