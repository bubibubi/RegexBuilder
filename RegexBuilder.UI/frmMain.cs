using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using System.Xml.Serialization;
using RegexBuilder.Engine;

namespace RegexBuilder.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IEnumerable<string> Sentences { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IEnumerable<string> WrongSentences { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IEnumerable<Information> Informations { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Sentences != null)
            {
                foreach (string sentence in Sentences)
                {
                    lstSimilarSentences.Items.Add(new Sentence {Text = sentence});
                }
            }

            if (WrongSentences != null)
            {
                foreach (string wrongSentence in WrongSentences)
                {
                    lstWrongSentences.Items.Add(wrongSentence);
                }
            }

            if (Informations != null)
            {
                foreach (Information information in Informations)
                {
                    lstInformations.Items.Add(information);
                }

                lstInformations.ButtonsEnabled = false;
            }

        }


        private void lstSimilarSentences_Add(object sender, EventArgs e)
        {
            Sentence sentence;
            if (frmGetSimilarSentence.Show(lstInformations.Items.Cast<Information>(), out sentence) != DialogResult.OK)
                return;

            lstSimilarSentences.Items.Add(sentence);
        }

        private void lstSimilarSentences_Edit(object sender, EventArgs e)
        {
            Sentence sentence = (Sentence)lstSimilarSentences.SelectedItem;
            frmGetSimilarSentence.Show(lstInformations.Items.Cast<Information>(), sentence);
        }

        private void lstSimilarSentences_Remove(object sender, EventArgs e)
        {
            lstSimilarSentences.Items.Remove(lstSimilarSentences.SelectedItem);
        }

        private void lstWrongSentences_Add(object sender, EventArgs e)
        {
            string sentence;
            if (frmGetWrongSentence.Show(out sentence) != DialogResult.OK)
                return;
            lstWrongSentences.Items.Add(sentence);
        }

        private void lstWrongSentences_Remove(object sender, EventArgs e)
        {
            lstWrongSentences.Items.Remove(lstWrongSentences.SelectedItem);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TrainingSet trainingSet = new TrainingSet()
            {
                Informations = new InformationCollection(lstInformations.Items.Cast<Information>().ToList()),
                Sentences = new SentenceCollection(lstSimilarSentences.Items.Cast<Sentence>()),
                WrongSentences = lstWrongSentences.Items.Cast<string>().ToList()
            };

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = ".trainingset",
                OverwritePrompt = true
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            using (var textWriter = new StreamWriter(saveFileDialog.FileName))
                new XmlSerializer(typeof(TrainingSet)).Serialize(textWriter, trainingSet);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                AddExtension = true,
                DefaultExt = ".trainingset"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            TrainingSet trainingSet;
            using (var textReader = new StreamReader(openFileDialog.FileName))
                trainingSet = (TrainingSet)new XmlSerializer(typeof(TrainingSet)).Deserialize(textReader);

            lstInformations.AddItems(trainingSet.Informations);
            lstSimilarSentences.AddItems(trainingSet.Sentences);
            lstWrongSentences.AddItems(trainingSet.WrongSentences);
        }

        private void lstInformations_Add(object sender, EventArgs e)
        {
            Information information;
            if (frmGetInformation.Show(out information) != DialogResult.OK)
                return;

            lstInformations.Items.Add(information);
        }

        private void lstInformations_Remove(object sender, EventArgs e)
        {
            lstInformations.Items.Remove(lstInformations.SelectedItem);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(text))
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            var lines = text.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                lstWrongSentences.Items.Add(line);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            TrainingSet trainingSet = new TrainingSet()
            {
                Informations = new InformationCollection(lstInformations.Items.Cast<Information>().ToList()),
                Sentences = new SentenceCollection(lstSimilarSentences.Items.Cast<Sentence>()),
                WrongSentences = lstWrongSentences.Items.Cast<string>().ToList()
            };

            string regex = trainingSet.GetRegex();

            frmReport.Show(trainingSet, regex);

        }


    }
}
