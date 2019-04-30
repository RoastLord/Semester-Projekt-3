using HypersWebshop.DataAccessLayer;
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
        DBOrder dBOrder = new DBOrder();
        ProductController productController = new ProductController();

        public void RemoveProductFromShoppingcart(int orderNo, int productId)
        {
            dBOrder.RemoveProduct(orderNo, productId);
        }
        public void Create(Order entity)
        {
            throw new NotImplementedException();
        }
        public void AddOrderlineToOrder(int orderNo, OrderLine orderLine)
        {   
            dBOrder.CreateOrderline(orderNo, orderLine);
        }
        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
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

        private bool CheckAmount(List<OrderLine> orderLines)
        {
            bool check = false;
            DBProduct dBProduct = new DBProduct();
            foreach (OrderLine orderLine in orderLines)
            {
                Product p = dBProduct.Get(orderLine.Product.ProductId);
                if (p.AmountInStock > orderLine.Amount)
                {
                    check = true;
                }
                else
                {
                    throw new Exception("Der er ikke nok " + p.Name + " på lager");
                }

            }
            return check;
        }

        public void ProcessSale(Order order)
        {
            List<OrderLine> orderLines = order.OrderLines;
            // Slet tjek om den er på lager
            if(CheckAmount(orderLines))
            {
                if (IsPaid(order))
                {
                    foreach(OrderLine orderLine in orderLines)
                    {
                        Product product = orderLine.Product;
                        product.ProductStatus = Product_Status.Sold;
                        //slet amount in stock
                        product.AmountInStock -= orderLine.Amount;
                        productController.Update(product);
                    }
                PrintReceipt(order);
                }
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

        public IEnumerable<Order> GetAll(Enum productDescription)
        {
            throw new NotImplementedException();
        }
    }
}
