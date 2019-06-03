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

        private void IsProductPublished(List<OrderLine> orderLines)
        {
            foreach (OrderLine orderLine in orderLines)
            {
                if (productController.FindProduct(orderLine.Product.ProductId).ProductStatus != Product_Status.Published)
                {
                    throw new ProductAlreadyUpdatedException(orderLine.Product.Name);
                }
            }
        }

        public string ProcessSale(Order order)
        {
            try
            {
                IsProductPublished(order.OrderLines);
                if (IsPaid(order))
                {
                    List<OrderLine> orderLines = order.OrderLines;
                    foreach (OrderLine orderLine in orderLines)
                    {
                        Product p = productController.FindProduct(orderLine.Product.ProductId);
                        p.ProductStatus = Product_Status.Sold;
                        int rows = productController.UpdateProduct(p);
                    }
                    // Save all information in the database
                    order.OrderNo = CreateOrder(order);
                    if (personController.GetCustomer(order.Customer.PhoneNo) == null)
                    {
                        personController.CreateCustomer(order.Customer);
                    }
                    
                    foreach (OrderLine orderLine in order.OrderLines)
                    {
                        AddOrderlineToOrder(order.OrderNo, orderLine);
                    }
                    personController.AddOrderToCustomer(order.OrderNo, order.Customer);
                }
                return PrintReceipt(order);
            }
            catch(ProductAlreadyUpdatedException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool IsRowsAffected(int rows)
        {
            bool check = true;
            if (rows == 0)
                check = false;

            return check;
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
