using System;

namespace RegexBuilder.Engine
{
    public class Sentence
    {
        public string Text { get; set; }
        public SentenceInformationCollection Informations { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public string GetInformationText(Information information)
        {
            SentenceInformation sentenceInformation;
            if (!Informations.TryGetItem(information, out sentenceInformation))
                return null;

            if (Text.Length <= sentenceInformation.Start)
                return null;

            if (Text.Length <= sentenceInformation.Start + sentenceInformation.Length)
                return Text.Substring(sentenceInformation.Start, Text.Length - sentenceInformation.Start);
            else
                return Text.Substring(sentenceInformation.Start, sentenceInformation.Length);
        }

        public string GetInformationPrefixText(Information information, int prefixLength, int minimumPosition = 0)
        {
            var sentenceInformation = Informations[information];
            var prefixStart = Math.Max(minimumPosition, sentenceInformation.Start - prefixLength);
            var realPrefixLength = sentenceInformation.Start - prefixStart;
            return Text.Substring(prefixStart, realPrefixLength);
        }

        public string GetInformationSuffixText(Information information, int suffixLength, int maximumPosition = int.MaxValue)
        {
            var sentenceInformation = Informations[information];
            int suffixEnd = Math.Min(Math.Min(maximumPosition, sentenceInformation.End + suffixLength), Text.Length);
            var realSuffixLength = suffixEnd - sentenceInformation.End;
            if (realSuffixLength < 1)
                return string.Empty;
            return Text.Substring(sentenceInformation.End, realSuffixLength);
        }
    }
}
