using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Commands.DeleteProperty
{
    public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand>
    {
        private readonly IAsyncBaseRepository<Property> _propertyrepository;

        public DeletePropertyCommandHandler(IAsyncBaseRepository<Property> propertyrepository)
        {
            _propertyrepository = propertyrepository;
        }

        public async Task Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
           var property =  await _propertyrepository.GetByIdAsync(request.Id);
            await _propertyrepository.DeleteAsync(property);
        }
    }
}
