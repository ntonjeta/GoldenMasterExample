using Tris;
using System;
using System.IO;

namespace tris_app
{
    class Program
    {
        private const string InputPath = "input/input.txt";
        private const string OutputPath = "output/output.txt";

        public static void Main(string[] args)
        {
            var input = new StreamReader(new FileStream(InputPath, FileMode.Open));
            var output = new StreamWriter(new FileStream(OutputPath, FileMode.Create));
            Console.SetIn(input);
            Console.SetOut(output);
            Game.run();
            input.Close();
            output.Close();
        }
    }
}
