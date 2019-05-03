using HypersWebshop.DataAccessLayer;
using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.BusinessLogic
{
    public class OrderController
    {
        DBOrder dBOrder = new DBOrder();
        ProductController productController = new ProductController();

        public void RemoveProductFromShoppingcart(int orderNo, int productId)
        {
            dBOrder.RemoveProductFromOrder(orderNo, productId);
        }

        public int RemoveAllProducts(int orderNo)
        {
            return dBOrder.RemoveAllProductsFromOrder(orderNo);
        }
        public void AddOrderlineToOrder(int orderNo, OrderLine orderLine)
        {   
            dBOrder.CreateOrderline(orderNo, orderLine);
        }

        public int CreateOrder(Order order)
        {
            return dBOrder.CreateOrder(order);
        }

        public void ProcessSale(Order order)
        {
            {
                if (IsPaid(order))
                {
                    List<OrderLine> orderLines = dBOrder.FindOrderLines(order.OrderNo);
                    Console.WriteLine(orderLines.Count);
                    foreach(OrderLine orderLine in orderLines)
                    {
                        productController.ChangeProductStatus(orderLine.Product, Product_Status.Sold);
                        Console.WriteLine("Kommer den herind??");
                    }
                    Console.WriteLine("Salg gik igennem");
                //PrintReceipt(order);
                }
            }
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
            stringBuilder.AppendLine(order.TotalPrice.ToString());

            foreach (OrderLine orderLine in order.OrderLines)
            {

                stringBuilder.AppendLine(orderLine.Product.Name);
                stringBuilder.AppendLine(orderLine.Product.Price.ToString());

            }

            return stringBuilder.ToString();
        }

        public List<OrderLine> GetOrderLines(int orderNo)
        {
            return dBOrder.FindOrderLines(orderNo);
        }

        private bool IsPaid(Order order)
        {
            //NETS logik
            return true;
        }

        //private bool CheckAmount(List<OrderLine> orderLines)
        //{
        //    bool check = false;
        //    DBProduct dBProduct = new DBProduct();
        //    foreach (OrderLine orderLine in orderLines)
        //    {
        //        Product p = dBProduct.Get(orderLine.Product.ProductId);
        //        if (p.AmountInStock > orderLine.Amount)
        //        {
        //            check = true;
        //        }
        //        else
        //        {
        //            throw new Exception("Der er ikke nok " + p.Name + " på lager");
        //        }

        //    }
        //    return check;
        //}

    }
}
