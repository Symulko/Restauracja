using Restaurant.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Builders
{
    public class OrderBuilder
    {
        private Order _order;
        public int TestCommentId => 234;
        public DateTime TestOrderDate => DateTime.Now;
        public int TestItemsTotal => 3;
        public string TestCommentBody => "Without soda";
        public Comment TestComment { get; }

        public int TestProductId => 1;
        public string TestProductName => "Margheritta";
        public decimal TestProductPrice => 20m;
        public Product TestProduct { get; }

        public int TestProductTypeId => 1;
        public string TestProductTypeName => "Pizza";
        public ProductType TestProductType { get; }
        public decimal TestUnitPrice => 5m;
        public int TestUnits => 3;
        public OrderBuilder()
        {
            TestComment = new Comment(TestCommentId, TestCommentBody);
            TestProductType = new ProductType(TestProductTypeId, TestProductTypeName);
            TestProduct = new Product(TestProductId, TestProductType, TestProductName, TestProductPrice);
            _order = WithDefaultValues();
        }

        public Order Build()
        {
            return _order;
        }

        public Order WithDefaultValues()
        {
            var orderItem = new OrderItem(TestProduct, TestUnitPrice, TestUnits);
            var itemList = new List<OrderItem>() { orderItem };
            _order = new Order(TestComment, itemList);
            return _order;
        }

        public Order WithNoItems()
        {
            _order = new Order(TestComment, new List<OrderItem>());
            return _order;
        }

        public Order WithItems(List<OrderItem> items)
        {
            _order = new Order(TestComment, items);
            return _order;
        }
    }
}
