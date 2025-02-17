﻿using MediatR;
using PharmacyManagement_BE.Infrastructure.Common.DTOs.PromotionDTOs;
using PharmacyManagement_BE.Infrastructure.Common.ResponseAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Application.Queries.PromotionFeatures.Requests
{
    public class GetDetailsPromotionQueryRequest : IRequest<ResponseAPI<DetailsPromotionDTO>>
    {
        public Guid Id { get; set; }

        public GetDetailsPromotionQueryRequest(Guid Id)
        {
            this.Id = Id;
        }
        public GetDetailsPromotionQueryRequest() { }
    }
}
