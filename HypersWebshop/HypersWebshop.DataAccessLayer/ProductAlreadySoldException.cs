using System;

namespace HypersWebshop.DataAccessLayer
{

    public class ProductAlreadySoldException : Exception
    {
        public ProductAlreadySoldException()
        {
        }

        public ProductAlreadySoldException(string message)
            : base(message)
        {
        }
    }
}