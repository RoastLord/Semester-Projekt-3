using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.BusinessLogic
{
    public class OrderController : ICRUD<Order>
    {
        public void create(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(string phoneNo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public void ProcessSale(Order order)
        {
            OrderLine orderLine = order.OrderLines.Peek();
            Product product = orderLine.Product;
            Customer customer = order.Customer;
            ProductController productController = new ProductController();

            if (product.AmountInStock < orderLine.Amount)
            {
                throw new Exception("Det er lidt en cancer");
            }

            if(IsPaid(order))
            {
                productController.ChangeProductStatus(product, Product_Status.Sold);
                PrintReceipt(order);
                
            }
            
        }

        private bool IsPaid(Order order)
        {
            //NETS logik
            return true;
        }

        private string PrintReceipt(Order order)
        {
            StringBuilder stringBuilder = new StringBuilder();

            
            stringBuilder.AppendLine(order.OrderNo.ToString());
            stringBuilder.AppendLine(order.Customer.Name);
            stringBuilder.AppendLine(order.Customer.Address);
            stringBuilder.AppendLine(order.Customer.City);
            stringBuilder.AppendLine(order.Customer.Email);
            stringBuilder.AppendLine(order.Customer.PhoneNo);
            stringBuilder.AppendLine();

            foreach (OrderLine orderLine in order.OrderLines)
            {
                stringBuilder.AppendLine(orderLine.Amount.ToString());
                stringBuilder.AppendLine(orderLine.Price.ToString());
                stringBuilder.AppendLine(orderLine.Product.Name);
                stringBuilder.AppendLine(orderLine.TotalPrice.ToString());

            }

            return stringBuilder.ToString();

            

        }
    }
}
