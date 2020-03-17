using System;
using System.Linq;
using System.Windows.Forms;
using RegexBuilder.Engine;

namespace RegexBuilder.UI
{
    public partial class frmGetInformation : Form
    {
        private frmGetInformation()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cmbInformationType.Items.AddRange(Enum.GetValues(typeof(InformationType)).Cast<object>().ToArray());
        }

        public static DialogResult Show(out Information information)
        {
            var frm = new frmGetInformation();

            var result =  frm.ShowDialog();

            information = result != DialogResult.OK ? default(Information) : new Information(frm.txtInformation.Text, (InformationType) frm.cmbInformationType.SelectedItem);

            return result;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInformation.Text) || cmbInformationType.SelectedItem == null)
            {
                MessageBox.Show("Insert the required informations", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
