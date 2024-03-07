

using BlazorApp2.Service.Base;

namespace BlazorApp2.Contracts
{ 
    public interface IOrederProductDataService
    {
        public  Task<ApiResponse<List<GetOrderProductDto>>> GetAllOrders();
        public  Task<ApiResponse<List<GetOrderProductDto>>> GetAllAcceptedOrRefusedOrders(bool input = true);
        public  Task<ApiResponse<bool>> Create( CreateOrderProductCommand createOrderProductCommand);
        public  Task<ApiResponse<Guid>> Delete(Guid id);
       
    }
}
