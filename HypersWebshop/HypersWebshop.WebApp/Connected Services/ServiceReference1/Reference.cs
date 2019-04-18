﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HypersWebshop.WebApp.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/HypersWebshop.Domain")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AmountInStockField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HypersWebshop.WebApp.ServiceReference1.Product_Description ProductDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HypersWebshop.WebApp.ServiceReference1.Product_Status ProductStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long PurchasePriceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AmountInStock {
            get {
                return this.AmountInStockField;
            }
            set {
                if ((this.AmountInStockField.Equals(value) != true)) {
                    this.AmountInStockField = value;
                    this.RaisePropertyChanged("AmountInStock");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public HypersWebshop.WebApp.ServiceReference1.Product_Description ProductDescription {
            get {
                return this.ProductDescriptionField;
            }
            set {
                if ((this.ProductDescriptionField.Equals(value) != true)) {
                    this.ProductDescriptionField = value;
                    this.RaisePropertyChanged("ProductDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductId {
            get {
                return this.ProductIdField;
            }
            set {
                if ((this.ProductIdField.Equals(value) != true)) {
                    this.ProductIdField = value;
                    this.RaisePropertyChanged("ProductId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public HypersWebshop.WebApp.ServiceReference1.Product_Status ProductStatus {
            get {
                return this.ProductStatusField;
            }
            set {
                if ((this.ProductStatusField.Equals(value) != true)) {
                    this.ProductStatusField = value;
                    this.RaisePropertyChanged("ProductStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long PurchasePrice {
            get {
                return this.PurchasePriceField;
            }
            set {
                if ((this.PurchasePriceField.Equals(value) != true)) {
                    this.PurchasePriceField = value;
                    this.RaisePropertyChanged("PurchasePrice");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product_Description", Namespace="http://schemas.datacontract.org/2004/07/HypersWebshop.Domain")]
    public enum Product_Description : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Harddisk = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RAM = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Batteri = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Strømforsyning = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GPU = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CPU_Køling = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Motherboard = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CPU = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Optisk_Drev = 8,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product_Status", Namespace="http://schemas.datacontract.org/2004/07/HypersWebshop.Domain")]
    public enum Product_Status : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Sold = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Published = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unpublished = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Tested = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Untested = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Rejected = 5,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/HypersWebshop.ServiceLib")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AmountInStockField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HypersWebshop.WebApp.ServiceReference1.Product_Description ProductDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HypersWebshop.WebApp.ServiceReference1.Product_Status Product_StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long PurchasePriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AmountInStock {
            get {
                return this.AmountInStockField;
            }
            set {
                if ((this.AmountInStockField.Equals(value) != true)) {
                    this.AmountInStockField = value;
                    this.RaisePropertyChanged("AmountInStock");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public HypersWebshop.WebApp.ServiceReference1.Product_Description ProductDescription {
            get {
                return this.ProductDescriptionField;
            }
            set {
                if ((this.ProductDescriptionField.Equals(value) != true)) {
                    this.ProductDescriptionField = value;
                    this.RaisePropertyChanged("ProductDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public HypersWebshop.WebApp.ServiceReference1.Product_Status Product_Status {
            get {
                return this.Product_StatusField;
            }
            set {
                if ((this.Product_StatusField.Equals(value) != true)) {
                    this.Product_StatusField = value;
                    this.RaisePropertyChanged("Product_Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long PurchasePrice {
            get {
                return this.PurchasePriceField;
            }
            set {
                if ((this.PurchasePriceField.Equals(value) != true)) {
                    this.PurchasePriceField = value;
                    this.RaisePropertyChanged("PurchasePrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IProductInterface")]
    public interface IProductInterface {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/CreateProduct", ReplyAction="http://tempuri.org/IProductInterface/CreateProductResponse")]
        void CreateProduct(HypersWebshop.WebApp.ServiceReference1.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/CreateProduct", ReplyAction="http://tempuri.org/IProductInterface/CreateProductResponse")]
        System.Threading.Tasks.Task CreateProductAsync(HypersWebshop.WebApp.ServiceReference1.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/FindProduct", ReplyAction="http://tempuri.org/IProductInterface/FindProductResponse")]
        HypersWebshop.WebApp.ServiceReference1.Product FindProduct(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/FindProduct", ReplyAction="http://tempuri.org/IProductInterface/FindProductResponse")]
        System.Threading.Tasks.Task<HypersWebshop.WebApp.ServiceReference1.Product> FindProductAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/GetData", ReplyAction="http://tempuri.org/IProductInterface/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/GetData", ReplyAction="http://tempuri.org/IProductInterface/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/ggwp", ReplyAction="http://tempuri.org/IProductInterface/ggwpResponse")]
        void ggwp();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/ggwp", ReplyAction="http://tempuri.org/IProductInterface/ggwpResponse")]
        System.Threading.Tasks.Task ggwpAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IProductInterface/GetDataUsingDataContractResponse")]
        HypersWebshop.WebApp.ServiceReference1.CompositeType GetDataUsingDataContract(HypersWebshop.WebApp.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInterface/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IProductInterface/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<HypersWebshop.WebApp.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(HypersWebshop.WebApp.ServiceReference1.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductInterfaceChannel : HypersWebshop.WebApp.ServiceReference1.IProductInterface, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductInterfaceClient : System.ServiceModel.ClientBase<HypersWebshop.WebApp.ServiceReference1.IProductInterface>, HypersWebshop.WebApp.ServiceReference1.IProductInterface {
        
        public ProductInterfaceClient() {
        }
        
        public ProductInterfaceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductInterfaceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void CreateProduct(HypersWebshop.WebApp.ServiceReference1.Product product) {
            base.Channel.CreateProduct(product);
        }
        
        public System.Threading.Tasks.Task CreateProductAsync(HypersWebshop.WebApp.ServiceReference1.Product product) {
            return base.Channel.CreateProductAsync(product);
        }
        
        public HypersWebshop.WebApp.ServiceReference1.Product FindProduct(int id) {
            return base.Channel.FindProduct(id);
        }
        
        public System.Threading.Tasks.Task<HypersWebshop.WebApp.ServiceReference1.Product> FindProductAsync(int id) {
            return base.Channel.FindProductAsync(id);
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public void ggwp() {
            base.Channel.ggwp();
        }
        
        public System.Threading.Tasks.Task ggwpAsync() {
            return base.Channel.ggwpAsync();
        }
        
        public HypersWebshop.WebApp.ServiceReference1.CompositeType GetDataUsingDataContract(HypersWebshop.WebApp.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<HypersWebshop.WebApp.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(HypersWebshop.WebApp.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
