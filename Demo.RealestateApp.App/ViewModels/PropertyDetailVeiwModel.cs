using Demo.RealestateApp.App.Service.Base;
namespace Demo.RealestateApp.App.ViewModels

{
    public class PropertyDetailVeiwModel
    {
        public Guid Id { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfWindows { get; set; }
        public int NumberOfBeeds { get; set; }
        public Guid? BuildingId { get; set; }
        public BuildingViewModel? building { get; set; }
        public Guid? AddressGuid { get; set; }
        public AddressViewModel? ProductAddress { get; set; }
        public string? ProductTitle { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public List<ImageViewModel>? ImagesPath { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType productType { get; set; }
    }
}
