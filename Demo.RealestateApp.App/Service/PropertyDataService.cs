using AutoMapper;
using Blazored.LocalStorage;
using Demo.RealestateApp.App.Contracts;
using Demo.RealestateApp.App.Service.Base;
using Demo.RealestateApp.App.ViewModels;
using MassTransit;

namespace Demo.RealestateApp.App.Service
{
    public class PropertyDataService : BaseDataService, IPropertyDataService
    {
        private readonly IMapper _mapper;

        public PropertyDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> Create(PropertyDetailVeiwModel createPropertyCommand)
        {
            try
            {
                CreatePropertyCommand createEventCommand = _mapper.Map<CreatePropertyCommand>(createPropertyCommand);
                var newId = await _client.AddPropertyAsync(createEventCommand);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> Delete(Guid id)
        {
            try
            {
                await _client.DeletePropertyAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<PropertyDetailVeiwModel>> GetAllProperties()
        {
            var allProperties = await _client.GetAllPropertiesAsync();
            var result = _mapper.Map<List<PropertyDetailVeiwModel>>(allProperties);
            return result;
        }

        public async Task<List<PropertyDetailVeiwModel>> GetAllPropertiesWithInputFilter(ProductStatus? status, bool? productAvailability, double? price, Guid? location_Id, string location_Country, string location_City, string location_Street, CancellationToken cancellationToken)
        {
            var allProperties = await _client.GetAllPropertiesWithInputFilterAsync(status,productAvailability,price,location_Id,location_Country,location_City,location_Street);
            var result = _mapper.Map<List<PropertyDetailVeiwModel>>(allProperties);
            return result;
        }

        public async Task<List<BuildingPropertiesViewModel>> GetPropertiesBuildings(Guid Buildingtid)
        {
            var allProperties = await _client.GetBuildingPropertiesAsync(Buildingtid);
            var result = _mapper.Map<List<BuildingPropertiesViewModel>>(allProperties);
            return result;
        }

        public async Task<PropertyDetailVeiwModel> GetPropertyById(Guid id)
        {
            var Property = await _client.GetPropertyByIdAsync(id);
            var result = _mapper.Map<PropertyDetailVeiwModel>(Property);
            return result;
        }

        public async Task<ApiResponse<Guid>> Update(PropertyDetailVeiwModel updatePropertyCommand)
        {
            try
            {
                UpdatePropertyCommand updateCommand = _mapper.Map<UpdatePropertyCommand>(updatePropertyCommand);
                await _client.UpdatePropertyAsync(updateCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
