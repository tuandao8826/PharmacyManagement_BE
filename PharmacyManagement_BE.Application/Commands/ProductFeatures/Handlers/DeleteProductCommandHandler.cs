﻿using MediatR;
using Microsoft.AspNetCore.Http;
using PharmacyManagement_BE.Application.Commands.ProductFeatures.Requests;
using PharmacyManagement_BE.Infrastructure.Common.ResponseAPIs;
using PharmacyManagement_BE.Infrastructure.Common.ValidationNotifies;
using PharmacyManagement_BE.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Application.Commands.ProductFeatures.Handlers
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, ResponseAPI<string>>
    {
        private readonly IPMEntities _entities;

        public DeleteProductCommandHandler(IPMEntities entities)
        {
            this._entities = entities;
        }

        public async Task<ResponseAPI<string>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validation = new ValidationNotify<string>();

                // kiểm tra chi nhánh tồn tại
                var product = await _entities.ProductService.GetById(request.ProductId);

                if (product == null)
                    return new ResponseErrorAPI<string>(StatusCodes.Status404NotFound, "Sản phẩm không tồn tại.");

                // Kiểm tra sản phẩm đã tồn tại trong kho
                var shipmentDetails = await _entities.ShipmentDetailsService.GetShipmentDetailsByProductId(request.ProductId);

                if (shipmentDetails != null)
                {
                    validation.Obj = "default";
                    validation.Message = $"Sản phẩm đã tồn tại trong kho";
                    return new ResponseErrorAPI<string>(StatusCodes.Status409Conflict, validation);
                }

                // Xóa sản phẩm
                var result = _entities.ProductService.Delete(product);

                if (!result)
                {
                    validation.Obj = "default";
                    validation.Message = $"Hiện tại không thể xóa sản phẩm này.";
                    return new ResponseErrorAPI<string>(StatusCodes.Status409Conflict, validation);
                }

                // SaveChange
                _entities.SaveChange(); 

                return new ResponseSuccessAPI<string>(StatusCodes.Status200OK, $"Xóa sản phẩm có mã {product.CodeMedicine} thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ResponseErrorAPI<string>(StatusCodes.Status500InternalServerError, "Lỗi hệ thống.");
            }
        }
    }
}
