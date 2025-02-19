﻿
using System.Threading.Tasks;

namespace NorthWind.Sales.BusinessObjects.Repositories
{
    public interface INorthWindSalesCommandsRepository : IUnitOfWork
    {
        ValueTask CreateOrder(OrderAggregate order);
    }
}
