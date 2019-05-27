using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HypersWebshop.ServiceLib
{
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

