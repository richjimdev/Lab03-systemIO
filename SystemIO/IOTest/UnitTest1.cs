using System;
using Xunit;
using SystemIO;
using static SystemIO.Program;

namespace IOTest
{
    public class UnitTest1
    {
        string path = "../../../myWords.txt";

        [Fact]
        public void CreateAFileCreatesFile()
        {
            Assert.True(CreateFile(path));
        }

        [Fact]
        public void DeleteAFileDeletesFile()
        {
            Assert.False(DeleteAFile(path));
        }
    }
}
