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
