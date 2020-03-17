using System;
using System.Windows.Forms;

namespace RegexBuilder.UI
{
    public partial class frmGetWrongSentence : Form
    {
        private frmGetWrongSentence()
        {
            InitializeComponent();
        }


        public static DialogResult Show(out string sentence)
        {
            var frm = new frmGetWrongSentence();

            var result = frm.ShowDialog();

            sentence = frm.txtSentence.Text;

            return result;
        }

    }
}
