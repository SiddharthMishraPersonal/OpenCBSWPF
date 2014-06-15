namespace OpenCBS.ArchitectureV2.Interface.View
{
    public interface IView<in TCallbacks>
    {
        void Attach(TCallbacks presenterCallbacks);
    }
}
