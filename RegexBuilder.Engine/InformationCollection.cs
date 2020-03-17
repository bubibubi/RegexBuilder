using System;
using System.Collections.Generic;

namespace RegexBuilder.Engine
{
    public class InformationCollection : List<Information>
    {
        public InformationCollection() { }
        public InformationCollection(IEnumerable<Information> collection) : base(collection)
        {
        }
    }
}
