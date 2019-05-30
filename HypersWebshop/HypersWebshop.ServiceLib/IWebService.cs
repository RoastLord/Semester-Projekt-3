using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HypersWebshop.ServiceLib
{
    [ServiceContract]
    public interface IWebService
    {
        [OperationContract]
        CompositeProduct FindProduct(int id);

        [OperationContract]
        List<CompositeProduct> FindProductsByDescription(Product_Description description);

        [OperationContract]
        List<CompositeProduct> FindProductsByStatus(Product_Status status);

        [OperationContract]
        void CreateCustomer(CompositeCustomer composite);

        [OperationContract]
        string ProcessSale(List<CompositeProduct> compProducts, CompositeCustomer compCustomer);

    }
}
