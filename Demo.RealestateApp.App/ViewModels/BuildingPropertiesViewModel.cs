using Demo.RealestateApp.App.Service.Base;

namespace Demo.RealestateApp.App.ViewModels
{
    public class BuildingPropertiesViewModel
    {
        public Guid Id { get; set; }
        public Guid? BuildingId { get; set; }
        public BuildingViewModel? building { get; set; }
        public string? ProductTitle { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public List<ImageViewModel>? ImagesPath { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType productType { get; set; }
    }
}
