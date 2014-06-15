using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.View;
using StructureMap;

namespace OpenCBS.ArchitectureV2
{
    public class ApplicationController : IApplicationController
    {
        private readonly IContainer _container;
        private readonly IEventPublisher _eventPublisher;

        public ApplicationController(IContainer container, IEventPublisher eventPublisher)
        {
            _container = container;
            _eventPublisher = eventPublisher;
        }

        public void Execute<T>(T commandData)
        {
            try
            {
                var command = _container.TryGetInstance<ICommand<T>>();
                if (command != null)
                {
                    command.Execute(commandData);
                }
            }
            catch (Exception error)
            {
                var errorView = _container.GetInstance<IErrorView>();
                errorView.Run(error.Message);
            }
        }

        public void Raise<T>(T eventData)
        {
            _eventPublisher.Publish(eventData);
        }

        public void Unsubscribe(object eventHandlers)
        {
            _eventPublisher.Unsubscribe(eventHandlers);
        }
    }
}
