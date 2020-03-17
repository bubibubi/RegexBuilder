using System.Collections.Generic;

namespace RegexBuilder.Engine
{
    public class SentenceCollection : List<Sentence>
    {
        public SentenceCollection() {}

        public SentenceCollection(IEnumerable<Sentence> sentences) : base(sentences)
        {
        }
    }
}