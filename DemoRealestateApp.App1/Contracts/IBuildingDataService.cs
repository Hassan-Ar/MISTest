using Demo.RealestateApp.App1.Service.Base;

using Demo.RealestateApp.App1.ViewModels;

namespace Demo.RealestateApp.App1.Contracts
{
    public interface IBuildingDataService
    {

        public Task<List<BuildingViewModel>> GetAllBuildings();

        public Task<List<BuildingViewModel>> GetAllBuildingsWithInputFilter(ProductStatus? status,
            bool? productAvailability,
            double? price,
            Guid? location_Id,
            string location_Country,
            string location_City,
            string location_Street );

        public Task<List<ProjectBuildingsViewModel>> GetProjectBuildings(Guid Projectid);

        public Task<BuildingViewModel> GetBuildingById(Guid id);

        public Task<ApiResponse<Guid>> Create(BuildingViewModel createBuildingCommand);

        public Task<ApiResponse<Guid>> Update(BuildingViewModel updateBuildingCommand);

        public Task<ApiResponse<Guid>> Delete(Guid id);

    }
}
