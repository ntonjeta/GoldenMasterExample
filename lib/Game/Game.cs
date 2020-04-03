using System;
using System.Threading;

namespace Tris
{
    public class Game
    {
        private const int Player2 = 0;
        private const int NumberOfPlayer = 2;
        private const int DefaultBoardSize = 3;

        public static void run(int boardSize = 0)
        {
            Board board = new Board((boardSize == 0) ? DefaultBoardSize : boardSize);
            int actualPlayer = 1;

            while (board.CheckWin() == -1)
            {
                PrintPlayerChoise(actualPlayer);
                Console.WriteLine(board.Print());
                var choice = ReadPlayerChoise();
                if (!board.UpdateBoard(actualPlayer, choice))
                {
                    PrintCellIsAlreadyMarketMessage(board.GetCellValue(choice), choice);
                    continue;
                }
                actualPlayer = UpdatePlayer(actualPlayer);
            }

            PrintResult(board, actualPlayer);
        }

        private static void PrintResult(Board board, int actualPlayer)
        {
            Console.Clear();
            Console.WriteLine(board.Print());
            Console.WriteLine((ActualPlayerWin(board))
                    ? string.Format("Player {0} has won", (actualPlayer % NumberOfPlayer) + 1)
                    : "Draw");
            Console.ReadLine();
        }

        private static bool ActualPlayerWin(Board board)
        {
            return board.CheckWin() == 1;
        }

        private static void PrintCellIsAlreadyMarketMessage(char cellValue, int row)
        {
            Console.WriteLine("Sorry the row {0} is already marked with {1}", row, cellValue);
            Console.WriteLine("\n");
            Console.WriteLine("Please wait 2 second board is loading again.....");
            Thread.Sleep(2000);
        }

        private static int ReadPlayerChoise()
        {
            return int.Parse(Console.ReadLine());
        }

        private static void PrintPlayerChoise(int actualPlayer)
        {
            Console.Clear();
            Console.WriteLine("Player1:X and Player2:O");
            Console.WriteLine("\n");
            Console.WriteLine((actualPlayer == Player2) ? "Player 2 Chance" : "Player 1 Chance");
            Console.WriteLine("\n");
        }

        private static int UpdatePlayer(int player)
        {
            return (player + 1) % NumberOfPlayer;
        }
    }
}