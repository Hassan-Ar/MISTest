using AutoMapper;
using Blazored.LocalStorage;
using Demo.RealestateApp.App1.Contracts;
using Demo.RealestateApp.App1.Service.Base;
using Demo.RealestateApp.App1.ViewModels;

namespace Demo.RealestateApp.App.Service
{
    public class BuildingDataService : BaseDataService, IBuildingDataService
    {
        private readonly IMapper _mapper;
        public BuildingDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> Create(BuildingViewModel createBuildingCommand)
        {
            try
            {
                CreateBuildingCommand createCommand = _mapper.Map<CreateBuildingCommand>(createBuildingCommand);
                var id = await _client.AddBuildingAsync(createCommand);
                return new ApiResponse<Guid>() { Data=id,Success=true};
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
                await _client.DeleteBuildingAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<BuildingViewModel>> GetAllBuildings()
        {
            var allBuildings = await _client.GetAllBuildingAsync();
            var result = _mapper.Map<List<BuildingViewModel>>(allBuildings);
            return result;
        }

        public async Task<List<BuildingViewModel>> GetAllBuildingsWithInputFilter(ProductStatus? status, bool? productAvailability, double? price, Guid? location_Id, string location_Country, string location_City, string location_Street)
        {
            var allBuildings = await _client.GetAllBuildingsWithInputFilterAsync(status, productAvailability, price, location_Id, location_Country, location_City, location_Street);
            var result = _mapper.Map<List<BuildingViewModel>>(allBuildings);
            return result;
        }

        public async Task<BuildingViewModel> GetBuildingById(Guid id)
        {
            var building = await _client.GetBuildingByIdAsync(id);
            var result = _mapper.Map<BuildingViewModel>(building);
            return result;
        }

        public async Task<List<ProjectBuildingsViewModel>> GetProjectBuildings(Guid Projectid)
        {
            var allBuildings = await _client.GetProjectBuildingsAsync(Projectid);
            var result = _mapper.Map<List<ProjectBuildingsViewModel>>(allBuildings);
            return result;
        }

        public async Task<ApiResponse<Guid>> Update(BuildingViewModel updateBuildingCommand)
        {
            try
            {
                UpdateBuildingCommand updateCommand = _mapper.Map<UpdateBuildingCommand>(updateBuildingCommand);
                await _client.UpdateBuildingAsync(updateCommand);
                return new ApiResponse<Guid>() {Success=true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
                
            }
        }
    }
}
