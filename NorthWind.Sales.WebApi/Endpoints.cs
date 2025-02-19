﻿namespace NorthWind.Sales.WebApi
{
    public static class Endpoints
    {
        public static WebApplication UseNortWindSalesEndpoints(
            this WebApplication app)
        {
            app.MapPost("/create", async (CreateOrderDTO order,
                ICreateOrderController controller) =>
            Results.Ok(await controller.CreateOrder(order)));
            return app;
        }
    }
}
