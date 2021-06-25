using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Promotion
    {
        public static List<PromotionData> ActivePromotions()
        {
            List<PromotionData> promotionDetails = new List<PromotionData>();
            PromotionData promotionA = new PromotionData(1, new Dictionary<string, int>() { {"A",3 } }, 130);
            PromotionData promotionB = new PromotionData(2, new Dictionary<string, int>() { { "B", 2 } }, 45);
            PromotionData promotionCD = new PromotionData(3, new Dictionary<string, int>() { { "C", 1 }, { "D", 1 } }, 30);
            promotionDetails.AddRange(new PromotionData[] { promotionA, promotionB, promotionCD });

            return promotionDetails;
        }

        public static int CalculateCost(List<OrderData> orderDetails, List<PromotionData> promotionList)
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
                                costOfPurchase += promo.PromotionPrice;
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
                                    OrderData originalData = orderDetails.Where(o => o.ProductDetails.ProductName == promoOrder.ProductDetails.ProductName).FirstOrDefault();
                                    int index = orderDetails.IndexOf(originalData);
                                    orderDetails[index].Qunatity = 0;
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
                    costOfPurchase += (ord.ProductDetails.Price * ord.Qunatity);
                }
            }
            return costOfPurchase;
        }
    }

    public class PromotionData
    {
        public int PromotionId { get; set; }
        public Dictionary<string, int> PromoProduct { get; set; }
        public int PromotionPrice { get; set; }

        public PromotionData(int promotionId, Dictionary<string,int> promoProduct, int PromotionPrice)
        {
            this.PromotionId = promotionId;
            this.PromoProduct = promoProduct;
            this.PromotionPrice = PromotionPrice;
        }
    }

}
