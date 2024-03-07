using Demo.RealestateApp.App.Service.Base;

namespace Demo.RealestateApp.App.ViewModels
{
    public class ProjectBuildingsViewModel
    {
        public Guid Id { get; set; }
        public string ProductTitle { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        public ProductStatus productStatus { get; set; } = ProductStatus._0;
        public ProductType productType { get; set; }  
        public List<ImageViewModel>? Images { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
