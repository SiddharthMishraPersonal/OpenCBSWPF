using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Service;
using StructureMap;

namespace OpenCBS.ArchitectureV2
{
    public class Bootstrapper
    {
        private readonly IContainer _container;

        public Bootstrapper(IContainer container)
        {
            _container = container;
        }

        public ApplicationContext GetAppContext()
        {
            _container.Configure(c => c.AddRegistry<DefaultRegistry>());
            _container.Inject<ApplicationContext>(new AppContext(_container));
            _container.GetInstance<ITranslationService>().Reload();
            return _container.GetInstance<ApplicationContext>();
        }
    }
}
