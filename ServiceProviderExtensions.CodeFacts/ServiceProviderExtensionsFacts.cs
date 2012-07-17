using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;

namespace ServiceProviderExtensions
{
    public class ServiceProviderExtensionsFacts
    {
        [TestClass]
        public class TheGetServiceMethod
        {
            [TestMethod]
            public void ReturnsNull_WhenNoServicesExist()
            {
                var serviceProvider = new Mock<IServiceProvider>();
                serviceProvider.Setup(m => m.GetService(typeof(IServiceProvider)))
                    .Returns(null);
                var services = serviceProvider.Object.GetService<IServiceProvider>();
                services.ShouldBeNull();
            }
        }

        [TestClass]
        public class TheGetServicesMethod
        {
            [TestMethod]
            public void ReturnsEmptyEnumerable_WhenNoServicesExist()
            {
                var serviceProvider = new Mock<IServiceProvider>();
                serviceProvider.Setup(m => m.GetService(typeof(IEnumerable<IServiceProvider>)))
                    .Returns(null);
                var services = serviceProvider.Object.GetServices<IServiceProvider>().ToArray();
                services.ShouldNotBeNull();
                services.ShouldImplement<IEnumerable<IServiceProvider>>();
                services.ShouldBeEmpty();
            }

            [TestMethod]
            public void ReturnsPopulatedEnumerable_WhenMultipleServicesExist()
            {
                var serviceProvider = new Mock<IServiceProvider>();
                var sp1 = new Mock<IServiceProvider>();
                var sp2 = new Mock<IServiceProvider>();
                serviceProvider.Setup(m => m.GetService(typeof(IEnumerable<IServiceProvider>)))
                    .Returns(new[] { sp1.Object, sp2.Object });
                var services = serviceProvider.Object.GetServices<IServiceProvider>().ToArray();
                services.ShouldNotBeNull();
                services.ShouldImplement<IEnumerable<IServiceProvider>>();
                services.ShouldNotBeEmpty();
                services.Length.ShouldEqual(2);
            }
        }
    }
}
