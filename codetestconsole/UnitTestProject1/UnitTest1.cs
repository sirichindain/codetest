using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            List<ProductData> productList = Product.ListProducts();
            List<OrderData> OrderDetails = new List<OrderData>();

            OrderData data1 = new OrderData(productList[0], 1);
            OrderData data2 = new OrderData(productList[1], 1);
            OrderData data3 = new OrderData(productList[2], 1);
            OrderData data4 = new OrderData(productList[3], 0);
            OrderDetails.AddRange(new OrderData[] { data1, data2, data3, data4 });
            List<PromotionData> promotionList = Promotion.ActivePromotions();
            int cost = Calculator.CalculateCost(OrderDetails, promotionList);

        }

        [TestMethod]
        public void TestMethod2()
        {
            List<ProductData> productList = Product.ListProducts();
            List<OrderData> OrderDetails = new List<OrderData>();

            OrderData data1 = new OrderData(productList[0], 5);
            OrderData data2 = new OrderData(productList[1], 5);
            OrderData data3 = new OrderData(productList[2], 1);
            OrderData data4 = new OrderData(productList[3], 0);
            OrderDetails.AddRange(new OrderData[] { data1, data2, data3, data4 });
            List<PromotionData> promotionList = Promotion.ActivePromotions();
            int cost = Calculator.CalculateCost(OrderDetails, promotionList);

        }

        [TestMethod]
        public void TestMethod3()
        {
            List<ProductData> productList = Product.ListProducts();
            List<OrderData> OrderDetails = new List<OrderData>();

            OrderData data1 = new OrderData(productList[0], 3);
            OrderData data2 = new OrderData(productList[1], 5);
            OrderData data3 = new OrderData(productList[2], 1);
            OrderData data4 = new OrderData(productList[3], 1);
            OrderDetails.AddRange(new OrderData[] { data1, data2, data3, data4 });
            List<PromotionData> promotionList = Promotion.ActivePromotions();
            int cost = Calculator.CalculateCost(OrderDetails, promotionList);

        }
    }
}
