using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegexBuilder.Engine;

namespace RegexBuilder.UI
{
    public partial class frmReport : Form
    {
        private frmReport()
        {
            InitializeComponent();
        }

        public static void Show(TrainingSet trainingSet, string regexText)
        {
            var frm = new frmReport();

            frm.txtRegex.Text = regexText;

            frm._regexText = regexText;
            frm._regex = new Regex(regexText, RegexOptions.IgnoreCase);
            frm._trainingSet = trainingSet;

            frm.Show();
        }

        private Regex _regex;
        private TrainingSet _trainingSet;
        private string _regexText;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtTrueTotal.Text = _trainingSet.Sentences.Count.ToString();
            txtFalseTotals.Text = _trainingSet.WrongSentences.Count.ToString();

            Task.Run(() =>
            {
                UpdateTruePositives();
            });

            Task.Run(() =>
            {
                UpdateFalsePositives();
            });


            foreach (Sentence sentence in _trainingSet.Sentences)
            {
                lstSentences.Items.Add(sentence);
            }
        }

        private void UpdateTruePositives()
        {
            int count = _trainingSet.TestRegex(_regexText, _trainingSet.Sentences.Select(_ => _.Text));
            MethodInvoker method = delegate { txtTruePositives.Text = count.ToString(); };
            if (txtTruePositives.InvokeRequired)
                txtTruePositives.Invoke(method);
            else
                method();
        }

        private void UpdateFalsePositives()
        {
            int count = _trainingSet.TestRegex(_regexText, _trainingSet.WrongSentences);
            MethodInvoker method = delegate { txtFalsePositives.Text = count.ToString(); };
            if (txtFalsePositives.InvokeRequired)
                txtFalsePositives.Invoke(method);
            else
                method();
        }

        private void lstSentences_SelectedIndexChanged(object sender, EventArgs e)
        {
            var match = _regex.Match(lstSentences.SelectedItem.ToString());
            lstVariables.Items.Clear();

            lstVariables.Items.Add(string.Format("Success = {0}", match.Success));
            foreach (string groupName in _regex.GetGroupNames())
            {
                lstVariables.Items.Add(string.Format("{0} = {1}", groupName, match.Groups[groupName].Value));
            }
        }
    }
}
