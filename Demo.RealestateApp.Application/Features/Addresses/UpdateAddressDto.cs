using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Addresses
{
    public class UpdateAddressDto
    {
        public Guid Id { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
