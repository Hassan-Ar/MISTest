using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Domain.Common
{
    public class Product : BaseEntity
    {
      
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductAvailability { get; set; } = false;
        
        public ProductStatus ProductStatus { get; set; } = ProductStatus.Unknown;
        public ProductType productType { get; set; } = ProductType.Unknown;
    }
}
