using OpenCBS.CoreDomain;

namespace OpenCBS.ArchitectureV2.Interface.Service
{
    public interface IAuthService
    {
        User Login(string username, string password);
        bool LoggedIn { get; }
    }
}
