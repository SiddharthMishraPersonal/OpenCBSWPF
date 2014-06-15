using System;
using System.Linq;
using OpenCBS.ArchitectureV2.Interface;
using StructureMap;
using StructureMap.Interceptors;

namespace OpenCBS.ArchitectureV2
{
    public class EventAggregatorInterceptor : TypeInterceptor
    {
        public bool MatchesType(Type type)
        {
            if (type.IsGenericType) return false;

            var templateType = typeof(IEventHandler<>);
            return type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == templateType);
        }

        public object Process(object target, IContext context)
        {
            var eventPublisher = context.GetInstance<IEventPublisher>();
            eventPublisher.Subscribe(target);
            return target;
        }
    }
}
