using Tris;
using System;
using System.IO;

namespace tris_app
{
    class Program
    {
        private const string InputFolderPath = "input/";
        private const string OutputFolderPath = "output/";

        public static void Main(string[] args)
        {
            int i = 1;
            foreach (var filePath in Directory.GetFiles(InputFolderPath)) {
                var input = new StreamReader(new FileStream(filePath, FileMode.Open));
                var output = new StreamWriter(new FileStream(OutputFolderPath + "output" + i.ToString() + ".txt" , FileMode.Append));
                Console.SetIn(input);
                Console.SetOut(output);
                Game.run();
                input.Close();
                output.Close();
                i++;
            }
        }
    }
}
