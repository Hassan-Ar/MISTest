using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Addresses
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string? Country { get; set; } =string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty; 
    }
}
