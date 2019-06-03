using System;

namespace HypersWebshop.DataAccessLayer
{

    public class ProductAlreadyUpdatedException : Exception
    {
        public ProductAlreadyUpdatedException()
        {
        }

        public ProductAlreadyUpdatedException(string message)
            : base(message)
        {
        }
    }
}