using System;
using System.Collections.Generic;

namespace RegexBuilder.Engine
{
    public static class InformationTypePattern
    {
        static readonly Dictionary<InformationType, string> _informationTypes = new Dictionary<InformationType, string>()
        {
            {InformationType.Unknown, "." },
            {InformationType.All, "." },
            {InformationType.Character, "[A-Z]" },
            {InformationType.Numeric, "[0-9]" },
            {InformationType.Alfanumeric, "[0-9A-Z]" },
            {InformationType.Date, @"[0-9]{1,4}[\s\./-]{1}[0-9]{1,4}[\s\./-]{1}[0-9]{1,4}" },
            {InformationType.Time2, @"[0-9]{1,2}[\s\.-:]{1}[0-9]{1,2}" },
            {InformationType.Time3, @"[0-9]{1,2}[\s\.-:]{1}[0-9]{1,2}[\s\.-:]{1}[0-9]{1,2}" }
        };

        public static string GetPattern(InformationType informationType)
        {
            return _informationTypes[informationType];
        }

        public static string GetPattern(InformationType informationType, int min, int max)
        {
            if (!RequireQuantifier(informationType))
                return GetPattern(informationType);

            if (min == max)
                return string.Format("{0}{{{1}}}", _informationTypes[informationType], min);
            else
                return string.Format("{0}{{{1},{2}}}", _informationTypes[informationType], min, max);

        }

        private static bool RequireQuantifier(InformationType informationType)
        {
            switch (informationType)
            {
                case InformationType.Date:
                case InformationType.Time2:
                case InformationType.Time3:
                    return false;
                default:
                    return true;
            }
        }
    }
}
