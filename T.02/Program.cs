using System;
using System.Text;
using System.Text.RegularExpressions;

namespace T._02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(.+)\>(?<first>\d{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<last>[^<>]{3})\<\1";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match currMatch = Regex.Match(input, pattern);

                if (currMatch.Success)
                {
                    StringBuilder password = new StringBuilder();

                    password.Append(currMatch.Groups["first"].Value);
                    password.Append(currMatch.Groups["second"].Value);
                    password.Append(currMatch.Groups["third"].Value);
                    password.Append(currMatch.Groups["last"].Value);

                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
