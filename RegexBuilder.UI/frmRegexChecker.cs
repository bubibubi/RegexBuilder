using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegexBuilder.UI
{
    public partial class frmRegexChecker : Form
    {
        private frmRegexChecker()
        {
            InitializeComponent();
        }

        public static void Show(string regex = null, string sentence = null)
        {
            var frm = new frmRegexChecker();
            frm.txtRegex.Text = regex;
            frm.txtSentence.Text = sentence;

            frm.ShowDialog();
        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegex.Text))
            {
                MessageBox.Show("Insert the regular expression", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSentence.Text))
            {
                MessageBox.Show("Insert the sentence", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            Regex regex = new Regex(txtRegex.Text, RegexOptions.IgnoreCase);
            var match = regex.Match(txtSentence.Text);

            lstGroups.Items.Clear();

            lstGroups.Items.Add(string.Format("Success: {0}", match.Success));

            if (!match.Success)
                return;

            foreach (string groupName in regex.GetGroupNames())
            {
                CheckedInformation checkedInfo = new CheckedInformation(groupName, match.Groups[groupName].Index, match.Groups[groupName].Length);
                lstGroups.Items.Add(checkedInfo);
            }
        }

        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedInformation checkedInfo = lstGroups.SelectedItem as CheckedInformation;
            if (checkedInfo == null)
                return;

            if (txtSentence.Text.Length > checkedInfo.Start)
                txtSentence.SelectionStart = checkedInfo.Start;

            if (txtSentence.Text.Length > checkedInfo.Start + checkedInfo.Length)
                txtSentence.SelectionLength = checkedInfo.Length;
            else
                txtSentence.SelectionLength = txtSentence.Text.Length - txtSentence.SelectionStart;
        }

        class CheckedInformation
        {
            public string GroupName { get; private set; }
            public int Start { get; private set; }
            public int Length { get; private set; }

            public CheckedInformation(string groupName, int start, int length)
            {
                GroupName = groupName;
                Start = start;
                Length = length;
            }

            public override string ToString()
            {
                return string.Format("{0} ({1}, {2})", GroupName, Start, Length);
            }
        }
    }

}
