﻿using ContosoOnlineOrders.Abstractions;
using ContosoOnlineOrders.DataProviders.Cosmos;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCosmosDbStorage(
            this IServiceCollection services, string connectionString)
        {
            services.AddCosmosRepository(
                options =>
                {
                    options.CosmosConnectionString = connectionString;
                    options.ContainerId = "Contoso";
                    options.DatabaseId = "OnlineOrders";
                    options.ContainerPerItemType = true;
                });

            services.AddSingleton<IStoreDataService, CosmosDataProvider>();
            return services;
        }
    }
}
