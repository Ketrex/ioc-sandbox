using Autofac;
using Ioc.Domain.Abstraction;
using Ioc.Implementation;
using System;
using System.Collections.Generic;

namespace Ioc.Presentation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Application Started");

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ServiceRunner>().As<IServiceRunner>().WithParameter((p,c) => p.ParameterType == typeof(CompositeService),
                (p,c) => c.Resolve<IService>());
            containerBuilder.RegisterType<Service1>().As<IService>()
                .Named<IService>("iService")
                .OnActivated(e =>
                {
                    Console.WriteLine($"{e.Instance.Name} was created for scope");
                })
                .OnRelease(e=>
                {
                    Console.WriteLine($"{e.Name} is being released");
                });
            containerBuilder.RegisterType<Service2>().As<IService>()
                .Named<IService>("iService")
                .OnActivated(e =>
                {
                    Console.WriteLine($"{e.Instance.Name} was created for scope");
                }).OnRelease(e=>
                {
                    Console.WriteLine($"{e.Name} is being released");
                });
            containerBuilder.RegisterType<Service3>().As<IService>()
                .Named<IService>("iService")
                .OnActivated(e =>
                {
                    Console.WriteLine($"{e.Instance.Name} was created for scope");
                }).OnRelease(e=>
                {
                    Console.WriteLine($"{e.Name} is being released");
                });

            containerBuilder.RegisterType<CompositeService>().As<IService>().Named<IService>("compositeService")
                .OnActivated(e => { Console.WriteLine($"{e.Instance.Name} was created for scope"); })
                .OnRelease(e => { Console.WriteLine($"{e.Name} is being released"); })
                .WithParameter(
                    (p, c) => p.Name != "compositeService",
                    (p, c) => c.ResolveNamed<IEnumerable<IService>>("iService"));

            var container = containerBuilder.Build();

            container.ChildLifetimeScopeBeginning += (sender, evnt) =>
            {
                Console.WriteLine($"Scope {evnt.LifetimeScope.Tag} beginning");
            };
            container.CurrentScopeEnding += (sender, evnt) =>
            {
                Console.WriteLine($"Scope {evnt.LifetimeScope.Tag} is ending.");
            };

            using (var scope = container.BeginLifetimeScope("child"))
            {
                scope.CurrentScopeEnding += (sender, evnt) =>
                {
                    Console.WriteLine($"Scope {evnt.LifetimeScope.Tag} is ending.");
                };
                var runner = scope.Resolve<IServiceRunner>();
            }

            Console.WriteLine("Application Ended.");
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}
