using System.Windows.Forms;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.Interface.Presenter
{
    public interface IRepaymentPresenter : IPresenter
    {
        DialogResult Run(Loan loan);
    }
}
