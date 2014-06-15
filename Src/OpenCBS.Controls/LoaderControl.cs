using System.Drawing;
using System.Windows.Forms;

namespace OpenCBS.Controls
{
    public partial class LoaderControl : UserControl
    {
        private Control _attachTo;

        public LoaderControl()
        {
            InitializeComponent();
        }

        public void AttachTo(Control control)
        {
            _attachTo = control;
            var y = _attachTo.Location.Y;
            y += (_attachTo.Size.Height - 18) / 2;
            Location = new Point(_attachTo.Location.X, y);
            Size = new Size(_attachTo.Size.Width, 18);
        }

        public void Start()
        {
            if (_attachTo != null)
            {
                Visible = true;
                _attachTo.Visible = false;
            }
            loaderPictureBox.Enabled = true;
        }

        public void Stop()
        {
            if (_attachTo != null)
            {
                Visible = false;
                _attachTo.Visible = true;
            }
            loaderPictureBox.Enabled = false;
        }
    }
}
