using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HypersWebshop.ServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        void UpdateProduct(CompositeProduct composite);

        [OperationContract]
        int CreateProduct(CompositeProduct composite);

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


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "HypersWebshop.ServiceLib.ContractType".
    [DataContract]
    public class CompositeProduct
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public long Price { get; set; }

        [DataMember]
        public long PurchasePrice { get; set; }

        [DataMember]
        public Product_Description ProductDescription { get; set; }

        [DataMember]
        public Product_Status Product_Status { get; set; }
    }
    [DataContract]
    public class CompositeCustomer
    {
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string CustomerAddress { get; set; }
        [DataMember]
        public string CustomerPhoneNo { get; set; }
        [DataMember]
        public string CustomerEmail { get; set; }
        [DataMember]
        public int CustomerZipcode { get; set; }
        [DataMember]
        public string CustomerCity { get; set; }
    }
}
