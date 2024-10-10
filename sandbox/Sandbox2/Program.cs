using System;
using System.Text;
// namespace Sandbox2;
// Caesar Cypher Encryption
class Program
{
    static void Main(string[] args)
    {
        string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890 !?.,$()-+='";
        int key = 0;
        bool loop = true;
        bool isValidKey;
        do
        {
            Console.Write("\nDo you want to 1. encrypt or 2. decrypt? ");
            string? userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Please enter the message to encrypt:");
                    string? plainMessage = Console.ReadLine();
                    do
                    {
                        Console.Write("Please enter the encryption key: ");
                        string? keyInput = Console.ReadLine();
                        isValidKey = int.TryParse(keyInput, out int result);
                        if (isValidKey)
                        {
                            key = result;
                        }
                        else
                        {
                            Console.WriteLine("Invalid key. Please try again");
                        }
                    } while (isValidKey is not true);

                    Console.WriteLine($"{encrypt(plainMessage, key, symbols)}");
                    loop = false;
                    break;
                case "2":
                Console.WriteLine("Please enter the message to decrypt:");
                    string? encryptedMessage = Console.ReadLine();
                    do
                    {
                        Console.Write("Please enter the encryption key: ");
                        string? keyInput = Console.ReadLine();
                        isValidKey = int.TryParse(keyInput, out int result);
                        if (isValidKey)
                        {
                            key = result;
                        }
                        else
                        {
                            Console.WriteLine("Invalid key. Please try again");
                        }
                    } while (isValidKey is not true);

                    Console.WriteLine($"{decrypt(encryptedMessage, key, symbols)}");
                    loop = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again");
                    break;
            }
        } while (loop);
    }

    static int intCheck(string userInput)
    {
        int.TryParse(userInput, out int result);
        
        return result;
    }

    static string encrypt(string? plainMessage, int key, string symbols)
    {
        StringBuilder sb = new StringBuilder();
        string encryptedMessage;
        foreach (char symbol in plainMessage ?? "")
        {
            if (symbols.Contains(symbol))
            {
                int symbolIndex = symbols.IndexOf(symbol);
                int translatedIndex = symbolIndex + key;
                // Handle wraparound
                while (translatedIndex >= symbols.Length)
                {
                    translatedIndex -= symbols.Length;
                }

                sb.Append(symbols[translatedIndex]);
            }
            else
            {
                sb.Append(symbol);
            }
        }
        encryptedMessage = sb.ToString();
        return encryptedMessage;
    }

    static string decrypt(string? encryptedMessage, int key, string symbols)
    {
        StringBuilder sb = new StringBuilder();
        string decryptedMessage;
        foreach (char symbol in encryptedMessage ?? "")
        {
            if (symbols.Contains(symbol))
            {
                int symbolIndex = symbols.IndexOf(symbol);
                int translatedIndex = symbolIndex - key;
                // Handle wraparound
                while (translatedIndex < 0)
                {
                    translatedIndex += symbols.Length;
                }

                sb.Append(symbols[translatedIndex]);
            }
            else
            {
                sb.Append(symbol);
            }
        }
        decryptedMessage = sb.ToString();
        return decryptedMessage;
    }
}
