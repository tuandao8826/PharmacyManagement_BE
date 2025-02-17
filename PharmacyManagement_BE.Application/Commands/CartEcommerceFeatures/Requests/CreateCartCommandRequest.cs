﻿using MediatR;
using PharmacyManagement_BE.Infrastructure.Common.ResponseAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Application.Commands.CartEcommerceFeatures.Requests
{
    public class CreateCartCommandRequest : IRequest<ResponseAPI<string>>
    {
        public Guid ProductId { get; set; }
        public Guid UnitId { get; set; }
        public int Quantity { get; set; }
    }
}
