using NUnit.Framework;
using receipt_processor.Models;
using receipt_processor.Services;
using System;
using System.Collections.Generic;

namespace receipt_processor.Tests
{
    [TestFixture]
    public class ReceiptPointsCalculatorTests
    {
        private ReceiptPointsCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new ReceiptPointsCalculator();
        }

        [Test]
        public void CalculatePoints_ComplexReceipt_ReturnsCorrectTotalPoints()
        {
            var receipt = new Receipt
            {
                retailer = "Target",
                total = "35.50",
                purchaseDate = "2023-11-03",
                purchaseTime = "14:30",
                items = new List<Item>
                {
                    new Item
                    {
                        shortDescription = "Milk",
                        price = "3.50"
                    },
                    new Item
                    {
                        shortDescription = "Bread",
                        price = "2.25"
                    }
                }
            };

            var points = _calculator.CalculatePoints(receipt);
            Assert.AreEqual(52, points);
        }
    }
}