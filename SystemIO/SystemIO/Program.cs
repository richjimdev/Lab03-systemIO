using System;
using System.IO;
using System.Text;

namespace SystemIO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PlayGame();

        }

        public static void PlayGame()
        {
            string path = "../../../myWords.txt";

            CreateFile(path);
            string[] allWords = ReadFile(path);

            Random rnd = new Random();
            int randomNum = rnd.Next(allWords.Length);

            string randomWord = allWords[randomNum];

            string[] hiddenWord = new string[randomWord.Length];

            string guess = "A";

            for (int i = 0; i < hiddenWord.Length; i++)
            {
                    hiddenWord[i] = "_";
            }

            for (int i = 0; i < hiddenWord.Length; i++)
            {
                if (randomWord[i].ToString() == guess)
                {
                    hiddenWord[i] = guess;
                }
            }

            Console.WriteLine(string.Join("  ", hiddenWord));

            //Console.WriteLine(hiddenWord);
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
            
        }
    }
}
