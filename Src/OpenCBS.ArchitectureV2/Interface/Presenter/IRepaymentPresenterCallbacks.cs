namespace OpenCBS.ArchitectureV2.Interface.Presenter
{
    public interface IRepaymentPresenterCallbacks
    {
        void OnRepay();
        void OnRefresh();
        void OnCancel();
    }
}
