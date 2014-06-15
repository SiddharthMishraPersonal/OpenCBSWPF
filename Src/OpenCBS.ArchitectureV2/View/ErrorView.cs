using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.View
{
    public class ErrorView : IErrorView
    {
        private readonly ITranslationService _translationService;

        public ErrorView(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        public void Run(string message)
        {
            MessageBox.Show(
                _translationService.Translate(message), 
                _translationService.Translate("Error"), 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }
}
