using System;
using System.IO;
using System.Text;

namespace SystemIO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainMenu();
            
            //AddToFile(path, "TESTING");
            
        }

        public static void MainMenu()
        {
            string path = "../../../myWords.txt";
            CreateFile(path);

            while(true)
            {
                Console.WriteLine("Welcome to Hangman. Please select an option below:");
                Console.WriteLine("1. Play game with random word");
                Console.WriteLine("2. View/Edit words");
                Console.WriteLine("3. Exit");

                string selection = Console.ReadLine();

                if (selection == "1")
                    PlayGame(GetRandomWord());
                else if (selection == "2")
                {
                    string[] allWords = ReadFile(path);
                    Console.WriteLine("Here are the words currently in use:");
                    Console.WriteLine(string.Join("  ", allWords));

                    Console.WriteLine("1. Add a word");
                    Console.WriteLine("2. Delete a word");
                    Console.WriteLine("3. Delete all words!");
                    Console.WriteLine("4. Nevermind");

                    string submenu = Console.ReadLine();

                    if (submenu == "1")
                    {
                        Console.WriteLine("Type the word you want to add:");
                        string newWord = Console.ReadLine().ToUpper();
                        Console.WriteLine("New word is: " + newWord);
                    }

                    if (submenu == "4")
                        Console.WriteLine("Returning to Main Menu");
                }
                else if (selection == "3")
                    break;
            }

            Console.WriteLine("Thank you for playing!");
        }

        public static void PlayGame(string word)
        {
            string[] hiddenWord = TurnToHiddenWord(word);
            
            while (true)
            {
                string hiddenWordString = string.Join("  ", hiddenWord);
                Console.WriteLine(hiddenWordString);

                if (!hiddenWordString.Contains("_"))
                {
                    break;
                }

                Console.WriteLine("Guess a letter");
                
                string guess = Console.ReadLine().ToUpper();

                for (int i = 0; i < hiddenWord.Length; i++)
                {
                    if (word[i].ToString() == guess)
                    {
                        hiddenWord[i] = guess;
                    }
                }

            }

            Console.WriteLine("You win! Play again? Y/N:");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "Y")
                PlayGame(GetRandomWord());
        }

        public static string GetRandomWord()
        {
            string path = "../../../myWords.txt";
            CreateFile(path);

            string[] allWords = ReadFile(path);

            Random rnd = new Random();
            int randomNum = rnd.Next(allWords.Length);

            return allWords[randomNum];
        }

        public static string[] TurnToHiddenWord(string word)
        {
            string [] hiddenWord = new string[word.Length];


            for (int i = 0; i < hiddenWord.Length; i++)
            {
                hiddenWord[i] = "_";
            }

            return hiddenWord;
        }
        

        public static bool CreateFile(string path)
        {
            string[] wordsArray = new string[5];
            wordsArray[0] = "PUPPIES";
            wordsArray[1] = "LAPTOP";
            wordsArray[2] = "ORANGE";
            wordsArray[3] = "WATER";
            wordsArray[4] = "WHITEBOARD";
            
            try
            {
                File.WriteAllLines(path, wordsArray);
            }
            catch
            {
                throw;
            }

            return File.Exists(path);
        }

        public static bool DeleteAFile(string path)
        {
            File.Delete(path);
            return File.Exists(path);
        }

        public static string[] ReadFile(string path)
        {
            try
            {
                string[] myWords = File.ReadAllLines(path);
                return myWords;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddToFile(string path, string word)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(word);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
