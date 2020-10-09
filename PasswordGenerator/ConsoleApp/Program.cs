using System;
using System.Security.Cryptography;
using PasswordGenerator;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                var pwd = new Password(17);
                //Console.WriteLine(pwd.NextGroup(20));
                foreach (var p in pwd.NextGroup(20))
                {
                    Console.WriteLine(p);
                }
                Console.ReadLine();
            }


        }
    }
}
