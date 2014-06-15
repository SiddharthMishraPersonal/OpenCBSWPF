namespace OpenCBS.ArchitectureV2.Interface
{
    public interface IEventHandler<T>
    {
        void Handle(T eventData);
    }
}
