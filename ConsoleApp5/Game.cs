using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class Game
    {
        public void Greet()
        {
            Console.WriteLine("====================");
            Console.WriteLine("Welcome to SPACEMAN!");
            Console.WriteLine("====================");
            Console.WriteLine("\nInstructions: Guess the word correctly before you get abducted by a UFO! You have 5 incorrect guesses to work with. Good luck!\n");
        }

        public string codeword;
        string currentWord;
        int maxGuesses;
        int numWrongGuesses;
        static string[] options = { "acrobat", "pelican", "jupiter", "galaxy", "celestial" };
        string guessedLetters = "";


        Ufo u = new Ufo();

        static Random rand = new Random();

        static int optionsIndex = rand.Next(options.Length);
        public Game()
        {
            codeword = options[optionsIndex];
            maxGuesses = 5;
            numWrongGuesses = 0;
            foreach (char a in codeword)
            {
                currentWord += "_";
            }
        }

        public bool DidWin()
        {
            if (codeword.Equals(currentWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DidLose()
        {
            if (numWrongGuesses >= maxGuesses)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
        public void Display()
        {
            Console.WriteLine(u.Stringify());
            Console.WriteLine($"Current word: {currentWord}");
            Console.WriteLine($"Incorrect guesses remaining: {maxGuesses - numWrongGuesses}");
            Console.WriteLine($"Letters already guessed: {guessedLetters}");
        }

        public void Ask()
        {
            Console.Write("Guess a letter: ");
            string guess = Console.ReadLine();
            if (guess.Length > 1)
            {

                Console.WriteLine("\n==================================================="); 
                Console.WriteLine("Guess one letter at a time!");
                
            }

            else if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("\n===================================================");
                Console.WriteLine("You already guessed that letter! Guess again!");
            }
           
            else if (codeword.Contains(guess))
            {
                Console.WriteLine("\n===================================================");
                Console.WriteLine("\nYou guessed correctly!");
                int index1 = codeword.IndexOf(guess);
                int index2 = codeword.LastIndexOf(guess);
                currentWord = currentWord.Remove(index1, 1);
                currentWord = currentWord.Insert(index1, guess);
                currentWord = currentWord.Remove(index2, 1);
                currentWord = currentWord.Insert(index2, guess);
                guessedLetters += $"{guess}, ";
                
            }
            else
            {
                Console.WriteLine("\n===================================================");
                Console.WriteLine("\nIncorrect guess.");
                numWrongGuesses++;
                u.AddPart();
                guessedLetters += $"{guess}, ";

            }
        }
    }
}
