using PharmacyManagement_BE.Domain.Entities;
using PharmacyManagement_BE.Infrastructure.Common.ResponseAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Infrastructure.Respositories.Services
{
    public interface IProductSupportService : IRepositoryService<ProductSupport>
    {
        Task<bool> CreateRange(List<ProductSupport> productSupports);
        Task<List<ProductSupport>> GetProductSupportsByProductId(Guid productId);
        Task<List<ProductSupport>> GetAllBySupport(Guid supportId);
        Task<ProductSupport> GetProductSupport(Guid supportId, Guid productId);
        Task<ResponseAPI<string>> CheckExit(Guid? productId, Guid? supportId);
    } 
}
