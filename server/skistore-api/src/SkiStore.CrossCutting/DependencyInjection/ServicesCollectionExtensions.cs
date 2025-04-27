// using Microsoft.Extensions.DependencyInjection;
// using System;
// using System.Linq;
// using System.Reflection;

// namespace SkiStore.CrossCutting.DependencyInjection;

// public static class ServiceCollectionExtensions
// {
//     public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, Assembly assembly)
//     {
//         var types = assembly.GetTypes()
//                             .Where(type => type.IsClass && !type.IsAbstract)
//                             .Select(type => new
//                             {
//                                 Interface = type.GetInterfaces().FirstOrDefault(i => i.Name.EndsWith("Repository")),
//                                 Implementation = type
//                             })
//                             .Where(t => t.Interface != null);

//         foreach (var type in types)
//         {
//             services.AddScoped(type.Interface, type.Implementation);
//         }

//         return services;
//     }
// }
