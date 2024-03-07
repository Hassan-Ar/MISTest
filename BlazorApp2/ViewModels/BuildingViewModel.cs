
using BlazorApp2.Service.Base;

namespace BlazorApp2.ViewModels
{
    public class BuildingViewModel
    {
        public Guid Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public int NumberOfProperties { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public bool HasGarage { get; set; }
        public ProductStatus productStatus { get; set; } 
        public ProductType productType { get; set; }
        public AddressViewModel ProductAddress { get; set; }
        public List<ImageViewModel>? Images { get; set; }
        public Guid? ProjectId { get; set; }
        public List<PropertiesBuildingDto>? propeties { get; set; }
    }
}
