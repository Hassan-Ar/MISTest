using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Buildings.Queries;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Features.Projects.Queries;
using Demo.RealestateApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommand : IRequest<Guid>
    {
       
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public int NumberOfProperties { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public bool HasGarage { get; set; } = false;
        public ProductStatus ProductStatus { get; set; } = ProductStatus.Unknown;
        public ProductType productType { get; set; } = ProductType.Unknown;

        [Required]
        public CreateAddreesDto Address { get; set; }
        public List<ImageUploadRequestDto>? Images { get; set; }
        public Guid ProjectId { get; set; } = Guid.Empty;   
        public List<PropertiesBuildingDto>? propeties { get; set; }
    }
}
