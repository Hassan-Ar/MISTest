using Demo.RealestateApp.App1.Service;
using Demo.RealestateApp.App1.Service.Base;
using Microsoft.AspNetCore.Mvc;

namespace Demo.RealestateApp.App1.Contracts
{
    public interface IOrederProductDataService
    {
        public  Task<ApiResponse<List<GetOrderProductDto>>> GetAllOrders();
        public  Task<ApiResponse<List<GetOrderProductDto>>> GetAllAcceptedOrRefusedOrders(bool input = true);
        public  Task<ApiResponse<bool>> Create([FromBody] CreateOrderProductCommand createOrderProductCommand);
        public  Task<ApiResponse<Guid>> Delete(Guid id);
       
    }
}
