using Microsoft.Extensions.DependencyInjection;

using System;

namespace Kartrider.Api.AspNetCore
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public static IServiceCollection AddKartriderApi(this IServiceCollection serviceCollection, string apiKey)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }
            serviceCollection.AddSingleton<IKartriderApi>(KartriderApi.GetInstance(apiKey));
            return serviceCollection;
        }
    }
}
