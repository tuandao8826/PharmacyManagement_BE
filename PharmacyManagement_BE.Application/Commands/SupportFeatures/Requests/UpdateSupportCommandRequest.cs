﻿using MediatR;
using Microsoft.AspNetCore.Http;
using PharmacyManagement_BE.Application.Commands.SymptomFeatures.Requests;
using PharmacyManagement_BE.Infrastructure.Common.ResponseAPIs;
using PharmacyManagement_BE.Infrastructure.Common.ValidationNotifies;
using PharmacyManagement_BE.Infrastructure.Customs.SupportFunctions;
using PharmacyManagement_BE.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Application.Commands.SupportFeatures.Requests
{
    public class UpdateSupportCommandRequest : IRequest<ResponseAPI<string>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CodeSupport { get; set; }

        public ValidationNotify<string> IsValid()
        {
            Name = CheckInput.CheckInputName(Name);
            Description = CheckInput.CheckInputName(Description);
            CodeSupport = CheckInput.CheckInputCode(CodeSupport);

            if (string.IsNullOrWhiteSpace(Name))
                return new ValidationNotifyError<string>("Vui lòng nhập tên hỗ trợ của thuốc.", "name");

            if (string.IsNullOrWhiteSpace(CodeSupport))
                return new ValidationNotifyError<string>("Vui lòng nhập mã hỗ trợ của thuốc.", "description");

            if (!CheckInput.IsAlphaNumeric(CodeSupport))
                return new ValidationNotifyError<string>("Mã hỗ trợ của thuốc không hợp lệ, vui lòng kiểm tra lại", "codeSupport");

            return new ValidationNotifySuccess<string>();
        }
    }
}
