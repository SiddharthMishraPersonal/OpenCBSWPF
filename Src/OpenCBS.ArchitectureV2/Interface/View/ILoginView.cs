using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Interface.Presenter;

namespace OpenCBS.ArchitectureV2.Interface.View
{
    public interface ILoginView : IView<ILoginPresenterCallbacks>
    {
        void Run();
        void Stop();
        void StartDatabaseListRefresh();
        void StopDatabaseListRefresh();
        void ShowDatabases(IList<string> databases);
        string Username { get; }
        string Password { get; }
        string Database { get; set; }
    }
}
