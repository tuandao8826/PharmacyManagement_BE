﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using PharmacyManagement_BE.Application.Queries.OrderFeatures.Requests;
using PharmacyManagement_BE.Domain.Entities;
using PharmacyManagement_BE.Infrastructure.Common.DTOs.DiseaseDTOs;
using PharmacyManagement_BE.Infrastructure.Common.DTOs.OrderDTOs;
using PharmacyManagement_BE.Infrastructure.Common.ResponseAPIs;
using PharmacyManagement_BE.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Application.Queries.OrderFeatures.Handlers
{
    internal class GetDetailsOrderQueryHandler : IRequestHandler<GetDetailsOrderQueryRequest, ResponseAPI<OrderDTO>>
    {
        private readonly IPMEntities _entities;
        private readonly IMapper _mapper;

        public GetDetailsOrderQueryHandler(IPMEntities entities, IMapper mapper)
        {
            this._entities = entities;
            this._mapper = mapper;
        }

        public async Task<ResponseAPI<OrderDTO>> Handle(GetDetailsOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //Lấy Branch của nhân viên
                var branch = await _entities.AccountService.GetBranchId();

                //Kiểm tra tồn tại
                var order = await _entities.OrderService.GetOrderByBranch(request.Id, branch);

                if (order == null)
                    return new ResponseSuccessAPI<OrderDTO>(StatusCodes.Status404NotFound, "Đơn hàng không tồn tại.");

                return new ResponseSuccessAPI<OrderDTO>(StatusCodes.Status200OK, "Thông tin đơn hàng", order);
            }
            catch (Exception)
            {
                return new ResponseErrorAPI<OrderDTO>(StatusCodes.Status500InternalServerError, "Lỗi hệ thống.");
            }
        }
    }
}
