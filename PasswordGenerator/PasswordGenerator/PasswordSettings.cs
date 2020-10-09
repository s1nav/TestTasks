using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
    public class PasswordSettings : IPasswordSettings
    {

        private const string LowercaseCharacters = "abcdefghijkmnpqrstuvwxyz";
        private const string AmbiguouseLowercase = "lo";
        private const string UppercaseCharacters = "ABCDEFGHJKLMNPQRSTUVWXYZ";
        private const string AmbiguouseUppercase = "IO";
        private const string NumericCharacters = "23456789";
        private const string AmbiguouseNumeric = "01";
        private const string SymbolCharacters = @"!#$%&*@\";

        public bool IncludeLowercase { get; set; }
        public bool IncludeUppercase { get; set; }
        public bool IncludeNumeric { get; set; }
        public bool IncludeSymbols { get; set; }
        public bool AvoidAmbiguous { get; set; }
        public int PasswordLength { get; set; }
        public string CharacterSet { get; set; }
        public string Symbols { get; set; }

        public PasswordSettings(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSymbols,
            bool avoidAmbiguous, int passwordLenght)
        {
            IncludeLowercase = includeLowercase;
            IncludeUppercase = includeUppercase;
            IncludeNumeric = includeNumeric;
            IncludeSymbols = includeSymbols;
            AvoidAmbiguous = avoidAmbiguous;
            PasswordLength = passwordLenght;

            Symbols = SymbolCharacters;

            CharacterSet = BuildCharacterSet(includeLowercase, includeUppercase, includeNumeric, includeSymbols, avoidAmbiguous);
        }

        private string BuildCharacterSet(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSymbols, bool avoidAmbiguous)
        {
            var characterSet = new StringBuilder();

            if (includeLowercase)
            {
                characterSet.Append(LowercaseCharacters);
                if (!avoidAmbiguous)
                    characterSet.Append(AmbiguouseLowercase);
            }                

            if (includeUppercase)
            {
                characterSet.Append(UppercaseCharacters);
                if (!avoidAmbiguous)
                    characterSet.Append(AmbiguouseUppercase);
            }

            if (includeNumeric)
            {
                characterSet.Append(NumericCharacters);
                if (!avoidAmbiguous)
                    characterSet.Append(AmbiguouseNumeric);
            }

            if (includeSymbols)
                characterSet.Append(SymbolCharacters);

            return characterSet.ToString();
        }
    }
}
