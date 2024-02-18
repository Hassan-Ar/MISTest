using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Domain.Entities
{
    public class OrderProduct : BaseEntity
    {
        public Guid Id { get; set; }
        public bool AcceptOrder { get; set; } = false;
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Guid ProductId { get; set; }
        public double productPrice { get; set; }
        public ProductType productType { get; set; } = ProductType.Unknown;
        public ProductStatus productStatus { get; set; } = ProductStatus.Unknown;

        
    }
}
