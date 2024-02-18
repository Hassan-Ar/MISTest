using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Commands.UpdateProperty
{
    public class UpdatePropertyCommand : IRequest
    {
        public Guid Id { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfWindows { get; set; }
        public int NumberOfBeeds { get; set; }
        public Guid AddressId { get; set; }
        public UpdateAddressDto Address { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public Guid BuildingId { get; set; } = Guid.Empty;
        public List<ImageUploadRequestDto>? Images { get; set; }
        public ProductStatus ProductStatus { get; set; } = ProductStatus.Unknown;
        public ProductType productType { get; set; } = ProductType.Unknown;

    }
}
