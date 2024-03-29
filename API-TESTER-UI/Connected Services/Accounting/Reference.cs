﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_TESTER_UI.Accounting {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://corridor.aero/cws/", ConfigurationName="Accounting.AccountingSoap")]
    public interface AccountingSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/ProcessAutopostFacilityRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorStatusData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorLoginData))]
        API_TESTER_UI.Accounting.AutoPostResponseOutput ProcessAutopostFacilityRequest(API_TESTER_UI.Accounting.ProcessAutoPostFacilityData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/ProcessAutopostFacilityRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> ProcessAutopostFacilityRequestAsync(API_TESTER_UI.Accounting.ProcessAutoPostFacilityData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/EnableAutopostFacilityRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorStatusData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorLoginData))]
        API_TESTER_UI.Accounting.AutoPostResponseOutput EnableAutopostFacilityRequest(API_TESTER_UI.Accounting.AutoPostFacilityData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/EnableAutopostFacilityRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> EnableAutopostFacilityRequestAsync(API_TESTER_UI.Accounting.AutoPostFacilityData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/DisableAutopostFacilityRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorStatusData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorLoginData))]
        API_TESTER_UI.Accounting.AutoPostResponseOutput DisableAutopostFacilityRequest(API_TESTER_UI.Accounting.AutoPostFacilityData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/DisableAutopostFacilityRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> DisableAutopostFacilityRequestAsync(API_TESTER_UI.Accounting.AutoPostFacilityData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/EnableAllAutopostFacilitiesRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorStatusData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorLoginData))]
        API_TESTER_UI.Accounting.AutoPostResponseOutput EnableAllAutopostFacilitiesRequest(API_TESTER_UI.Accounting.AutoPostData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/EnableAllAutopostFacilitiesRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> EnableAllAutopostFacilitiesRequestAsync(API_TESTER_UI.Accounting.AutoPostData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/DisableAllAutopostFacilitiesRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorStatusData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorLoginData))]
        API_TESTER_UI.Accounting.AutoPostResponseOutput DisableAllAutopostFacilitiesRequest(API_TESTER_UI.Accounting.AutoPostData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/DisableAllAutopostFacilitiesRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> DisableAllAutopostFacilitiesRequestAsync(API_TESTER_UI.Accounting.AutoPostData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/ClearWipRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorStatusData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CorridorLoginData))]
        API_TESTER_UI.Accounting.ClearWipResponseOutput ClearWipRequest(API_TESTER_UI.Accounting.ClearWipData input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://corridor.aero/cws/ClearWipRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<API_TESTER_UI.Accounting.ClearWipResponseOutput> ClearWipRequestAsync(API_TESTER_UI.Accounting.ClearWipData input);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://corridor.aero/cws/")]
    public partial class ProcessAutoPostFacilityData : CorridorLoginData {
        
        private string enterpriseFacilityCodeField;
        
        private bool postNowAllField;
        
        private bool postNowARField;
        
        private bool postNowAPField;
        
        private bool postNowGLField;
        
        private bool postNowWIPField;
        
        private bool postNowCustVendField;
        
        public ProcessAutoPostFacilityData() {
            this.postNowAllField = false;
            this.postNowARField = false;
            this.postNowAPField = false;
            this.postNowGLField = false;
            this.postNowWIPField = false;
            this.postNowCustVendField = false;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string EnterpriseFacilityCode {
            get {
                return this.enterpriseFacilityCodeField;
            }
            set {
                this.enterpriseFacilityCodeField = value;
                this.RaisePropertyChanged("EnterpriseFacilityCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool PostNowAll {
            get {
                return this.postNowAllField;
            }
            set {
                this.postNowAllField = value;
                this.RaisePropertyChanged("PostNowAll");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool PostNowAR {
            get {
                return this.postNowARField;
            }
            set {
                this.postNowARField = value;
                this.RaisePropertyChanged("PostNowAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool PostNowAP {
            get {
                return this.postNowAPField;
            }
            set {
                this.postNowAPField = value;
                this.RaisePropertyChanged("PostNowAP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool PostNowGL {
            get {
                return this.postNowGLField;
            }
            set {
                this.postNowGLField = value;
                this.RaisePropertyChanged("PostNowGL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool PostNowWIP {
            get {
                return this.postNowWIPField;
            }
            set {
                this.postNowWIPField = value;
                this.RaisePropertyChanged("PostNowWIP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool PostNowCustVend {
            get {
                return this.postNowCustVendField;
            }
            set {
                this.postNowCustVendField = value;
                this.RaisePropertyChanged("PostNowCustVend");
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ClearWipData))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AutoPostData))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AutoPostFacilityData))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProcessAutoPostFacilityData))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://corridor.aero/cws/")]
    public partial class CorridorLoginData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string aliasNameField;
        
        private string loginIDField;
        
        private string loginPasswordField;
        
        private string sessionTokenField;
        
        private string auth0TokenField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string AliasName {
            get {
                return this.aliasNameField;
            }
            set {
                this.aliasNameField = value;
                this.RaisePropertyChanged("AliasName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string LoginID {
            get {
                return this.loginIDField;
            }
            set {
                this.loginIDField = value;
                this.RaisePropertyChanged("LoginID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string LoginPassword {
            get {
                return this.loginPasswordField;
            }
            set {
                this.loginPasswordField = value;
                this.RaisePropertyChanged("LoginPassword");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SessionToken {
            get {
                return this.sessionTokenField;
            }
            set {
                this.sessionTokenField = value;
                this.RaisePropertyChanged("SessionToken");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Auth0Token {
            get {
                return this.auth0TokenField;
            }
            set {
                this.auth0TokenField = value;
                this.RaisePropertyChanged("Auth0Token");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://corridor.aero/cws/")]
    public partial class ErrorMessage : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string errorTextField;
        
        private int errorCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ErrorText {
            get {
                return this.errorTextField;
            }
            set {
                this.errorTextField = value;
                this.RaisePropertyChanged("ErrorText");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int ErrorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
                this.RaisePropertyChanged("ErrorCode");
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ClearWipResponseOutput))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AutoPostResponseOutput))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://corridor.aero/cws/")]
    public partial class CorridorStatusData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string statusMessageField;
        
        private ErrorMessage[] errorMessagesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string StatusMessage {
            get {
                return this.statusMessageField;
            }
            set {
                this.statusMessageField = value;
                this.RaisePropertyChanged("StatusMessage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public ErrorMessage[] ErrorMessages {
            get {
                return this.errorMessagesField;
            }
            set {
                this.errorMessagesField = value;
                this.RaisePropertyChanged("ErrorMessages");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://corridor.aero/cws/")]
    public partial class ClearWipResponseOutput : CorridorStatusData {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://corridor.aero/cws/")]
    public partial class AutoPostResponseOutput : CorridorStatusData {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://corridor.aero/cws/")]
    public partial class ClearWipData : CorridorLoginData {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://corridor.aero/cws/")]
    public partial class AutoPostData : CorridorLoginData {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://corridor.aero/cws/")]
    public partial class AutoPostFacilityData : CorridorLoginData {
        
        private string enterpriseFacilityCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string EnterpriseFacilityCode {
            get {
                return this.enterpriseFacilityCodeField;
            }
            set {
                this.enterpriseFacilityCodeField = value;
                this.RaisePropertyChanged("EnterpriseFacilityCode");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AccountingSoapChannel : API_TESTER_UI.Accounting.AccountingSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountingSoapClient : System.ServiceModel.ClientBase<API_TESTER_UI.Accounting.AccountingSoap>, API_TESTER_UI.Accounting.AccountingSoap {
        
        public AccountingSoapClient() {
        }
        
        public AccountingSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountingSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountingSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountingSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public API_TESTER_UI.Accounting.AutoPostResponseOutput ProcessAutopostFacilityRequest(API_TESTER_UI.Accounting.ProcessAutoPostFacilityData input) {
            return base.Channel.ProcessAutopostFacilityRequest(input);
        }
        
        public System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> ProcessAutopostFacilityRequestAsync(API_TESTER_UI.Accounting.ProcessAutoPostFacilityData input) {
            return base.Channel.ProcessAutopostFacilityRequestAsync(input);
        }
        
        public API_TESTER_UI.Accounting.AutoPostResponseOutput EnableAutopostFacilityRequest(API_TESTER_UI.Accounting.AutoPostFacilityData input) {
            return base.Channel.EnableAutopostFacilityRequest(input);
        }
        
        public System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> EnableAutopostFacilityRequestAsync(API_TESTER_UI.Accounting.AutoPostFacilityData input) {
            return base.Channel.EnableAutopostFacilityRequestAsync(input);
        }
        
        public API_TESTER_UI.Accounting.AutoPostResponseOutput DisableAutopostFacilityRequest(API_TESTER_UI.Accounting.AutoPostFacilityData input) {
            return base.Channel.DisableAutopostFacilityRequest(input);
        }
        
        public System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> DisableAutopostFacilityRequestAsync(API_TESTER_UI.Accounting.AutoPostFacilityData input) {
            return base.Channel.DisableAutopostFacilityRequestAsync(input);
        }
        
        public API_TESTER_UI.Accounting.AutoPostResponseOutput EnableAllAutopostFacilitiesRequest(API_TESTER_UI.Accounting.AutoPostData input) {
            return base.Channel.EnableAllAutopostFacilitiesRequest(input);
        }
        
        public System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> EnableAllAutopostFacilitiesRequestAsync(API_TESTER_UI.Accounting.AutoPostData input) {
            return base.Channel.EnableAllAutopostFacilitiesRequestAsync(input);
        }
        
        public API_TESTER_UI.Accounting.AutoPostResponseOutput DisableAllAutopostFacilitiesRequest(API_TESTER_UI.Accounting.AutoPostData input) {
            return base.Channel.DisableAllAutopostFacilitiesRequest(input);
        }
        
        public System.Threading.Tasks.Task<API_TESTER_UI.Accounting.AutoPostResponseOutput> DisableAllAutopostFacilitiesRequestAsync(API_TESTER_UI.Accounting.AutoPostData input) {
            return base.Channel.DisableAllAutopostFacilitiesRequestAsync(input);
        }
        
        public API_TESTER_UI.Accounting.ClearWipResponseOutput ClearWipRequest(API_TESTER_UI.Accounting.ClearWipData input) {
            return base.Channel.ClearWipRequest(input);
        }
        
        public System.Threading.Tasks.Task<API_TESTER_UI.Accounting.ClearWipResponseOutput> ClearWipRequestAsync(API_TESTER_UI.Accounting.ClearWipData input) {
            return base.Channel.ClearWipRequestAsync(input);
        }
    }
}
