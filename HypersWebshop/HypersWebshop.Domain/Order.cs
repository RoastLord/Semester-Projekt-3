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
        public float totalPrice { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Order(int orderNo, float totalPrice, DateTime date, DateTime deliveryDate)
        {
            OrderNo = orderNo;
            this.totalPrice = totalPrice;
            Date = date;
            DeliveryDate = deliveryDate;
        }
    }
}
