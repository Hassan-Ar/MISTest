using AutoMapper;
using Blazored.LocalStorage;
using Demo.RealestateApp.App1.Contracts;
using Demo.RealestateApp.App1.Service.Base;
using Demo.RealestateApp.App1.ViewModels;

namespace Demo.RealestateApp.App1.Service
{
    public class ProjectDataService : BaseDataService, IProjectDataService
    {
        private readonly IMapper _mapper;
        public ProjectDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> Create(ProjectViewModel createProjectCommand)
        {
            try
            {
                CreateProjectCommand createCommand = _mapper.Map<CreateProjectCommand>(createProjectCommand);   
                var id = await _client.AddProjectAsync(createCommand);
                return new ApiResponse<Guid> {Data = id , Success = true };
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
                await _client.DeleteProjectAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<ProjectViewModel>> GetAllProjects()
        {
            var allProjects = await _client.GetAllProjectsAsync();
            var result = _mapper.Map<List<ProjectViewModel>>(allProjects);
            return result;
        }

        public async Task<List<ProjectViewModel>> GetAllProjectsWithInputFilter(ProductStatus? status, bool? productAvailability, double? price, Guid? location_Id, string location_Country, string location_City, string location_Street, CancellationToken cancellationToken)
        {
            var allProjects = await _client.GetAllProjectsWithInputFilterAsync(status, productAvailability, price, location_Id, location_Country, location_City, location_Street);
            var result = _mapper.Map<List<ProjectViewModel>>(allProjects);
            return result;
        }

        public async Task<ProjectViewModel> GetProjectById(Guid id)
        {
            var project = await _client.GetBuildingByIdAsync(id);
            var result = _mapper.Map<ProjectViewModel>(project);
            return result;
        }

        public async Task<ApiResponse<Guid>> Update(ProjectViewModel updateProjectCommand)
        {
            try
            {
                UpdateProjectCommand updateCommand = _mapper.Map<UpdateProjectCommand>(updateProjectCommand);
                await _client.UpdateProjectAsync(updateCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);

            }
        }
    }
}
