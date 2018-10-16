using System;
using Xunit;
using SystemIO;
using static SystemIO.Program;

namespace IOTest
{
    public class UnitTest1
    {
        string path = "../../../myWords.txt";
        string[] defaultWords = { "PUPPIES", "LAPTOP", "ORANGE", "WATER", "WHITEBOARD" };

        //CreaFile returns true if the file exists
        [Fact]
        public void CreateAFileCreatesFile()
        {
            Assert.True(CreateFile(path, defaultWords));
        }

        //Delete returns false once the file has been deleted
        [Fact]
        public void DeleteAFileDeletesFile()
        {
            Assert.False(DeleteAFile(path));
        }

        //Read returns an array of all words in the file
        [Fact]
        public void ReadFileReturnsArrayOfWords()
        {
            CreateFile(path, defaultWords);
            string[] fileTest = { "PUPPIES", "LAPTOP", "ORANGE", "WATER", "WHITEBOARD" };
            Assert.Equal(fileTest, ReadFile(path));
        }

        //Add returns the last word in the file, the newest one created
        [Fact]
        public void AddWordAddsAWord()
        {
            Assert.Equal("APPLES", AddToFile(path, "APPLES"));
        }

        //Remove returns an array of all words, with the entered word removed
        [Fact]
        public void RemoveWordDeletesAWord()
        {
            string[] deleteTest = { "PUPPIES", "ORANGE", "WATER", "WHITEBOARD" };
            Assert.Equal(deleteTest, RemoveFromFile(path, "LAPTOP"));
        }

        //Test wether a guess letter is found in the word (regularly run on a loop)
        [Fact]
        public void CalculateCorrectGuessedLetterReturnsTrue()
        {
            string word = defaultWords[0];
            Assert.True(CalculateGuess(word[0].ToString(), "P"));
        }
    }
}
