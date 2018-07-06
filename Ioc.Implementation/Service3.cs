using Ioc.Domain;
using Ioc.Domain.Abstraction;
using System;

namespace Ioc.Implementation
{
    public class Service3 : Root, IService
    {
        public Service3() : base("Service 3")
        {
        }

        public void Do()
        {
            Console.WriteLine("Servie 1 is doing something.");
        }
    }
}