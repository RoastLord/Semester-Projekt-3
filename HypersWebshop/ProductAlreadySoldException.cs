using System;

namespace HypersWebshop.DataAccesLayer {

    public class ProductAlreadySoldException : Exception
    {
        publicProductAlreadySoldException()
        {
        }

        public ProductAlreadySoldException(string message)
            : base(message)
        {
        }
    }