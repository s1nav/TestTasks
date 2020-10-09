using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    public interface IPasswordSettings
    {
        bool IncludeLowercase { get; }
        bool IncludeUppercase { get; }
        bool IncludeNumeric { get; }
        bool IncludeSymbols { get; }
        bool AvoidAmbiguous { get; }
        int PasswordLength { get; set; }
        string CharacterSet { get; }
        string Symbols { get; }
    }
}
