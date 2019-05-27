using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.ServiceLib
{
    [ServiceContract]
    public interface IDesktopService
    {
        [OperationContract]
        int UpdateProduct(CompositeProduct composite);

        [OperationContract]
        int CreateProduct(CompositeProduct composite);

        [OperationContract]
        List<CompositeProduct> FindProductsByDescription(Product_Description description);

        [OperationContract]
        List<CompositeProduct> FindProductsByStatus(Product_Status status);

        //[OperationContract]
        //CompositeProduct FindProduct(int id);
    }
}
