using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RegexBuilder.Engine;

namespace RegexBuilder.UI
{
    public partial class frmGetSimilarSentence : Form
    {
        private frmGetSimilarSentence()
        {
            InitializeComponent();
        }


        public static DialogResult Show(IEnumerable<Information> informations, out Sentence sentence)
        {
            var frm = new frmGetSimilarSentence();
            frm._informations = informations;

            var result = frm.ShowDialog();

            sentence = new Sentence()
            {
                Text = frm.txtSentence.Text,
                Informations = new SentenceInformationCollection(frm.ctlList.Items.Cast<SentenceInformation>())
            };

            return result;
        }

        public static DialogResult Show(IEnumerable<Information> informations, Sentence sentence)
        {
            var frm = new frmGetSimilarSentence();
            frm._informations = informations;

            frm.txtSentence.Text = sentence.Text;
            frm.ctlList.Items.AddRange(sentence.Informations.Select(_ => _.Clone()).Cast<object>().ToArray());

            var result = frm.ShowDialog();

            if (result != DialogResult.OK)
                return result;

            sentence.Text = frm.txtSentence.Text;
            sentence.Informations = new SentenceInformationCollection(frm.ctlList.Items.Cast<SentenceInformation>());

            return result;
        }


        private IEnumerable<Information> _informations;

        private void ctlList_Add(object sender, EventArgs e)
        {
            if (txtSentence.SelectionLength < 1)
            {
                MessageBox.Show("Select a part of the sentence", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            object o;
            if (frmSelectInformation.Show(_informations, out o) != DialogResult.OK)
            {
                return;
            }

            Information information = (Information) o;


            foreach (SentenceInformation sentenceInformation in ctlList.Items)
            {
                if (sentenceInformation.Information.Name.Equals(information.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("Information already set", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            ctlList.Items.Add(new SentenceInformation(information, txtSentence.SelectionStart, txtSentence.SelectionLength));
        }

        private void ctlList_Remove(object sender, EventArgs e)
        {
            ctlList.Items.Remove(ctlList.SelectedItem);
        }

        private void ctlList_SelectedItemChanged(object sender, EventArgs e)
        {
            SentenceInformation sentenceInformation = ctlList.SelectedItem as SentenceInformation;
            if (sentenceInformation == null)
                return;

            if (txtSentence.Text.Length > sentenceInformation.Start)
                txtSentence.SelectionStart = sentenceInformation.Start;

            if (txtSentence.Text.Length > sentenceInformation.Start + sentenceInformation.Length)
                txtSentence.SelectionLength = sentenceInformation.Length;
            else
                txtSentence.SelectionLength = txtSentence.Text.Length - txtSentence.SelectionStart;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSentence.Text))
            {
                MessageBox.Show("Insert a sentence", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
