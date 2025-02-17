﻿using MediatR;
using PharmacyManagement_BE.Infrastructure.Common.ResponseAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Application.Commands.ShipmentFeatures.Requests
{
    public class CreateShipmentCommandRequest : IRequest<ResponseAPI<string>>
    {
        public string Note { get; set; }
        public string Status { get; set; }
        public Guid SupplierId { get; set; }
        public string CodeShipment { get; set; }
        public DateTime ImportDate { get; set; }
    }
}
