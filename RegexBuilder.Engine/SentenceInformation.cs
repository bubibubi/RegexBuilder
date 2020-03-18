using System;

namespace RegexBuilder.Engine
{
    public class SentenceInformation : ICloneable
    {
        public SentenceInformation() { }

        public SentenceInformation(Information information, int start, int length)
        {
            Information = information;
            Start = start;
            Length = length;
        }

        public Information Information { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }

        public int End
        {
            get { return Start + Length; }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}, {2})", Information, Start, Length);
        }

        #region ICloneable implementation

        public SentenceInformation Clone()
        {
            return new SentenceInformation(Information, Start, Length);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion
    }
}