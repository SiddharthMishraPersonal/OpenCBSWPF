namespace OpenCBS.ArchitectureV2.Interface
{
    public interface ICommand<in T>
    {
        void Execute(T commandData);
    }
}
