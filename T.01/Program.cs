using System;

namespace T._01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Complete")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Make")
                {
                    string letterCase = cmdArgs[1];
                    int index = int.Parse(cmdArgs[2]);

                    if (letterCase == "Upper")
                    {
                        char letter = password[index];
                        password = password.Remove(index, 1);
                        password = password.Insert(index, letter.ToString().ToUpper());
                    }
                    else if (letterCase == "Lower")
                    {
                        char letter = password[index];
                        password = password.Remove(index, 1);
                        password = password.Insert(index, letter.ToString().ToLower());
                    }

                    Console.WriteLine(password);
                }
                else if (action == "Insert")
                {
                    int insertIndex = int.Parse(cmdArgs[1]);
                    char ch = char.Parse(cmdArgs[2]);

                    // -1
                    // 2
                    if (!(insertIndex >= password.Length || insertIndex < 0))
                    {
                        password = password.Insert(insertIndex, ch.ToString());
                        Console.WriteLine(password);
                    }
                }
                else if (action == "Replace")
                {
                    char charToReplace = char.Parse(cmdArgs[1]);
                    int value = int.Parse(cmdArgs[2]);

                    if (password.Contains(charToReplace))
                    {
                        char newChar = (char)(charToReplace + value);
                        password = password.Replace(charToReplace, newChar);

                        Console.WriteLine(password);
                    }
                }
                else if (action == "Validation")
                {
                    if (password.Length < 8)
                    {
                        Console.WriteLine("Password must be at least 8 characters long!");
                    }

                    bool hasOnlyValidSymbols = true;
                    bool hasUppercase = false;
                    bool hasLowercase = false;
                    bool hasDigit = false;

                    for (int i = 0; i < password.Length; i++)
                    {
                        char currChar = password[i];

                        // *
                        if (!(Char.IsLetterOrDigit(currChar) || currChar == '_'))
                        {
                            hasOnlyValidSymbols = false;
                        }

                        if (Char.IsUpper(currChar))
                        {
                            hasUppercase = true;
                        }

                        if (Char.IsLower(currChar))
                        {
                            hasLowercase = true;
                        }

                        if (Char.IsDigit(currChar))
                        {
                            hasDigit = true;
                        }
                    }

                    if (!hasOnlyValidSymbols)
                    {
                        Console.WriteLine("Password must consist only of letters, digits and _!");
                    }

                    if (!hasUppercase)
                    {
                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }

                    if (!hasLowercase)
                    {
                        Console.WriteLine("Password must consist at least one lowercase letter!");
                    }

                    if (!hasDigit)
                    {
                        Console.WriteLine("Password must consist at least one digit!");
                    }
                }
            }
        }
    }
}
