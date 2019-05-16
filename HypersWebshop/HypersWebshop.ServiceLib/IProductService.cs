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


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "HypersWebshop.ServiceLib.ContractType".
    [DataContract]
    public class CompositeProduct
    {
        public int productId;
        public string name;
        public long price;
        public long purchasePrice;
        public Product_Description productDescription;
        public Product_Status productStatus;

        [DataMember]
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
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
        
    }
    [DataContract]
    public class CompositeCustomer
    {
        public string Name;
        public string Address;
        public string PhoneNo;
        public string Email;
        public int Zipcode;
        public string City;

        [DataMember]
        public string CustomerName
        {
            set { CustomerName = value; }
        }

        public String CustomerAddress
        {
            set { CustomerAddress = value; }
        }
        public String CustomerPhoneNo
        {
            set { CustomerPhoneNo = value; }
        }
        public String CustomerEmail
        {
            set { CustomerEmail = value; }
        }
        public int CustomerZipcode
        {
            set { CustomerZipcode = value; }
        }
        public String CustomerCity
        {
            set { CustomerCity = value; }
        }
    }
}
