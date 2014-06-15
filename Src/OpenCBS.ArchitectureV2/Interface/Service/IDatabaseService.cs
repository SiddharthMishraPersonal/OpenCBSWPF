using System.Collections.Generic;

namespace OpenCBS.ArchitectureV2.Interface.Service
{
    public interface IDatabaseService
    {
        IList<string> FindAll();
        bool IsServerConnectionOk();
        bool IsVersionOk();
        void UpdateDatabase();
    }
}
