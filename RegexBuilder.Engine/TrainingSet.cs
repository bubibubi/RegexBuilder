using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexBuilder.Engine
{
    public class TrainingSet
    {
        public InformationCollection Informations { get; set; }
        public SentenceCollection Sentences { get; set; }
        public List<string> WrongSentences { get; set; }

        public string GetRegex()
        {
            string regexText;


            regexText = GetRegex_Simple();
            if (!TestRegexAll(regexText, Sentences.Select(_ => _.Text)))
                throw new InvalidOperationException("Cannot match information types");
            if (!TestRegexAny(regexText, WrongSentences))
                return regexText;

            for (int prefixSuffixLength = 1; prefixSuffixLength < 10; prefixSuffixLength++)
            {
                regexText = GetRegex(prefixSuffixLength);
                if (TestRegexAny(regexText, WrongSentences))
                    continue;

                if (TestAllGroups(regexText))
                    break;
            }

            if (!TestRegexAll(regexText, Sentences.Select(_ => _.Text)))
                throw new InvalidOperationException("Cannot match information types");

            return regexText;
        }

        private bool TestAllGroups(string regexText)
        {
            Regex regex = new Regex(regexText, RegexOptions.IgnoreCase);
            bool all = true;
            object lockObject = new object();
            Parallel.ForEach(Sentences, _ =>
            {
                if (all)
                {
                    var match = regex.Match(_.Text);
                    if (!match.Success)
                    {
                        lock (lockObject)
                            all = false;
                    }

                    foreach (var information in _.Informations)
                    {
                        if (_.GetInformationText(information.Information) != match.Groups[information.Information.Name].Value)
                        {
                            lock (lockObject)
                                all = false;
                            break;
                        }
                    }
                }
            });
            return all;
        }

        public int TestRegex(string regexText, IEnumerable<string> texts)
        {
            Regex regex = new Regex(regexText, RegexOptions.IgnoreCase);
            int count = 0;
            object lockObject = new object();
            Parallel.ForEach(texts, _ =>
            {
                bool success = regex.Match(_).Success;
                if (success)
                {
                    lock (lockObject)
                        count++;
                }
            });
            return count;
        }

        private bool TestRegexAll(string regexText, IEnumerable<string> texts)
        {
            Regex regex = new Regex(regexText, RegexOptions.IgnoreCase);
            bool all = true;
            object lockObject = new object();
            Parallel.ForEach(texts, _ =>
            {
                if (all)
                {
                    bool success = regex.Match(_).Success;
                    if (!success)
                    {
                        lock (lockObject)
                            all = false;
                    }
                }
            });
            return all;
        }

        private bool TestRegexAny(string regexText, IEnumerable<string> texts)
        {
            Regex regex = new Regex(regexText, RegexOptions.IgnoreCase);
            bool none = true;
            object lockObject = new object();
            Parallel.ForEach(texts, _ =>
            {
                if (none)
                {
                    bool success = regex.Match(_).Success;
                    if (success)
                    {
                        lock (lockObject)
                            none = false;
                    }
                }
            });
            return !none;
        }


        private string GetRegex_Simple()
        {
            List<Information> informationsInSentences = CheckAndGetInformationInSentences();

            string regex = ".*";
            foreach (Information informationsInSentence in informationsInSentences)
            {
                regex += InformationTypePattern.GetPattern(informationsInSentence.Type) + ".*";
            }

            return regex;
        }

        private string GetRegex(int length)
        {
            List<Information> informationsInSentences = CheckAndGetInformationInSentences();

            string regex = ".*";
            int[] lastPosition = new int[Sentences.Count];
            for (int informationIndex = 0; informationIndex < informationsInSentences.Count; informationIndex++)
            {
                Information information = informationsInSentences[informationIndex];
                Information nextInformation = informationIndex < informationsInSentences.Count - 1 ? informationsInSentences[informationIndex + 1] : null;

                // Compute the effective length avoiding overlapping.
                // In case of overlap the suffix wins
                PatternBuilder prefixPatternBuilder = new PatternBuilder() { Reverse = true };
                PatternBuilder suffixPatternBuilder = new PatternBuilder() { Reverse = false };
                for (int sentenceIndex = 0; sentenceIndex < Sentences.Count; sentenceIndex++)
                {
                    Sentence sentence = Sentences[sentenceIndex];

                    string prefix = sentence.GetInformationPrefixText(information, length, lastPosition[sentenceIndex]);
                    prefixPatternBuilder.Samples.Add(prefix);

                    string suffix = sentence.GetInformationSuffixText(information, length, nextInformation == null ? sentence.Text.Length : sentence.Informations[nextInformation].Start - length);
                    suffixPatternBuilder.Samples.Add(suffix);

                    lastPosition[sentenceIndex] = sentence.Informations[information].End + suffix.Length;
                }

                int min = Sentences.Select(_ => _.Informations[information]).Min(_ => _.Length);
                int max = Sentences.Select(_ => _.Informations[information]).Max(_ => _.Length);
                regex += prefixPatternBuilder.GetRegex() + information.GetPattern(min, max) + suffixPatternBuilder.GetRegex() + ".*";

            }

            return regex;
        }

        private List<Information> CheckAndGetInformationInSentences()
        {
            if (Sentences == null || Sentences.Count == 0)
                throw new InvalidOperationException("No sentences to match");

            List<Information> informationsInSentences = Sentences[0].Informations.OrderBy(_ => _.Start).Select(_ => _.Information).ToList();

            foreach (Sentence sentence in Sentences)
            {
                var informations = sentence.Informations.OrderBy(_ => _.Start).Select(_ => _.Information).ToList();
                if (!informationsInSentences.SequenceEqual(informations))
                    throw new InvalidOperationException("Informations on sentences are different or in different order");
            }

            return informationsInSentences;
        }
    }

    internal class PatternBuilder
    {
        public PatternBuilder()
        {
            Samples = new List<string>();
        }

        public List<string> Samples { get; set; }

        public bool Reverse { get; set; }

        public string GetRegex()
        {
            if (Reverse)
                return GetRegex_Reverse();
            else
                return GetRegex_Direct();
        }

        private string GetRegex_Direct()
        {
            const char character = '\0';
            const char number = '\x01';

            int minCharCount = Samples.Min(_ => _.Length);

            StringBuilder pattern = new StringBuilder();

            for (int i = 0; i < minCharCount; i++)
            {
                foreach (string sample in Samples)
                {
                    if (pattern.Length < i + 1)
                    {
                        pattern.Append(sample[i]);
                    }
                    else if (pattern[i] == sample[i])
                    {
                        // Same char as before
                    }
                    else if ((char.IsDigit(pattern[i]) || pattern[i] == number) && char.IsDigit(sample[i]))
                    {
                        pattern[i] = number;
                    }
                    else
                    {
                        pattern[i] = character;
                    }
                }
            }

            string regex = string.Empty;
            for (int i = 0; i < minCharCount; i++)
            {
                if (pattern[i] == number)
                    regex += "[0-9]";
                else if (pattern[i] == character)
                    regex += ".";
                else
                    regex += EscapeRegexChar(pattern[i]);
            }

            return regex;
        }

        private string GetRegex_Reverse()
        {
            const char character = '\0';
            const char number = '\x01';

            int minCharCount = Samples.Min(_ => _.Length);

            StringBuilder pattern = new StringBuilder();

            for (int i = 0; i < minCharCount; i++)
            {
                foreach (string sample in Samples)
                {
                    char charSample = sample[sample.Length - i - 1];
                    if (pattern.Length < i + 1)
                    {
                        pattern.Insert(0, charSample);
                    }
                    else if (pattern[0] == charSample)
                    {
                        // Same char as before
                    }
                    else if ((char.IsDigit(pattern[0]) || pattern[0] == number) && char.IsDigit(charSample))
                    {
                        pattern[0] = number;
                    }
                    else
                    {
                        pattern[0] = character;
                    }
                }
            }

            string regex = string.Empty;
            for (int i = 0; i < minCharCount; i++)
            {
                if (pattern[i] == number)
                    regex += "[0-9]";
                else if (pattern[i] == character)
                    regex += ".";
                else
                    regex += EscapeRegexChar(pattern[i]);
            }

            return regex;
        }



        private string EscapeRegexChar(char c)
        {
            if (".^$*+?()[{\\|".Contains('c'))
                return "\\" + c;
            else
                return c.ToString();
        }
    }
}
