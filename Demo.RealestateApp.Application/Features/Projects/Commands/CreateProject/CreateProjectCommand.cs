using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Features.Projects.Queries;
using Demo.RealestateApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
       
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public int NumberOfBuildings { get; set; } = 0;
        public bool ProductAvailability { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType productType { get; set; }
        public CreateAddreesDto Address { get; set; }
        public List<ImageUploadRequestDto>? Images { get; set; }
        public List<BuildingProjectDto>? Buildings { get; set; }
    }
}
