﻿using PharmacyManagement_BE.Domain.Entities;
using PharmacyManagement_BE.Domain.Types;
using PharmacyManagement_BE.Infrastructure.Common.DTOs.OrderDTOs;
using PharmacyManagement_BE.Infrastructure.Common.DTOs.OrderEcommerceDTOs;
using PharmacyManagement_BE.Infrastructure.Common.DTOs.StatisticDTOs;
using PharmacyManagement_BE.Infrastructure.Common.ResponseAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Infrastructure.Respositories.Services
{
    public interface IOrderService : IRepositoryService<Order>
    {
        Task<List<Order>> GetAllOrderByStaffId(Guid id);
        Task<List<StatisticOrderDTO>> StatisticOrder(TimeType type, DateTime dateTime);
        Task<List<StatisticRevenueDTO>> StatisticRevenue(TimeType type, DateTime dateTime);
        //Task<List<OrderDTO>> GetCanceledOrder();
        Task<OrderDTO> GetOrderByBranch(Guid OrderId, Guid BranchId);
        Task<List<OrderDTO>> GetOrdersByBranch(Guid BranchId, OrderType type);
        Task<GeneralStatisticsDTO> RealTimeStatistc();
        bool CheckUpdateStatus(Order order, OrderType status);
        //Task<List<OrderDTO>> GetRequestCancellations();
        Task<Order?> GetOrderByCode(string codeOrder);
        Task<List<ItemOrderDTO>> GetMyOrders(Guid customerId);
    }
}
