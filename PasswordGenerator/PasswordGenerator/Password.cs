using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace PasswordGenerator
{
    public class Password : IPassword
    {
        private const bool DefaultIncludeLowercase = true;
        private const bool DefaultIncludeUppercase = true;
        private const bool DefaultIncludeNumeric = true;
        private const bool DefaultIncludeSymbols = true;
        private const bool DefaultAvoidAmbiguous = true;
        private const int DefaultPasswordLength = 15;
        private const int DefaultMaxAttempt = 10000;
        private static RandomNumberGenerator _rngcsp;

        public IPasswordSettings Settings { get; set; }

        public Password() :
            this(DefaultIncludeLowercase, DefaultIncludeUppercase, DefaultIncludeNumeric, DefaultIncludeSymbols, DefaultAvoidAmbiguous, DefaultPasswordLength)
        {

        }
        public Password(int length) :
            this(DefaultIncludeLowercase, DefaultIncludeUppercase, DefaultIncludeNumeric, DefaultIncludeSymbols, DefaultAvoidAmbiguous, length)
        {
            if (length < 4)
            {
                // TODO: define password length exception
                throw new Exception();
            }
        }
        public Password(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSymbols, int length) :
            this(includeLowercase, includeUppercase, includeNumeric, includeSymbols, DefaultAvoidAmbiguous, length)
        {

        }
        public Password(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSymbols, bool avoidAmbiguous, int length)
        {
            Settings = new PasswordSettings(includeLowercase, includeUppercase, includeNumeric, includeSymbols, avoidAmbiguous, length);
            _rngcsp = RandomNumberGenerator.Create();
        }
        public Password(IPasswordSettings passwordSettings)
        {
            Settings = passwordSettings;
            _rngcsp = RandomNumberGenerator.Create();
        }

        private string GeneratePassword(IPasswordSettings settings)
        {
            var password = new char[settings.PasswordLength];

            var shuffledCharacters = Shuffle(settings.CharacterSet);

            for (int position = 0; position < settings.PasswordLength; position++)
            {
                password[position] = shuffledCharacters.ToCharArray()[GetRandomNumber(shuffledCharacters.Length - 1)];
            }

            return new string(password);
        }

        private int GetRandomNumber(int max)
        {
            var data = new byte[sizeof(int)];
            _rngcsp.GetBytes(data);
            var randomInt = BitConverter.ToInt32(data, 0);
            return Math.Abs(randomInt % max);
        }

        private string Shuffle(string characterSet)
        {
            var characterArray = characterSet.ToCharArray();
            var numArray = new byte[characterSet.Length];
            _rngcsp.GetBytes(numArray);
            Array.Sort(numArray, characterArray);
            return new string(characterArray);
        }

        private bool IsPasswordValid(string password)
        {
            const int maxIdenticalConsecutive = 2;
            const string lowerCaseRegex = @"[a-z]";
            const string upperCaseRegex = @"[A-Z]";
            const string numericRegex = @"\d";
            var maxIdenticalConsecutiveRegex = @"(.)\1{" + maxIdenticalConsecutive.ToString() + ",}";

            var lowerCaseMatch = !Settings.IncludeLowercase || Settings.IncludeLowercase && Regex.IsMatch(password, lowerCaseRegex);
            var upperCaseMatch = !Settings.IncludeUppercase || Settings.IncludeUppercase && Regex.IsMatch(password, upperCaseRegex);
            var numericMatch = !Settings.IncludeNumeric || Settings.IncludeNumeric && Regex.IsMatch(password, numericRegex);
            var symbolsMatch = !Settings.IncludeSymbols || Settings.IncludeSymbols && password.ToCharArray().Any(c => Settings.Symbols.ToCharArray().Contains(c));
            var identicalConsecutiveMatch = !Regex.IsMatch(password, maxIdenticalConsecutiveRegex);

            return lowerCaseMatch && upperCaseMatch && numericMatch && symbolsMatch && identicalConsecutiveMatch;
        }

        public string Next()
        {
            string password;
            int currentAttempt = 0;
            do
            {
                password = GeneratePassword(Settings);
                currentAttempt++;
                //Console.WriteLine($"Current attempt: {currentAttempt} - {password}");
            } while (!IsPasswordValid(password) && currentAttempt <= DefaultMaxAttempt);

            if (currentAttempt == DefaultMaxAttempt)
                // TODO: cannot generate password
                throw new Exception();
            else
                return password;
        }

        public IEnumerable<string> NextGroup(int numberOfPasswords)
        {
            var passwords = new List<string>();

            for (int i = 0; i < numberOfPasswords; i++)
            {
                passwords.Add(this.Next());
            }

            return passwords;
        }
    }
}
