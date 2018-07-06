using Ioc.Domain;
using Ioc.Domain.Abstraction;
using System;

namespace Ioc.Implementation
{
    public class Service1 : Root, IService
    {
        public Service1() : base("Service 1")
        {
        }

        public void Do()
        {
            Console.WriteLine("Servie 1 is doing something.");
        }
    }
}