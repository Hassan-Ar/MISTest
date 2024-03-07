using Demo.RealestateApp.App1.Service.Base;
using Demo.RealestateApp1.App.ViewModels;
using System.ComponentModel.DataAnnotations;
namespace Demo.RealestateApp.App1.ViewModels
{
    public class PropertyDetailVeiwModel
    {
        public Guid? Id { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfWindows { get; set; }
        public int NumberOfBeeds { get; set; }
        public Guid? BuildingId { get; set; } = null;
        public Guid? AddressGuid { get; set; }
        public AddressViewModel ProductAddress { get; set; } 
        public string? ProductTitle { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }
        public double ProductSize { get; set; } = 44;
        public double ProductPrice { get; set; } = 55;
        public bool ProductAvailability { get; set; } = false;
        public List<ImageViewModel>? ImagesPath { get; set; }
        public ProductStatus ProductStatus { get; set; } 
        public ProductType productType { get; set; } 
    }
}
