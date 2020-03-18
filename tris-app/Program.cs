using Tris;
using System;
using System.IO;

namespace tris_app
{
    class Program
    {
        private const string InputFolderPath = "input";
        private const string OutputPath = "output/output.txt";

        public static void Main(string[] args)
        {
            foreach (var filePath in Directory.GetFiles(InputFolderPath)) {
                var input = new StreamReader(new FileStream(filePath, FileMode.Open));
                var output = new StreamWriter(new FileStream(OutputPath, FileMode.Append));
                Console.SetIn(input);
                Console.SetOut(output);
                Game.run();
                input.Close();
                output.Close();
            }
        }
    }
}
