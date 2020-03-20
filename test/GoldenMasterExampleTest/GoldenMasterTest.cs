using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Tris;

namespace GoldenMasterExampleTest
{
    public class TrisGameShould
    {
        private readonly string InputFolderPath = TestContext.CurrentContext.TestDirectory + "../../../../../../input/";
        private readonly string OutputFolderPath = TestContext.CurrentContext.TestDirectory + "/";
        private readonly string GoldenMasterOutput = TestContext.CurrentContext.TestDirectory + "../../../../../../goldenMaster/";
        private string inputPath;
        private string outputPath;

        [TearDown]
        public void TearDown()
        {
            File.Delete(outputPath);
        }


        [Test]
        public void WinPlayerOne()
        {
            inputPath = InputFolderPath + "input1.txt";
            outputPath = OutputFolderPath + "output1.txt";
            var goldenMasterOutput = GoldenMasterOutput + "output1.txt";

            var input = new StreamReader(new FileStream(inputPath, FileMode.Open));
            var output = new StreamWriter(new FileStream(outputPath, FileMode.CreateNew));
            Console.SetIn(input);
            Console.SetOut(output);

            Game.run();

            input.Close();
            output.Close();

            Assert.True(AreFileEquals(goldenMasterOutput, outputPath));
        }

        private bool AreFileEquals(string expectedPath, string actualPath)
        {
            byte[] bytes1 = Encoding.Convert(Encoding.ASCII, Encoding.ASCII, Encoding.ASCII.GetBytes(File.ReadAllText(expectedPath)));
            byte[] bytes2 = Encoding.Convert(Encoding.ASCII, Encoding.ASCII, Encoding.ASCII.GetBytes(File.ReadAllText(actualPath)));

            return bytes1.SequenceEqual(bytes2);
        }
    }
}