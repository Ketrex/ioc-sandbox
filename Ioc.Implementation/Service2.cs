using Ioc.Domain;
using Ioc.Domain.Abstraction;
using System;

namespace Ioc.Implementation
{
    public class Service2 : Root, IService
    {
        public Service2() : base("Service 2")
        {
        }

        public void Do()
        {
            Console.WriteLine("Servie 1 is doing something.");
        }
    }
}