﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace IngenieriaGD.IGDDemo.App.AndroidApp.WS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IServiceSAL", Namespace="http://tempuri.org/")]
    public partial class ServiceSAL : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetAllClientsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetClientOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetClientByDocumentOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertClientOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateClientReadingOperationCompleted;
        
        private System.Threading.SendOrPostCallback ValidateUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllDocumentTypesOperationCompleted;
        
        private System.Threading.SendOrPostCallback WriteOperationTrackingOperationCompleted;
        
        private System.Threading.SendOrPostCallback WriteExceptionTrackingOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServiceSAL() {
            this.Url = "http://10.100.102.238/IGDDemoService/ServiceSAL.svc";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetAllClientsCompletedEventHandler GetAllClientsCompleted;
        
        /// <remarks/>
        public event GetClientCompletedEventHandler GetClientCompleted;
        
        /// <remarks/>
        public event GetClientByDocumentCompletedEventHandler GetClientByDocumentCompleted;
        
        /// <remarks/>
        public event InsertClientCompletedEventHandler InsertClientCompleted;
        
        /// <remarks/>
        public event UpdateClientReadingCompletedEventHandler UpdateClientReadingCompleted;
        
        /// <remarks/>
        public event ValidateUserCompletedEventHandler ValidateUserCompleted;
        
        /// <remarks/>
        public event GetAllDocumentTypesCompletedEventHandler GetAllDocumentTypesCompleted;
        
        /// <remarks/>
        public event WriteOperationTrackingCompletedEventHandler WriteOperationTrackingCompleted;
        
        /// <remarks/>
        public event WriteExceptionTrackingCompletedEventHandler WriteExceptionTrackingCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceSAL/GetAllClients", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/IngenieriaGD.IGDDemo.Library.DAL.Entities" +
            "")]
        public ClientInfo[] GetAllClients() {
            object[] results = this.Invoke("GetAllClients", new object[0]);
            return ((ClientInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllClientsAsync() {
            this.GetAllClientsAsync(null);
        }
        
        /// <remarks/>
        public void GetAllClientsAsync(object userState) {
            if ((this.GetAllClientsOperationCompleted == null)) {
                this.GetAllClientsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllClientsOperationCompleted);
            }
            this.InvokeAsync("GetAllClients", new object[0], this.GetAllClientsOperationCompleted, userState);
        }
        
        private void OnGetAllClientsOperationCompleted(object arg) {
            if ((this.GetAllClientsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllClientsCompleted(this, new GetAllClientsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceSAL/GetClient", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ClientInfo GetClient(int clientId, [System.Xml.Serialization.XmlIgnoreAttribute()] bool clientIdSpecified) {
            object[] results = this.Invoke("GetClient", new object[] {
                        clientId,
                        clientIdSpecified});
            return ((ClientInfo)(results[0]));
        }
        
        /// <remarks/>
        public void GetClientAsync(int clientId, bool clientIdSpecified) {
            this.GetClientAsync(clientId, clientIdSpecified, null);
        }
        
        /// <remarks/>
        public void GetClientAsync(int clientId, bool clientIdSpecified, object userState) {
            if ((this.GetClientOperationCompleted == null)) {
                this.GetClientOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetClientOperationCompleted);
            }
            this.InvokeAsync("GetClient", new object[] {
                        clientId,
                        clientIdSpecified}, this.GetClientOperationCompleted, userState);
        }
        
        private void OnGetClientOperationCompleted(object arg) {
            if ((this.GetClientCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetClientCompleted(this, new GetClientCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceSAL/GetClientByDocument", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ClientInfo GetClientByDocument(int documentType, [System.Xml.Serialization.XmlIgnoreAttribute()] bool documentTypeSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string documentNumber) {
            object[] results = this.Invoke("GetClientByDocument", new object[] {
                        documentType,
                        documentTypeSpecified,
                        documentNumber});
            return ((ClientInfo)(results[0]));
        }
        
        /// <remarks/>
        public void GetClientByDocumentAsync(int documentType, bool documentTypeSpecified, string documentNumber) {
            this.GetClientByDocumentAsync(documentType, documentTypeSpecified, documentNumber, null);
        }
        
        /// <remarks/>
        public void GetClientByDocumentAsync(int documentType, bool documentTypeSpecified, string documentNumber, object userState) {
            if ((this.GetClientByDocumentOperationCompleted == null)) {
                this.GetClientByDocumentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetClientByDocumentOperationCompleted);
            }
            this.InvokeAsync("GetClientByDocument", new object[] {
                        documentType,
                        documentTypeSpecified,
                        documentNumber}, this.GetClientByDocumentOperationCompleted, userState);
        }
        
        private void OnGetClientByDocumentOperationCompleted(object arg) {
            if ((this.GetClientByDocumentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetClientByDocumentCompleted(this, new GetClientByDocumentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceSAL/InsertClient", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void InsertClient([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] ClientInfo clientInfo, out bool InsertClientResult, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool InsertClientResultSpecified) {
            object[] results = this.Invoke("InsertClient", new object[] {
                        clientInfo});
            InsertClientResult = ((bool)(results[0]));
            InsertClientResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        public void InsertClientAsync(ClientInfo clientInfo) {
            this.InsertClientAsync(clientInfo, null);
        }
        
        /// <remarks/>
        public void InsertClientAsync(ClientInfo clientInfo, object userState) {
            if ((this.InsertClientOperationCompleted == null)) {
                this.InsertClientOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertClientOperationCompleted);
            }
            this.InvokeAsync("InsertClient", new object[] {
                        clientInfo}, this.InsertClientOperationCompleted, userState);
        }
        
        private void OnInsertClientOperationCompleted(object arg) {
            if ((this.InsertClientCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertClientCompleted(this, new InsertClientCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceSAL/UpdateClientReading", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateClientReading(int clientId, [System.Xml.Serialization.XmlIgnoreAttribute()] bool clientIdSpecified, int newReading, [System.Xml.Serialization.XmlIgnoreAttribute()] bool newReadingSpecified, out bool UpdateClientReadingResult, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool UpdateClientReadingResultSpecified) {
            object[] results = this.Invoke("UpdateClientReading", new object[] {
                        clientId,
                        clientIdSpecified,
                        newReading,
                        newReadingSpecified});
            UpdateClientReadingResult = ((bool)(results[0]));
            UpdateClientReadingResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        public void UpdateClientReadingAsync(int clientId, bool clientIdSpecified, int newReading, bool newReadingSpecified) {
            this.UpdateClientReadingAsync(clientId, clientIdSpecified, newReading, newReadingSpecified, null);
        }
        
        /// <remarks/>
        public void UpdateClientReadingAsync(int clientId, bool clientIdSpecified, int newReading, bool newReadingSpecified, object userState) {
            if ((this.UpdateClientReadingOperationCompleted == null)) {
                this.UpdateClientReadingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateClientReadingOperationCompleted);
            }
            this.InvokeAsync("UpdateClientReading", new object[] {
                        clientId,
                        clientIdSpecified,
                        newReading,
                        newReadingSpecified}, this.UpdateClientReadingOperationCompleted, userState);
        }
        
        private void OnUpdateClientReadingOperationCompleted(object arg) {
            if ((this.UpdateClientReadingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateClientReadingCompleted(this, new UpdateClientReadingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceSAL/ValidateUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ValidateUser([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string user, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string password, out bool ValidateUserResult, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool ValidateUserResultSpecified) {
            object[] results = this.Invoke("ValidateUser", new object[] {
                        user,
                        password});
            ValidateUserResult = ((bool)(results[0]));
            ValidateUserResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        public void ValidateUserAsync(string user, string password) {
            this.ValidateUserAsync(user, password, null);
        }
        
        /// <remarks/>
        public void ValidateUserAsync(string user, string password, object userState) {
            if ((this.ValidateUserOperationCompleted == null)) {
                this.ValidateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnValidateUserOperationCompleted);
            }
            this.InvokeAsync("ValidateUser", new object[] {
                        user,
                        password}, this.ValidateUserOperationCompleted, userState);
        }
        
        private void OnValidateUserOperationCompleted(object arg) {
            if ((this.ValidateUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ValidateUserCompleted(this, new ValidateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceSAL/GetAllDocumentTypes", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/IngenieriaGD.IGDDemo.Library.DAL.Entities" +
            "")]
        public DocumentTypeInfo[] GetAllDocumentTypes() {
            object[] results = this.Invoke("GetAllDocumentTypes", new object[0]);
            return ((DocumentTypeInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllDocumentTypesAsync() {
            this.GetAllDocumentTypesAsync(null);
        }
        
        /// <remarks/>
        public void GetAllDocumentTypesAsync(object userState) {
            if ((this.GetAllDocumentTypesOperationCompleted == null)) {
                this.GetAllDocumentTypesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllDocumentTypesOperationCompleted);
            }
            this.InvokeAsync("GetAllDocumentTypes", new object[0], this.GetAllDocumentTypesOperationCompleted, userState);
        }
        
        private void OnGetAllDocumentTypesOperationCompleted(object arg) {
            if ((this.GetAllDocumentTypesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllDocumentTypesCompleted(this, new GetAllDocumentTypesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceSAL/WriteOperationTracking", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void WriteOperationTracking([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] object request, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] object response) {
            this.Invoke("WriteOperationTracking", new object[] {
                        request,
                        response});
        }
        
        /// <remarks/>
        public void WriteOperationTrackingAsync(object request, object response) {
            this.WriteOperationTrackingAsync(request, response, null);
        }
        
        /// <remarks/>
        public void WriteOperationTrackingAsync(object request, object response, object userState) {
            if ((this.WriteOperationTrackingOperationCompleted == null)) {
                this.WriteOperationTrackingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnWriteOperationTrackingOperationCompleted);
            }
            this.InvokeAsync("WriteOperationTracking", new object[] {
                        request,
                        response}, this.WriteOperationTrackingOperationCompleted, userState);
        }
        
        private void OnWriteOperationTrackingOperationCompleted(object arg) {
            if ((this.WriteOperationTrackingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.WriteOperationTrackingCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceSAL/WriteExceptionTracking", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void WriteExceptionTracking([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] object exception) {
            this.Invoke("WriteExceptionTracking", new object[] {
                        exception});
        }
        
        /// <remarks/>
        public void WriteExceptionTrackingAsync(object exception) {
            this.WriteExceptionTrackingAsync(exception, null);
        }
        
        /// <remarks/>
        public void WriteExceptionTrackingAsync(object exception, object userState) {
            if ((this.WriteExceptionTrackingOperationCompleted == null)) {
                this.WriteExceptionTrackingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnWriteExceptionTrackingOperationCompleted);
            }
            this.InvokeAsync("WriteExceptionTracking", new object[] {
                        exception}, this.WriteExceptionTrackingOperationCompleted, userState);
        }
        
        private void OnWriteExceptionTrackingOperationCompleted(object arg) {
            if ((this.WriteExceptionTrackingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.WriteExceptionTrackingCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/IngenieriaGD.IGDDemo.Library.DAL.Entities" +
        "")]
    public partial class ClientInfo {
        
        private string addressField;
        
        private System.DateTime anniversaryField;
        
        private bool anniversaryFieldSpecified;
        
        private string documentNumberField;
        
        private int documentTypeIdField;
        
        private bool documentTypeIdFieldSpecified;
        
        private string emailField;
        
        private string firstNameField;
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int lastReadingField;
        
        private bool lastReadingFieldSpecified;
        
        private string phoneField;
        
        private bool readedField;
        
        private bool readedFieldSpecified;
        
        private string secondNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Anniversary {
            get {
                return this.anniversaryField;
            }
            set {
                this.anniversaryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AnniversarySpecified {
            get {
                return this.anniversaryFieldSpecified;
            }
            set {
                this.anniversaryFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DocumentNumber {
            get {
                return this.documentNumberField;
            }
            set {
                this.documentNumberField = value;
            }
        }
        
        /// <remarks/>
        public int DocumentTypeId {
            get {
                return this.documentTypeIdField;
            }
            set {
                this.documentTypeIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DocumentTypeIdSpecified {
            get {
                return this.documentTypeIdFieldSpecified;
            }
            set {
                this.documentTypeIdFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int LastReading {
            get {
                return this.lastReadingField;
            }
            set {
                this.lastReadingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastReadingSpecified {
            get {
                return this.lastReadingFieldSpecified;
            }
            set {
                this.lastReadingFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
            }
        }
        
        /// <remarks/>
        public bool Readed {
            get {
                return this.readedField;
            }
            set {
                this.readedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReadedSpecified {
            get {
                return this.readedFieldSpecified;
            }
            set {
                this.readedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string SecondName {
            get {
                return this.secondNameField;
            }
            set {
                this.secondNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/IngenieriaGD.IGDDemo.Library.DAL.Entities" +
        "")]
    public partial class DocumentTypeInfo {
        
        private string codeField;
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private string titleField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void GetAllClientsCompletedEventHandler(object sender, GetAllClientsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllClientsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllClientsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ClientInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ClientInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void GetClientCompletedEventHandler(object sender, GetClientCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetClientCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetClientCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ClientInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ClientInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void GetClientByDocumentCompletedEventHandler(object sender, GetClientByDocumentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetClientByDocumentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetClientByDocumentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ClientInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ClientInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void InsertClientCompletedEventHandler(object sender, InsertClientCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertClientCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertClientCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool InsertClientResult {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public bool InsertClientResultSpecified {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void UpdateClientReadingCompletedEventHandler(object sender, UpdateClientReadingCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateClientReadingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateClientReadingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool UpdateClientReadingResult {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public bool UpdateClientReadingResultSpecified {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void ValidateUserCompletedEventHandler(object sender, ValidateUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ValidateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ValidateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool ValidateUserResult {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public bool ValidateUserResultSpecified {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void GetAllDocumentTypesCompletedEventHandler(object sender, GetAllDocumentTypesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllDocumentTypesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllDocumentTypesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DocumentTypeInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DocumentTypeInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void WriteOperationTrackingCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void WriteExceptionTrackingCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591