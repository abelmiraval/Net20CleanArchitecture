﻿using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Sales.BusinessObjects.Aggregates
{
    public class OrderAggregate : Order
    {
        readonly List<OrderDetail> OrderDetailsField = new();
        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;

        public void AddDetail(OrderDetail orderDetail)
        {
            var ExistingOrderDetail = OrderDetailsField.FirstOrDefault(
                o => o.ProductId == orderDetail.ProductId);

            if (ExistingOrderDetail != default)
            {
                OrderDetailsField.Add(
                    ExistingOrderDetail with
                    {
                        Quantity = (short)(orderDetail.Quantity + ExistingOrderDetail.Quantity)
                    });
                OrderDetailsField.Remove(ExistingOrderDetail);
            }
            else
            {
                OrderDetailsField.Add(orderDetail);
            }
        }

        public void AddDetail(int productId, decimal unitPrice, short quantity) =>
            AddDetail(new OrderDetail(productId, unitPrice, quantity));

        public static OrderAggregate From(CreateOrderDTO orderDTO)
        {
            OrderAggregate Order = new OrderAggregate()
            {
                CustomerId = orderDTO.CustomerId,
                ShipAddress = orderDTO.ShipAddress,
                ShipCity = orderDTO.ShipCity,
                ShipCountry = orderDTO.ShipCountry,
                ShipPostalCode = orderDTO.ShipPostalCode
            };

            foreach (var Item in orderDTO.OrderDetails)
            {
                Order.AddDetail(Item.ProductId, Item.UnitPrice, Item.Quantity);
            }
            return Order;
        }
    }
}
