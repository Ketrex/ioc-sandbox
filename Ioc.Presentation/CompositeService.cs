using Ioc.Domain;
using Ioc.Domain.Abstraction;
using System;
using System.Collections.Generic;

namespace Ioc.Presentation
{
    public class CompositeService : Root, IService
    {
        private readonly IEnumerable<IService> services;
        public CompositeService(IEnumerable<IService> services) : base("Composite Service")
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public void Do()
        {
            foreach (var service in services)
            {
                service.Do();
            }
        }
    }
}