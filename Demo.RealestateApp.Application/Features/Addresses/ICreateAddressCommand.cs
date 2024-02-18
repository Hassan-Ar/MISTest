using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Addresses
{
    public interface ICreateAddressCommand 
    {
        public Task<Address> CreatAddress(CreateAddreesDto input);
    }
}
