using Tris;
using System;
using System.IO;

namespace tris_app
{
    class Program
    {
        private const string InputPath = "input.txt";

        public static void Main(string[] args)
        {
            var input = new StreamReader(new FileStream(InputPath, FileMode.Open));
            Console.SetIn(input);
            Game.run();
            input.Close();
        }
    }
}
