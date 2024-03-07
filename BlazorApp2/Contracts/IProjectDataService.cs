

using BlazorApp2.Service.Base;
using BlazorApp2.ViewModels;

namespace BlazorApp2.Contracts
{
    public interface IProjectDataService
    {
        public Task<List<ProjectViewModel>> GetAllProjects();
        public Task<List<ProjectViewModel>> GetAllProjectsWithInputFilter(ProductStatus? status,
            bool? productAvailability,
            double? price,
            Guid? location_Id,
            string location_Country,
            string location_City,
            string location_Street,
            CancellationToken cancellationToken);

        public Task<ProjectViewModel> GetProjectById(Guid id);
        public Task<ApiResponse<Guid>> Create( ProjectViewModel createProjectCommand);
        public Task<ApiResponse<Guid>> Update( ProjectViewModel updateProjectCommand);
        public Task<ApiResponse<Guid>> Delete(Guid id);
       
    }
}
