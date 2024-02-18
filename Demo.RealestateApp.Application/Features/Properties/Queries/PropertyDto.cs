using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Buildings.Queries;
using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Queries
{
    public class PropertyDto
    {
        public Guid Id { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfWindows { get; set; }
        public int NumberOfBeeds { get; set; }
        public Guid? BuildingId { get; set; } 
        public BuildingDto? building { get; set; }
        public Guid? AddressGuid { get; set; }
        public AddressDto? ProductAddress { get; set; }
        public string? ProductTitle { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public List<Image>? ImagesPath { get; set; }
        public ProductStatus ProductStatus { get; set; } 
        public ProductType productType { get; set; } 
    }
}
