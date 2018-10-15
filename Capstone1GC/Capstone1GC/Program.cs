using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Capstone1GC
{
    class Program
    {
        static void Main()
        {
            Console.Write("Welcome to the Grand Circus Pig Latin Translator!\n\nPlease enter a word or phrase to be translated: ");
            string input = Console.ReadLine();
            Console.Write("\n");            
            string vowels = "AEIOUaeiou";
            int i = 0;
            string[] pigInput = input.Split(' ');

            if(Regex.IsMatch(input, @"^[ ]+$")) //calls the main method again to restart program if user enters only spaces. Every other input should have a case.
            {
                Console.WriteLine("Your entry cannnot be blank. Please try again. \n");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                Main();
            }

            foreach (string word in pigInput)
            {
                i = 0;
                
                while (i < word.Length)
                {
                    if (char.IsUpper(word[0]) && char.IsLower(word[1]))//checks to see if word is title case
                    {
                        string newword = word.ToLower();
                        if((Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+.$") && vowels.Contains(word[i]))) // checks to see if contraction and puncuated
                        {
                            Console.Write(char.ToUpper(newword[i]) + newword.Substring(i + 1, newword.Length - i - 2) + newword.Substring(0, i) + "ay" + newword[newword.Length - 1] + " ");
                            break;
                        }
                        else if ((Regex.IsMatch(word, @"^[a-zA-Z]+.$") && vowels.Contains(word[i]))) // checks for punctuation & not a contraction
                        {
                            Console.Write(char.ToUpper(newword[i]) + newword.Substring(i + 1, newword.Length - i - 2) + newword.Substring(0, i) + "ay" + newword[newword.Length - 1] + " ");
                            break;
                        }
                        else if (Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+$") && vowels.Contains(word[i])) //checking to see if contraction
                        {
                            Console.Write(char.ToUpper(newword[i]) + newword.Substring(i + 1, newword.Length - i - 1) + newword.Substring(0, i) + "ay ");
                            break;
                        }
                        else if (!Regex.IsMatch(newword, @"^[a-zA-Z]+$") && !Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+$") && !Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+.$") && !Regex.IsMatch(word, @"^[a-zA-Z]+.$")) //checking to see if alphanumerics but not a contraction
                        {
                            Console.Write(word + " ");
                            break;
                        }
                        else if (vowels.Contains(newword[0])) //returns word + way if beginning with a vowel
                        {
                            Console.Write(char.ToUpper(newword[0]) + newword.Substring(1, newword.Length - 1) + "way ");
                            break;
                        }
                        else if (vowels.Contains(newword[i])) //standard pig latin translation
                        {
                            Console.Write(char.ToUpper(newword[i]) + newword.Substring(i + 1, newword.Length - i - 1) + newword.Substring(0, i) + "ay ");
                            break;
                        }
                        else if (i == newword.Length - 1) //if does not match any cases with vowels, such as word "My"
                        {
                            Console.Write(char.ToUpper(newword[0]) + newword.Substring(1, newword.Length - 1) + "way ");
                            break;
                        }
                        i++;
                    }
                    else if (char.IsUpper(word[0]) && char.IsUpper(word[1]))// same tests if all are uppercase
                    {
                        string newword = word.ToUpper();
                        if ((Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+.$") && vowels.Contains(word[i]))) // checks to see if contraction and puncuated
                        {
                            Console.Write(char.ToUpper(newword[i]) + newword.Substring(i + 1, newword.Length - i - 2) + newword.Substring(0, i) + "AY" + newword[newword.Length - 1] + " ");
                            break;
                        }
                        else if ((Regex.IsMatch(word, @"^[a-zA-Z]+.$") && vowels.Contains(word[i]))) // checks for punctuation & not a contraction
                        {
                            Console.Write(char.ToUpper(newword[i]) + newword.Substring(i + 1, newword.Length - i - 2) + newword.Substring(0, i) + "AY" + newword[newword.Length - 1] + " ");
                            break;
                        }
                        else if (Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+$") && vowels.Contains(word[i])) //checking to see if contraction
                        {
                            Console.Write(char.ToUpper(newword[i]) + newword.Substring(i + 1, newword.Length - i - 1) + newword.Substring(0, i) + "AY ");
                            break;
                        }
                        else if (!Regex.IsMatch(newword, @"^[a-zA-Z]+$") && !Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+$") && !Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+.$") && !Regex.IsMatch(word, @"^[a-zA-Z]+.$")) //checking to see if alphanumerics but not a contraction and not punctuated
                        {
                            Console.Write(word + " ");
                            break;
                        }
                        else if (vowels.Contains(newword[0])) //returns word + way if beginning with a vowel
                        {
                            Console.Write(char.ToUpper(newword[0]) + newword.Substring(1, newword.Length - 1) + "WAY ");
                            break;
                        }
                        else if (vowels.Contains(newword[i])) //standard pig latin translation
                        {
                            Console.Write(char.ToUpper(newword[i]) + newword.Substring(i + 1, newword.Length - i - 1) + newword.Substring(0, i) + "WAY ");
                            break;
                        }
                        else if (i == newword.Length - 1) //if does not match any cases with vowels, such as word "My"
                        {
                            Console.Write(char.ToUpper(newword[0]) + newword.Substring(1, newword.Length - 1) + "WAY ");
                            break;
                        }
                        i++;
                    }
                    else // standard pig latin
                    {
                        if ((Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+.$") && vowels.Contains(word[i]))) // checks to see if contraction and puncuated
                        {
                            Console.Write(word.Substring(i, word.Length - i - 1) + word.Substring(0, i) + "ay" + word[word.Length - 1]);
                            break;
                        }
                        else if ((Regex.IsMatch(word, @"^[a-zA-Z]+.$") && vowels.Contains(word[i]))) // checks for punctuation & not a contraction
                        {
                            Console.Write(word.Substring(i, word.Length - i - 1) + word.Substring(0, i) + "ay" + word[word.Length - 1]);
                            break;
                        }
                        else if (Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+$") && vowels.Contains(word[i]))
                        {
                            Console.Write(word.Substring(i, word.Length - i) + word.Substring(0, i) + "ay ");
                            break;
                        }
                        else if (!Regex.IsMatch(word, @"^[a-zA-Z]+$") && !Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+$") && !Regex.IsMatch(word, @"^[a-zA-Z]+['][a-zA-Z]+.$") && !Regex.IsMatch(word, @"^[a-zA-Z]+.$"))
                        {
                            Console.Write(word + " ");
                            break;
                        }
                        else if (vowels.Contains(word[0]))
                        {
                            Console.Write(word + "way ");
                            break;
                        }
                        else if (vowels.Contains(word[i]))
                        {
                            Console.Write(word.Substring(i, word.Length - i) + word.Substring(0, i) + "ay ");
                            break;
                        }
                        else if (i == word.Length - 1)
                        {
                            Console.Write(word + "way ");
                            break;
                        }
                        i++;
                    }
                }
            }

            Console.WriteLine("\n\nTranslate another word/phrase? (enter \"y\" to continue or anything else to quit)"); //option to restart program
            if(Console.ReadLine() == "y")
            {
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                Main();
            }

        }
     
        // Some thoughts after writing this code -- could have broken out checks on certain criteria for the input strings into methods instead of having trees of if/else statements
    }

}
