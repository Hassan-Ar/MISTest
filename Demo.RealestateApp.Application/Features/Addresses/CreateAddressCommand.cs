using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Addresses
{
    public class CreateAddressCommand : ICreateAddressCommand
    {
        private readonly IAsyncBaseRepository<Address> baseRepository;
        private readonly IMapper mapper;

        public CreateAddressCommand(IAsyncBaseRepository<Address> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<Address> CreatAddress(CreateAddreesDto input)
        {
           var address =  mapper.Map<Address>(input);
            var result = await baseRepository.AddAsync(address);
            return result;
        }
    }
}
