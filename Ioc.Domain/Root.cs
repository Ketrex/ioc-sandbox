using System;

namespace Ioc.Domain
{
    public abstract class Root
    {
        protected Root(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name + " - " + Guid.NewGuid();
        }

        public string Name { get; }
    }
}
