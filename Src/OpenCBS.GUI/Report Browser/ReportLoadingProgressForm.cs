using System;
using System.Windows.Forms;

namespace OpenCBS.GUI.Report_Browser
{
    public partial class ReportLoadingProgressForm : Form
    {
        private DateTime _startDate;

        public ReportLoadingProgressForm()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            Load += (sender, args) => LoadForm();
            timer.Tick += (sender, args) => Tick();
        }

        private void LoadForm()
        {
            _startDate = DateTime.Now;
            timer.Enabled = true;
            loaderControl.Start();
        }

        private void Tick()
        {
            var timeSpan = DateTime.Now - _startDate;
            elapsedTimeLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}
