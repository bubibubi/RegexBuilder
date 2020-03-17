using System.Xml.Serialization;

namespace RegexBuilder.Engine
{
    public class Information
    {
        public Information() { }

        public Information(string name, InformationType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }

        public InformationType Type { get; set; }

        public string GetPattern(int min, int max)
        {
            return string.Format("(?<{0}>{1})", Name, InformationTypePattern.GetPattern(Type, min, max));
        }


        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Type);
        }


        protected bool Equals(Information other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Information)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(Information left, Information right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Information left, Information right)
        {
            return !Equals(left, right);
        }

    }
}