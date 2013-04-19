﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClient.BetterPlaceAPIRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BetterPlaceAPIRef.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAllUsers", ReplyAction="http://tempuri.org/IUserService/GetAllUsersResponse")]
        Repository.Models.User[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAllUsers", ReplyAction="http://tempuri.org/IUserService/GetAllUsersResponse")]
        System.Threading.Tasks.Task<Repository.Models.User[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserById", ReplyAction="http://tempuri.org/IUserService/GetUserByIdResponse")]
        Repository.Models.User GetUserById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserById", ReplyAction="http://tempuri.org/IUserService/GetUserByIdResponse")]
        System.Threading.Tasks.Task<Repository.Models.User> GetUserByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/EditUserData", ReplyAction="http://tempuri.org/IUserService/EditUserDataResponse")]
        bool EditUserData(int id, string[] editData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/EditUserData", ReplyAction="http://tempuri.org/IUserService/EditUserDataResponse")]
        System.Threading.Tasks.Task<bool> EditUserDataAsync(int id, string[] editData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AuthenticateUser", ReplyAction="http://tempuri.org/IUserService/AuthenticateUserResponse")]
        bool AuthenticateUser(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AuthenticateUser", ReplyAction="http://tempuri.org/IUserService/AuthenticateUserResponse")]
        System.Threading.Tasks.Task<bool> AuthenticateUserAsync(string userName, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : WebClient.BetterPlaceAPIRef.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<WebClient.BetterPlaceAPIRef.IUserService>, WebClient.BetterPlaceAPIRef.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Repository.Models.User[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<Repository.Models.User[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public Repository.Models.User GetUserById(int id) {
            return base.Channel.GetUserById(id);
        }
        
        public System.Threading.Tasks.Task<Repository.Models.User> GetUserByIdAsync(int id) {
            return base.Channel.GetUserByIdAsync(id);
        }
        
        public bool EditUserData(int id, string[] editData) {
            return base.Channel.EditUserData(id, editData);
        }
        
        public System.Threading.Tasks.Task<bool> EditUserDataAsync(int id, string[] editData) {
            return base.Channel.EditUserDataAsync(id, editData);
        }
        
        public bool AuthenticateUser(string userName, string password) {
            return base.Channel.AuthenticateUser(userName, password);
        }
        
        public System.Threading.Tasks.Task<bool> AuthenticateUserAsync(string userName, string password) {
            return base.Channel.AuthenticateUserAsync(userName, password);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BetterPlaceAPIRef.IStationService")]
    public interface IStationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStationService/GetAllStations", ReplyAction="http://tempuri.org/IStationService/GetAllStationsResponse")]
        Repository.Models.Station[] GetAllStations();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStationService/GetAllStations", ReplyAction="http://tempuri.org/IStationService/GetAllStationsResponse")]
        System.Threading.Tasks.Task<Repository.Models.Station[]> GetAllStationsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStationService/GetStationById", ReplyAction="http://tempuri.org/IStationService/GetStationByIdResponse")]
        Repository.Models.Station GetStationById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStationService/GetStationById", ReplyAction="http://tempuri.org/IStationService/GetStationByIdResponse")]
        System.Threading.Tasks.Task<Repository.Models.Station> GetStationByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStationServiceChannel : WebClient.BetterPlaceAPIRef.IStationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StationServiceClient : System.ServiceModel.ClientBase<WebClient.BetterPlaceAPIRef.IStationService>, WebClient.BetterPlaceAPIRef.IStationService {
        
        public StationServiceClient() {
        }
        
        public StationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Repository.Models.Station[] GetAllStations() {
            return base.Channel.GetAllStations();
        }
        
        public System.Threading.Tasks.Task<Repository.Models.Station[]> GetAllStationsAsync() {
            return base.Channel.GetAllStationsAsync();
        }
        
        public Repository.Models.Station GetStationById(int id) {
            return base.Channel.GetStationById(id);
        }
        
        public System.Threading.Tasks.Task<Repository.Models.Station> GetStationByIdAsync(int id) {
            return base.Channel.GetStationByIdAsync(id);
        }
    }
}