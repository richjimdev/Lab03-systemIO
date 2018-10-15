using System;
using System.IO;
using System.Text;

namespace SystemIO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                MainMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please restart your console.");
            }
        }

        /// <summary>
        /// Method to handle main navigation of the game options.
        /// </summary>
        public static void MainMenu()
        {
            string path = "../../../myWords.txt";

            string[] defaultWords = new string[5];
            defaultWords[0] = "PUPPIES";
            defaultWords[1] = "LAPTOP";
            defaultWords[2] = "ORANGE";
            defaultWords[3] = "WATER";
            defaultWords[4] = "WHITEBOARD";

            CreateFile(path, defaultWords);

            string[] allWords = ReadFile(path);

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
                    while (true)
                    {
                        allWords = ReadFile(path);
                        Console.WriteLine("Here are the words currently in use:");
                        Console.WriteLine(string.Join("  ", allWords));

                        Console.WriteLine("1. Add a word");
                        Console.WriteLine("2. Delete a word");
                        Console.WriteLine("3. Back to Main Menu");

                        string submenu = Console.ReadLine();

                        if (submenu == "1")
                        {
                            Console.WriteLine("Type the word you want to add:");
                            string newWord = Console.ReadLine().ToUpper();
                            AddToFile(path, newWord);

                            Console.WriteLine("Added new word: " + newWord);
                        }
                        else if (submenu == "2")
                        {
                            Console.WriteLine("Type the full word you want to delete:");
                            string deleteWord = Console.ReadLine().ToUpper();
                            RemoveFromFile(path, deleteWord);

                            Console.WriteLine("Deleted word: " + deleteWord);
                        }
                        else if (submenu == "3")
                        {
                            Console.WriteLine("Returning to Main Menu");
                            break;
                        }
                        else
                            Console.WriteLine("Please only type in 1, 2 or 3.");
                    }
                }
                else if (selection == "3")
                    break;
            }

            Console.WriteLine("Thank you for playing!");
        }

        /// <summary>
        /// This will initiate a new game with a random work
        /// </summary>
        /// <param name="word">A random work, usually inserted using the GetRandomWord method</param>
        public static void PlayGame(string word)
        {
            string[] hiddenWord = TurnToHiddenWord(word);
            
            while (true)
            {
                string hiddenWordString = string.Join("  ", hiddenWord);
                Console.WriteLine(hiddenWordString);

                if (!hiddenWordString.Contains("_"))
                {
                    Console.WriteLine("You win! Congrats!");
                    break;
                }

                Console.WriteLine("Guess a letter. Type 'quit' to give up.");
                
                string guess = Console.ReadLine().ToUpper();

                if (guess == "QUIT")
                {
                    Console.WriteLine("Better luck next time! The word was: " + word);
                    break;
                }

                //This will populate the mystery word with their correctly guessed letter.
                for (int i = 0; i < hiddenWord.Length; i++)
                {
                    if (word[i].ToString() == guess)
                    {
                        hiddenWord[i] = guess;
                    }
                }

            }

            Console.WriteLine("Play again? Y/N:");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "Y")
                PlayGame(GetRandomWord());
        }

        /// <summary>
        /// Grabs a random word from the words file
        /// </summary>
        /// <returns>Returns a random word</returns>
        public static string GetRandomWord()
        {
            string path = "../../../myWords.txt";
            string[] allWords = ReadFile(path);

            Random rnd = new Random();
            int randomNum = rnd.Next(allWords.Length);

            return allWords[randomNum];
        }

        /// <summary>
        /// Grabs a word and returns it in underscores as a 'mystery' word.
        /// </summary>
        /// <param name="word">The word to turn into a mystery word</param>
        /// <returns>Returns the length of the word in a mystery word array</returns>
        public static string[] TurnToHiddenWord(string word)
        {
            string [] hiddenWord = new string[word.Length];


            for (int i = 0; i < hiddenWord.Length; i++)
            {
                hiddenWord[i] = "_";
            }

            return hiddenWord;
        }
        
        /// <summary>
        /// Creates a file and writes words to it
        /// </summary>
        /// <param name="path">Path to where to create file</param>
        /// <param name="words">Array of words to add to file</param>
        /// <returns>returns a true or false statement if the file was created</returns>
        public static bool CreateFile(string path, string[] words)
        {
            try
            {
                File.WriteAllLines(path, words);
            }
            catch
            {
                throw;
            }

            return File.Exists(path);
        }

        /// <summary>
        /// Deletes a file from the directory
        /// </summary>
        /// <param name="path">The path of the file to delete</param>
        /// <returns>Returns false if successful, since the file no longer exists</returns>
        public static bool DeleteAFile(string path)
        {
            File.Delete(path);
            return File.Exists(path);
        }

        /// <summary>
        /// Reads the file at the given path and returns what is inside
        /// </summary>
        /// <param name="path">Path of the file to read</param>
        /// <returns>An array of strings (words)</returns>
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

        /// <summary>
        /// Adds a word to our file
        /// </summary>
        /// <param name="path">Path of file to add word to</param>
        /// <param name="word">Word to add to file</param>
        /// <returns>The word that was added</returns>
        public static string AddToFile(string path, string word)
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
            string[] updatedWords = ReadFile(path);

            return updatedWords[updatedWords.Length-1];
        }

        /// <summary>
        /// Removes a word from a file.
        /// </summary>
        /// <param name="path">Path of file to remove word from</param>
        /// <param name="word">Word to remove.</param>
        public static void RemoveFromFile(string path, string word)
        {
            try
            {
                string[] currentWords = ReadFile(path);
                string[] newWords = new string[currentWords.Length - 1];
                
                int count = 0;
                for (int i = 0; i < currentWords.Length; i++)
                {
                    string oldWord = currentWords[i];
                    if (word != oldWord)
                    {
                        newWords[count] = currentWords[i];
                        count++;
                    }
                    else
                    {
                        continue;
                    }
                }

                DeleteAFile(path);
                CreateFile(path, newWords);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
