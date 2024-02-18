using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Projects.Queries;
using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Queries
{
    public class BuildingDto
    {
        public AddressDto ProductAddress { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public List<Image>? Images { get; set; }
        public ProductStatus ProductStatus { get; set; } = ProductStatus.Unknown;
        public ProductType productType { get; set; } = ProductType.Unknown;
        public int NumberOfProperties { get; set; }
        public bool HasGarage { get; set; }
        public Guid? ProjectId { get; set; } 
        public ProjectDto? project { get; set; }
        public List<PropertiesBuildingDto>? propeties  { get; set; }

    }
}
