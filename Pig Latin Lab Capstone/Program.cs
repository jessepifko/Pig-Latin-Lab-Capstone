using System;
using System.Text.RegularExpressions;

namespace Pig_Latin_Practice
{
    class Program
    {

        /* 3 Cases. 
         * 1. Vowel = +way
         * 2. Consnants = +ay
         * 3. A word with All consonants/ignore */

        static void Main(string[] args)
        {

            //Displays welcome prompt and asks for input
            Console.WriteLine("Welcome to our Pig Latin Translator");

            do
            {
                Console.WriteLine("Please enter a word to be translated: ");
                //Grabs input from the user and stores it in the string, input
                string input = Console.ReadLine().ToLower().Trim();
                
                //Checks if input contais only letters and spaces.
                if (Regex.IsMatch(input, @"^[a-zA-Z , ', .]+$"))
                {
                    Console.WriteLine($"{input} is a valid response");
                }
                else
                {
                    Console.WriteLine($"{input} is not a valid response");
                    continue; 
                }

               
                string[] words = input.Split();

                foreach (string word in words)
                {
                    TranslateWord(word);
                }

                Console.WriteLine("Done!");

            } while (LoopAgain("\n Translate another word? (y to continue)", "y"));
        }

        //public static bool CheckAlphabetic(String input)
        //{
        //    for (int i = 0; i != input.Length(); ++i)
        //    {
        //        if (!Character.isLetter(input.charAt(i)))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}
        public static void TranslateWord(string input)
        {
            char[] word = input.ToCharArray();
            string output = "";
            int firstVowelIndex = FindFirstVowel(word);

            if (firstVowelIndex == 0)
            {
                output = input + "way";
            }
            else if (firstVowelIndex == -1)
            {
                output = input;
            }
            else
            {
                string prefix = input.Substring(firstVowelIndex);
                string postfix = input.Substring(0, firstVowelIndex) + "ay";
                output = prefix + postfix;
            }

            // Console.WriteLine(FindFirstVowel(word));

            Console.WriteLine("Translation: " + output); ;
        }

        public static int FindFirstVowel(char[] word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                if (isVowel(letter))
                {
                    return i;
                }
            }
            Console.WriteLine("No vowels found in " + word);
            return -1;
        }

        public static bool isVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char vowel in vowels)
            {
                if (vowel == c)
                {
                    return true;
                }
            }

            return false;
        }
        // LOOPS EVERYTHING To SEE IF USER WANTS TO TRY AGAIN

        public static bool LoopAgain(string sentenence, string cont)
        {
            Console.Write(sentenence);
            string response = Console.ReadLine().Trim();
            if (response == cont)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

