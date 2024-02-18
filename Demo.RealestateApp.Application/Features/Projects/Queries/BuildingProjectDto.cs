using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Queries
{
    public class BuildingProjectDto
    {
        public Guid Id { get; set; }
        public AddressDto ProductAddress { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public List<ImageUploadRequestDto> ImagesPath { get; set; }
        public ProductStatus ProductStatus { get; set; } = ProductStatus.Unknown;
        public ProductType productType { get; set; } = ProductType.Unknown;
        public int NumberOfProperties { get; set; }
        public bool HasGarage { get; set; }
        public Guid ProjectId { get; set; }
    }
}
