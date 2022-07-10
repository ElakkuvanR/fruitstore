using FruitStore.OrderCloud.Client.Interfaces;
using FruitStore.OrderCloud.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.OrderCloud.Client
{
    public static class ServiceCollectionExtension
    {
        public static void AddFruitStoreServiceCollections(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IFSMeResource, FSMeResource>();
        }
    }
}
