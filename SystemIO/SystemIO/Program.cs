using System;
using System.IO;
using System.Text;

namespace SystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../myWords.txt";
            Console.WriteLine("Hello World!");
            CreateInitialFile(path);

        }

        public static void CreateInitialFile(string path)
        {
            string[] wordsArray = new string[5];
            wordsArray[0] = "PUPPIES";
            wordsArray[1] = "LAPTOP";
            wordsArray[2] = "ORANGE";
            wordsArray[3] = "WATER";
            wordsArray[4] = "WHITEBOARD";

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (string word in wordsArray)
                    {
                        sw.WriteLine(word);
                    }
                    
                }

            }
            catch
            {

            }
            finally
            {

            }
        }
    }
}
