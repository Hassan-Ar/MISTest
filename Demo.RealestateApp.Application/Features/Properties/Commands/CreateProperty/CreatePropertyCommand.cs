using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Buildings.Commands.UpdateBuilding;
using Demo.RealestateApp.Application.Features.Buildings.Queries;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Domain.Common;
using MediatR;


namespace Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty
{
    public class CreatePropertyCommand : IRequest<Guid>
    {
        public int NumberOfRooms { get; set; }
        public int NumberOfWindows { get; set; }
        public int NumberOfBeeds { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public List<ImageUploadRequestDto>? ImagesPath { get; set; }
        public ProductStatus ProductStatus { get; set; } = ProductStatus.Unknown;
        public ProductType productType { get; set; } = ProductType.Unknown;
        public CreateAddreesDto Address { get; set; }
        public Guid? buildingId { get; set; } 
    }
}
