﻿using HypersWebshop.Domain;
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

        public Product ProcessSale(Order order)
        {
            OrderLine orderLine = order.OrderLines.Peek();
            Product product = orderLine.Product;
            Customer customer = order.Customer;
            Boolean paid = true;
            ProductController productController = new ProductController();

            if (paid)
            {

                if (product.ProductStatus != Product_Status.Published)
                {
                    //Skal eftertjekkes
                    Console.WriteLine("Error, produktet er ikke tilgængeligt");
                }
                else
                {
                    //Sætter produktets status til solgt
                    productController.ChangeProductStatus(product, Product_Status.Sold);
                }
            }
            else
            {
                Console.WriteLine("Betalingen gik ikke gennem");
            }
            PrintReceipt(order);
            return product;
        }

        private string PrintReceipt(Order order)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (OrderLine orderLine in order.OrderLines)
            {
                stringBuilder.AppendLine(orderLine.Amount.ToString());
                stringBuilder.AppendLine(orderLine.Price.ToString());
                stringBuilder.AppendLine(orderLine.Product.Name);
                stringBuilder.AppendLine(orderLine.TotalPrice.ToString());
                stringBuilder.AppendLine();
                stringBuilder.AppendLine(order.Customer.Name);
                stringBuilder.AppendLine(order.Customer.Address);
                stringBuilder.AppendLine(order.Customer.City);
                stringBuilder.AppendLine(order.Customer.Email);
                stringBuilder.AppendLine(order.Customer.PhoneNo);
            }

            return stringBuilder.ToString();

        }
    }
}
