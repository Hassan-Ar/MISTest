using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Commands.DeleteProperty
{
    public class DeletePropertyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
