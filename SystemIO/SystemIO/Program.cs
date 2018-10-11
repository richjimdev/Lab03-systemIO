using System;
using System.IO;
using System.Text;

namespace SystemIO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = "../../../myWords.txt";
            //DeleteAFile(path);
            CreateFile(path);

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
