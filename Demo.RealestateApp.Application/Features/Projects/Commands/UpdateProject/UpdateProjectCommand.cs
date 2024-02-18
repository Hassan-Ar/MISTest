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

namespace Demo.RealestateApp.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public int NumberOfBuildings { get; set; } = 0;
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = true;
        public ProductStatus ProductStatus { get; set; }
        public ProductType productType { get; set; }
        public UpdateAddressDto Address { get; set; }
        public List<ImageUploadRequestDto>? Images { get; set; }
        public List<BuildingProjectDto>? Buildings { get; set; }

    }
}
