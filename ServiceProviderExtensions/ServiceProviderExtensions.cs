using System;
using System.Collections.Generic;
using System.Linq;

public static class ServiceProviderExtensions
{
    public static TService GetService<TService>(this IServiceProvider serviceProvider)
    {
        return (TService)serviceProvider.GetService(typeof(TService));
    }

    public static IEnumerable<TService> GetServices<TService>(this IServiceProvider serviceProvider)
    {
        // make IEnumerable<TService>
        var genericEnumerable = typeof(IEnumerable<>).MakeGenericType(typeof(TService));

        // invoke IServiceProvider.GetService(typeof(IEnumerable<TService>))
        var servicesObject = serviceProvider.GetService(genericEnumerable);

        // cast object to IEnumerable<object>
        var servicesEnumerable = (IEnumerable<object>)servicesObject;

        // when null, return an empty IEnumerable<TService>
        if (servicesEnumerable == null) return Enumerable.Empty<TService>();

        // otherwise, cast IEnumerable<object> to IEnumerable<TService>
        var strongEnumerable = servicesEnumerable.Cast<TService>();

        return strongEnumerable;
    }
}
