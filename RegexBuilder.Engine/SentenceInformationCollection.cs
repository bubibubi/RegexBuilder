using System;
using System.Collections.Generic;

namespace RegexBuilder.Engine
{
    public class SentenceInformationCollection : List<SentenceInformation>
    {
        public SentenceInformationCollection() { }

        public SentenceInformationCollection(IEnumerable<SentenceInformation> collection) : base(collection)
        {
        }

        public SentenceInformation this[Information information]
        {
            get
            {
                SentenceInformation sentenceInformation;
                if (TryGetItem(information, out sentenceInformation))
                    return sentenceInformation;
                else
                    throw new ArgumentOutOfRangeException("information");
            }
        }

        public bool TryGetItem(Information information, out SentenceInformation sentenceInformation)
        {
            foreach (SentenceInformation s in this)
            {
                if (s.Information == information)
                {
                    sentenceInformation = s;
                    return true;
                }
            }

            sentenceInformation = default(SentenceInformation);
            return false;
        }
    }
}