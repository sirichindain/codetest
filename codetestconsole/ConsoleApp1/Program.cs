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

                int qunatity = promo.PromoProduct[ord.ProductDetails.ProductName];
                if (ord.Qunatity > qunatity)
                {
                    if (promo.PromoProduct.Count > 1)
                    {
                        bool applyPromo = false;
                        List<OrderData> promoLinkedOrder = new List<OrderData>();
                        foreach (string key in promo.PromoProduct.Keys)
                        {
                            OrderData promoLinkedOrderData = orderDetails.Where(o => o.ProductDetails.ProductName == key).FirstOrDefault();
                            promoLinkedOrder.Add(promoLinkedOrderData);
                        }

                        bool exit = false;
                        while (exit == false)
                        {
                            foreach (OrderData pOrder in promoLinkedOrder)
                            {
                                if (pOrder.Qunatity > promo.PromoProduct[pOrder.ProductDetails.ProductName])
                                    applyPromo = true;
                                else
                                    applyPromo = false;
                            }
                            if (applyPromo == true)
                            {
                                costOfPurchase += (Convert.ToInt32(promoLinkedOrder.FirstOrDefault().Qunatity / promo.PromoProduct[promoLinkedOrder.FirstOrDefault().ProductDetails.ProductName])) * promo.PromotionPrice;
                                foreach (OrderData promoOrder in promoLinkedOrder)
                                {
                                    promoOrder.Qunatity -= promo.PromoProduct[promoOrder.ProductDetails.ProductName];
                                }
                                applyPromo = false;
                            }
                            else
                            {
                                exit = true;
                                foreach (OrderData promoOrder in promoLinkedOrder)
                                {
                                    costOfPurchase += (promoLinkedOrder.FirstOrDefault().Qunatity % promo.PromoProduct[promoLinkedOrder.FirstOrDefault().ProductDetails.ProductName]) * promo.PromotionPrice;
                                }
                            }
                        }


                            //foreach (OrderData promoOrder in promoLinkedOrder)
                            //{
                            //    int promoQunatity = promo.PromoProduct[promoOrder.ProductDetails.ProductName];
                            //    costOfPurchase += Convert.ToInt32(promoOrder.Qunatity / promoQunatity) * promo.PromotionPrice + (promoOrder.Qunatity % promoQunatity) * promoOrder.ProductDetails.Price;
                            //}
                        
                    }
                    else
                    {
                        costOfPurchase += (Convert.ToInt32(ord.Qunatity / qunatity) * promo.PromotionPrice + (ord.Qunatity % qunatity)) * ord.ProductDetails.Price;
                    }
                }
                else
                {
                    costOfPurchase += ord.ProductDetails.Price * qunatity;
                }
            }
            
                
            
        }

        

        
    }
}
