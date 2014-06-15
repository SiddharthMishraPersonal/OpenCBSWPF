using OpenCBS.CoreDomain.Events.Loan;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OpenCBS.GUI.UserControl
{
    public partial class WriteOffOkCancelForm : Form
    {
        public int OptionId
        {
            get { return (int) _optionComboBox.SelectedValue; }
        }

        public string Comment
        {
            get { return _commentTextBox.Text; }
        }

        public WriteOffOkCancelForm()
        {
            InitializeComponent();
        }

        public void ShowWriteOffOptions(IList<WriteOffOption> options)
        {
            var dict = options.ToDictionary(x => x.Id, x => x.Name);
            _optionComboBox.DisplayMember = "Value";
            _optionComboBox.ValueMember = "Key";
            _optionComboBox.DataSource = new BindingSource(dict, null);
            _optionComboBox.SelectedIndex = 0;
        }
    }
}
