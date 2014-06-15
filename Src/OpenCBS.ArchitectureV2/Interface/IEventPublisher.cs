namespace OpenCBS.ArchitectureV2.Interface
{
    public interface IEventPublisher
    {
        void Subscribe(object eventHandlers);
        void Unsubscribe(object eventHandlers);
        void Publish<T>(T eventData);
    }
}