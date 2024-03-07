

using BlazorApp2.Service.Base;
using BlazorApp2.ViewModels;

namespace BlazorApp2.Contracts
{
    public interface IPropertyDataService
    {
        public Task<List<PropertyDetailVeiwModel>> GetAllProperties();
        // TODO: Change args
        public Task<List<PropertyDetailVeiwModel>> GetAllPropertiesWithInputFilter(ProductStatus? status,
            bool? productAvailability,
            double? price,
            Guid? location_Id, 
            string location_Country,
            string location_City,
            string location_Street,
            CancellationToken cancellationToken);

        public Task<List<BuildingPropertiesViewModel>> GetPropertiesBuildings(Guid Buildingtid);
        public Task<PropertyDetailVeiwModel> GetPropertyById(Guid id);
        public Task<ApiResponse<Guid>> Create(PropertyDetailVeiwModel createPropertyCommand);
        public Task<ApiResponse<Guid>> Update(PropertyDetailVeiwModel updatePropertyCommand);
        public Task<ApiResponse<Guid>> Delete(Guid id);

    }
}
