using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class UpgradeView : BaseView, IUpgradeView
    {
        public UpgradeView(ITranslationService translationService)
            : base(translationService)
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Run()
        {
            Show();
        }

        public void Stop()
        {
            Close();
        }

        public bool Upgraded { get; set; }
    }
}
