﻿using System.Threading.Tasks;

namespace NorthWind.Sales.BusinessObjects.Interfaces.Controllers
{
    public interface ICreateOrderController
    {
        ValueTask<int> CreateOrder(CreateOrderDTO order);
    }
}
