using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Buildings.Queries;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Features.Projects.Queries;
using Demo.RealestateApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? ProductTitle { get; set; }
        public string? ProductDescription { get; set; }
        public int NumberOfProperties { get; set; } = 0;
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public bool HasGarage { get; set; }
        public ProductStatus ProductStatus { get; set; } = ProductStatus.Unknown;
        public ProductType productType { get; set; } = ProductType.Unknown;
        public Guid AddreesId { get; set; }
        public UpdateAddressDto Address { get; set; }
        public List<ImageUploadRequestDto>? Images { get; set; }
        public Guid ProjectId { get; set; } = Guid.Empty;
        public List<PropertiesBuildingDto>? propeties { get; set; }

    }
}
