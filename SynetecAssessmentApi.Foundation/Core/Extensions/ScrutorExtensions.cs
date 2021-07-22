using System;
using System.Linq;
using Scrutor;

namespace SynetecAssessmentApi.Foundation.Core.Extensions
{
    public static class ScrutorExtensions
    {
        public static ILifetimeSelector AsImplementationOfInterface(this IServiceTypeSelector selector, Type type)
        {
            return selector.As(t => t.GetInterfaces().Where(i =>
                type.IsGenericType && i.IsGenericType && i.GetGenericTypeDefinition() == type || i == type));
        }
    }
}