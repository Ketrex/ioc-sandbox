using Ioc.Domain;
using Ioc.Domain.Abstraction;

namespace Ioc.Implementation
{
    public class ServiceRunner : Root, IServiceRunner
    {
        public ServiceRunner(IService service) : base("Service Runner")
        {
        }

        public void Run()
        {

        }
    }
}