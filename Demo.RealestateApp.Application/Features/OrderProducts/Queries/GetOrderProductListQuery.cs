﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.OrderProducts.Queries
{
    public class GetOrderProductListQuery : IRequest<List<GetOrderProductDto>>
    {
    }
}
