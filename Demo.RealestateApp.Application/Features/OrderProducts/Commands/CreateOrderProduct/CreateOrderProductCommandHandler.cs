using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.OrderProducts.Commands.CreateOrderProduct
{
    public class CreateOrderProductCommandHandler : IRequestHandler<CreateOrderProductCommand, bool>
    {
        private readonly IOrderProductRepository _orederProductRepository;
        private readonly IMapper _mapper;

        public CreateOrderProductCommandHandler(IOrderProductRepository orederProductRepository, IMapper mapper)
        {
            _orederProductRepository = orederProductRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateOrderProductCommand request, CancellationToken cancellationToken)
        {
            //Property Validation
            var validator = new CreateOrderProductCommandValidator(_orederProductRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var inputDto =  _mapper.Map<OrderProduct>(request);
            var result = await _orederProductRepository.AddAsync(inputDto);

            if(result is not null)
            {
                return true;
            }
            return false;

        }
    }
}
