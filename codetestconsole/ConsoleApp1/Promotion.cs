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
            PromotionData promotionA = new PromotionData(1, new List<OrderData>() { new OrderData(new ProductData("A", 50), 3) }, 130);
            PromotionData promotionB = new PromotionData(2, new List<OrderData>() { new OrderData(new ProductData("B", 30), 2) }, 45);
            PromotionData promotionCD = new PromotionData(3, new List<OrderData>() { new OrderData(new ProductData("C", 20), 1), new OrderData(new ProductData("D", 15), 1) }, 30);
            promotionDetails.AddRange(new PromotionData[] { promotionA, promotionB, promotionCD });

            return promotionDetails;
        }        
    }

    public class PromotionData
    {
        public int PromotionId { get; set; }
        public List<OrderData> OrderDetails { get; set; }
        public int PromotionPrice { get; set; }

        public PromotionData(int promotionId, List<OrderData> orderDetails, int PromotionPrice)
        {
            this.PromotionId = promotionId;
            this.OrderDetails = orderDetails;
            this.PromotionPrice = PromotionPrice;
        }
    }

}
