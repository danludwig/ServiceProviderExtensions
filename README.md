ServiceProviderExtensions
=========================

Generic GetService&lt;T&gt; and GetServices&lt;T&gt; extension methods for the System.IServiceProvider interface.

## Resolving a single service

    IServiceProvider serviceProvider = HoweverYouGetAnInstance();

    // instead of this
    // ISomeInterface implementation = serviceProvider.GetService(typeof(ISomeInterface))

    // use the extension
    ISomeInterface implementation = serviceProvider.GetService<ISomeInterface>();

## Resolving multiple services

    IServiceProvider serviceProvider = HoweverYouGetAnInstance();

    // get a multiply-registered interface without any overhead
    IEnumerable<ISomeInterface> implementations = serviceProvider.GetServices<ISomeInterface>();

## License
This software is subject to the terms of the [Microsoft Public License (Ms-PL)](http://www.opensource.org/licenses/MS-PL).
