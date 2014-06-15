
namespace OpenCBS.Engine.Interfaces
{
    public interface IRoundingPolicy : IPolicy
    {
        decimal Round(decimal amount);
    }
}
