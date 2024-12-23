﻿using System;
using System.Text;
// namespace Sandbox2;
// Caesar Cypher Encryption
class Program
{
    static void Main(string[] args)
    {
        string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890 !?.,$#%^&*_:;`~(){}[]\\/-+='";
        int key = 0;
        bool loop = true;
        bool isValidKey;
        do
        {
            Console.Write("\n\nDo you want to 1. encrypt or 2. decrypt? ");
            string? userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("\nPlease enter the message to encrypt:");
                    string? plainMessage = Console.ReadLine();
                    do
                    {
                        Console.Write("\nPlease enter the encryption key: ");
                        string? keyInput = Console.ReadLine();
                        isValidKey = int.TryParse(keyInput, out int result);
                        if (isValidKey)
                        {
                            key = result;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid key. Please try again");
                        }
                    } while (isValidKey is not true);

                    Console.WriteLine($"\n{encrypt(plainMessage, key, symbols)}\n");
                    loop = false;
                    break;
                case "2":
                Console.WriteLine("\nPlease enter the message to decrypt:");
                    string? encryptedMessage = Console.ReadLine();
                    do
                    {
                        Console.Write("\nPlease enter the encryption key: ");
                        string? keyInput = Console.ReadLine();
                        isValidKey = int.TryParse(keyInput, out int result);
                        if (isValidKey)
                        {
                            key = result;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid key. Please try again");
                        }
                    } while (isValidKey is not true);

                    Console.WriteLine($"\n{decrypt(encryptedMessage, key, symbols)}\n");
                    loop = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid input. Please try again");
                    break;
            }
        } while (loop);
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