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

        [Fact]
        public void CreateAFileCreatesFile()
        {
            Assert.True(CreateFile(path, defaultWords));
        }

        [Fact]
        public void DeleteAFileDeletesFile()
        {
            Assert.False(DeleteAFile(path));
        }

        [Fact]
        public void ReadFileReturnsArrayOfWords()
        {
            CreateFile(path, defaultWords);
            string[] fileTest = { "PUPPIES", "LAPTOP", "ORANGE", "WATER", "WHITEBOARD" };
            Assert.Equal(fileTest, ReadFile(path));
        }

        [Fact]
        public void AddWordAddsAWord()
        {
            Assert.Equal("APPLES", AddToFile(path, "APPLES"));
        }
    }
}
