using System;
using System.Collections.Generic;
using System.Text;
using EnumeracaoComposicao.Entities.Enums;

namespace EnumeracaoComposicao.Entities
{
    public class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Client Client { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus orderStatus, Client client)
        {
            Moment = moment;
            OrderStatus = orderStatus;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public double Total()
        {
            double total = 0;
            foreach (OrderItem item in Items)
            {
                total += item.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine($"Order Moment: {Moment.ToString("dd/MM/yyyy MM:ss")}");
            sb.AppendLine($"Order Status: {OrderStatus.ToString()}");
            sb.AppendLine($"Client: {Client}");
            sb.AppendLine("Order Items:");
            foreach (OrderItem oItem in Items)
                sb.AppendLine(oItem.ToString());

            return sb.ToString();
        }
    }
}
