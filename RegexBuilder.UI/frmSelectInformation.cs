using System;
using System.Collections;
using System.Windows.Forms;

namespace RegexBuilder.UI
{
    public partial class frmSelectInformation : Form
    {
        private frmSelectInformation()
        {
            InitializeComponent();
        }

        public static DialogResult Show(IEnumerable informations, out object information)
        {
            var frm = new frmSelectInformation();

            foreach (object i in informations)
            {
                frm.combo.Items.Add(i);
            }

            var result =  frm.ShowDialog();

            information = frm.combo.SelectedItem;

            return result;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (combo.SelectedIndex < 0)
            {
                MessageBox.Show("Select an item", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
