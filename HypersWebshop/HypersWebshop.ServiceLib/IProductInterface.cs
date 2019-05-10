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
    public interface IProductInterface
    {

        [OperationContract]
        void CreateProduct(Product product);

        [OperationContract]
        Product FindProduct(int id);

        [OperationContract]
        List<CompositeType> FindProductsByStatus(Product_Status status);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        void ggwp();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "HypersWebshop.ServiceLib.ContractType".
    [DataContract]
    public class CompositeType
    {
        public string name;
        public long price;
        public long purchasePrice;
        public Product_Description productDescription;
        public Product_Status productStatus;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public long Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public long PurchasePrice
        {
            get { return purchasePrice; }
            set { purchasePrice = value; }
        }

        [DataMember]
        public Product_Description ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }

        [DataMember]
        public Product_Status Product_Status
        {
            get { return productStatus; }
            set { productStatus = value; }
        }

        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
