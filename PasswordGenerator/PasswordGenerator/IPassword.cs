using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    interface IPassword
    {
        string Next();
        IEnumerable<string> NextGroup(int numberOfPasswords);
    }
}
