namespace OpenCBS.ArchitectureV2.Interface.Service
{
    public interface ITranslationService
    {
        string Translate(string key);
        void Reload();
    }
}
