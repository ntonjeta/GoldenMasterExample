using Tris;
using System;
using System.IO;

namespace tris_app
{
    class Program
    {
        private const string InputFolderPath = "input/";
        private const string OutputFolderPath = "goldenMaster/";

        public static void Main(string[] args)
        {
            Console.WriteLine("Insert Diagonal dimension of Board: ");
            var boardSize = int.Parse(Console.ReadLine());
            Game.run(boardSize);
        }
    }
}
