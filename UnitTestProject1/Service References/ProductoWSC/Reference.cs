﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTestProject1.ProductoWSC {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EProducto", Namespace="http://schemas.datacontract.org/2004/07/CFFLORES.WebService.Dominio")]
    [System.SerializableAttribute()]
    public partial class EProducto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PrecioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StockField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string codigobarraField;
        
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
        public string Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((object.ReferenceEquals(this.EstadoField, value) != true)) {
                    this.EstadoField = value;
                    this.RaisePropertyChanged("Estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Precio {
            get {
                return this.PrecioField;
            }
            set {
                if ((this.PrecioField.Equals(value) != true)) {
                    this.PrecioField = value;
                    this.RaisePropertyChanged("Precio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Stock {
            get {
                return this.StockField;
            }
            set {
                if ((this.StockField.Equals(value) != true)) {
                    this.StockField = value;
                    this.RaisePropertyChanged("Stock");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tipo {
            get {
                return this.TipoField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoField, value) != true)) {
                    this.TipoField = value;
                    this.RaisePropertyChanged("Tipo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string codigobarra {
            get {
                return this.codigobarraField;
            }
            set {
                if ((object.ReferenceEquals(this.codigobarraField, value) != true)) {
                    this.codigobarraField = value;
                    this.RaisePropertyChanged("codigobarra");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductoInexistente", Namespace="http://schemas.datacontract.org/2004/07/CFFLORES.WebService.Errores")]
    [System.SerializableAttribute()]
    public partial class ProductoInexistente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int exCodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string exErrorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string exProductoField;
        
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
        public int exCodigo {
            get {
                return this.exCodigoField;
            }
            set {
                if ((this.exCodigoField.Equals(value) != true)) {
                    this.exCodigoField = value;
                    this.RaisePropertyChanged("exCodigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string exError {
            get {
                return this.exErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.exErrorField, value) != true)) {
                    this.exErrorField = value;
                    this.RaisePropertyChanged("exError");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string exProducto {
            get {
                return this.exProductoField;
            }
            set {
                if ((object.ReferenceEquals(this.exProductoField, value) != true)) {
                    this.exProductoField = value;
                    this.RaisePropertyChanged("exProducto");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductoWSC.IProducto")]
    public interface IProducto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/ObtenerProducto", ReplyAction="http://tempuri.org/IProducto/ObtenerProductoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UnitTestProject1.ProductoWSC.ProductoInexistente), Action="http://tempuri.org/IProducto/ObtenerProductoProductoInexistenteFault", Name="ProductoInexistente", Namespace="http://schemas.datacontract.org/2004/07/CFFLORES.WebService.Errores")]
        UnitTestProject1.ProductoWSC.EProducto ObtenerProducto(string codigobarra, string nombre, string tipo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/ObtenerProducto", ReplyAction="http://tempuri.org/IProducto/ObtenerProductoResponse")]
        System.Threading.Tasks.Task<UnitTestProject1.ProductoWSC.EProducto> ObtenerProductoAsync(string codigobarra, string nombre, string tipo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/ListarProducto", ReplyAction="http://tempuri.org/IProducto/ListarProductoResponse")]
        UnitTestProject1.ProductoWSC.EProducto[] ListarProducto();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/ListarProducto", ReplyAction="http://tempuri.org/IProducto/ListarProductoResponse")]
        System.Threading.Tasks.Task<UnitTestProject1.ProductoWSC.EProducto[]> ListarProductoAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductoChannel : UnitTestProject1.ProductoWSC.IProducto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductoClient : System.ServiceModel.ClientBase<UnitTestProject1.ProductoWSC.IProducto>, UnitTestProject1.ProductoWSC.IProducto {
        
        public ProductoClient() {
        }
        
        public ProductoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public UnitTestProject1.ProductoWSC.EProducto ObtenerProducto(string codigobarra, string nombre, string tipo) {
            return base.Channel.ObtenerProducto(codigobarra, nombre, tipo);
        }
        
        public System.Threading.Tasks.Task<UnitTestProject1.ProductoWSC.EProducto> ObtenerProductoAsync(string codigobarra, string nombre, string tipo) {
            return base.Channel.ObtenerProductoAsync(codigobarra, nombre, tipo);
        }
        
        public UnitTestProject1.ProductoWSC.EProducto[] ListarProducto() {
            return base.Channel.ListarProducto();
        }
        
        public System.Threading.Tasks.Task<UnitTestProject1.ProductoWSC.EProducto[]> ListarProductoAsync() {
            return base.Channel.ListarProductoAsync();
        }
    }
}
