﻿using MediatR;
using Microsoft.AspNetCore.Http;
using PharmacyManagement_BE.Application.Queries.StatisticFeatures.Requests;
using PharmacyManagement_BE.Infrastructure.Common.DTOs.StatisticDTOs;
using PharmacyManagement_BE.Infrastructure.Common.ResponseAPIs;
using PharmacyManagement_BE.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Application.Queries.StatisticFeatures.Handlers
{
    internal class Top10SoldProductQueryHandler : IRequestHandler<Top10SoldProductQueryRequest, ResponseAPI<List<StatisticProductOrderDTO>>>
    {
        private readonly IPMEntities _entities;

        public Top10SoldProductQueryHandler(IPMEntities entities)
        {
            this._entities = entities;
        }

        public async Task<ResponseAPI<List<StatisticProductOrderDTO>>> Handle(Top10SoldProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var top10 = await _entities.ProductService.GetTopSoldProduct();
                //Kiểm tra get danh sách
                if(top10 == null)
                    return new ResponseErrorAPI<List<StatisticProductOrderDTO>>(StatusCodes.Status500InternalServerError, "Lỗi hệ thống.");

                return new ResponseSuccessAPI<List<StatisticProductOrderDTO>>(StatusCodes.Status200OK, "Top 10 bán chạy", top10);
            }
            catch (Exception)
            {
                return new ResponseErrorAPI<List<StatisticProductOrderDTO>>(StatusCodes.Status500InternalServerError, "Lỗi hệ thống.");
            }
        }
    }
}
