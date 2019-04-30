using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.Domain
{
    public class Order
    {
        public int OrderNo { get; set; }
        public long TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Customer Customer { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        

        public Order(int orderNo, long totalPrice, DateTime date, DateTime deliveryDate, Customer customer)
        {
            OrderNo = orderNo;
            TotalPrice = totalPrice;
            Date = date;
            DeliveryDate = deliveryDate;
            Customer = customer;
            OrderLines = new List<OrderLine>();
        }

        public Order(long totalPrice, DateTime date, DateTime deliveryDate, Customer customer)
        {
            TotalPrice = totalPrice;
            Date = date;
            DeliveryDate = deliveryDate;
            Customer = customer;
            OrderLines = new List<OrderLine>();
        }

        public void AddToOrderLine(OrderLine orderLine)
        {
            OrderLines.Add(orderLine);
        }
    }
}
