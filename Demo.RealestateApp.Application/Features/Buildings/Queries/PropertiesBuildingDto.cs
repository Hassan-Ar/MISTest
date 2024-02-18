using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Queries
{
    public class PropertiesBuildingDto
    {
        public Guid Id { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfWindows { get; set; }
        public int NumberOfBeeds { get; set; }
        public Guid BuildingId { get; set; }
        public Address? ProductAddress { get; set; }
        public string? ProductTitle { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public List<string>? ImagesPath { get; set; }
        public ProductStatus ProductStatus { get; set; } = ProductStatus.Unknown;
        public ProductType productType { get; set; } = ProductType.Unknown;
    }
}
