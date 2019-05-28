using HypersWebshop.DataAccessLayer;
using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.BusinessLogic
{
    public class OrderController
    {
        DBOrder dBOrder = new DBOrder();
        ProductController productController = new ProductController();
        PersonController personController = new PersonController();


        public void AddOrderlineToOrder(int orderNo, OrderLine orderLine)
        {   
            dBOrder.CreateOrderline(orderNo, orderLine);
        }

        public int CreateOrder(Order order)
        {
            return dBOrder.CreateOrder(order);
        }

        private bool IsProductPublished(List<OrderLine> orderLines)
        {
            bool check = true;
            foreach(OrderLine orderLine in orderLines)
            {
                if(orderLine.Product.ProductStatus != Product_Status.Published)
                {
                    check= false;
                }
            }
            return check;
        }

        public string ProcessSale(Order order)
        {
            {
                if(!IsProductPublished(order.OrderLines))
                {
                    throw new FaultException("The product isnt published");
                }
                if (IsPaid(order))
                {
                    List<OrderLine> orderLines = FindOrderLines(order.OrderNo);
                    Console.WriteLine(orderLines.Count);
                    foreach(OrderLine orderLine in orderLines)
                    {
                        Product p = orderLine.Product;
                        p.ProductStatus = Product_Status.Sold;
                        productController.UpdateProduct(p);
                    }
                    Console.WriteLine("Salg gik igennem");

                    personController.AddOrderToCustomer(order.OrderNo, order.Customer);
                
                }
                return PrintReceipt(order);
            }
        }

        private string PrintReceipt(Order order)
        {
            StringBuilder stringBuilder = new StringBuilder();

            
            stringBuilder.AppendLine("Order Number" + order.OrderNo.ToString());
            stringBuilder.AppendLine("Name: " + order.Customer.Name);
            stringBuilder.AppendLine("Address: " + order.Customer.Address);
            stringBuilder.AppendLine("City: " + order.Customer.City);
            stringBuilder.AppendLine("Email: " + order.Customer.Email);
            stringBuilder.AppendLine("Phone Number: " + order.Customer.PhoneNo);
            

            foreach (OrderLine orderLine in order.OrderLines)
            {

                stringBuilder.AppendLine("Product: " + orderLine.Product.Name);
                stringBuilder.AppendLine("Description: " + orderLine.Product.ProductDescription);
                stringBuilder.AppendLine("Price: " + orderLine.Product.Price.ToString());

            }
            stringBuilder.AppendLine("Total Price: " + order.TotalPrice.ToString());

            return stringBuilder.ToString();
        }

        public List<OrderLine> FindOrderLines(int orderNo)
        {
            return dBOrder.FindOrderLines(orderNo);
        }

        private bool IsPaid(Order order)
        {
            //NETS logik
            return true;
        }

        //public void RemoveProductFromShoppingcart(int orderNo, int productId)
        //{
        //    dBOrder.RemoveProductFromOrder(orderNo, productId);
        //}
        //
        //public int RemoveAllProducts(int orderNo)
        //{
        //    return dBOrder.RemoveAllProductsFromOrder(orderNo);
        //}

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
