

using BlazorApp2.Service.Base;

namespace BlazorApp2.ViewModels
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; } 
        public string ProductTitle { get; set; } = string.Empty;
        public string ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; }
        public List<ImageViewModel>? ImagesPath { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType productType { get; set; }
        public AddressViewModel ProductAddress { get; set; }
        public List<ProjectBuildingsViewModel>? Buildings { get; set; }
    }
}
