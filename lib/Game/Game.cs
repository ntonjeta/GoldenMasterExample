using System;
using System.Threading;

namespace Tris
{
    public class Game
    {
        private const char Player2Mark = 'O';
        private const char Player1Mark = 'X';
        private const int Player2 = 0;
        private const int NumberOfPlayer = 2;
        private const int MatrixDimension = 3;
        private const int Boardsize = 3;

        public static void run()
        {
            Board board = new Board(Boardsize);
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

        private static char GetPlayerMarker(int actualPlayer)
        {
            return (actualPlayer == Player2) ? Player2Mark : Player1Mark;
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

        private static bool isBoardCellAlreadyTaken(char cellValue)
        {
            return cellValue == Player1Mark || cellValue == Player2Mark;
        }

        private static void PrintBoard(char[] board)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin(char[] board)
        {
            //Winning Condition For First Row   
            if (board[0] == board[1] && board[1] == board[2])
            {
                return 1;
            }

            //Winning Condition For Second Row   
            else if (board[3] == board[4] && board[4] == board[5])
            {
                return 1;
            }

            //Winning Condition For Third Row   
            else if (board[5] == board[6] && board[6] == board[7])
            {
                return 1;
            }


            //Winning Condition For First Column       
            else if (board[0] == board[3] && board[3] == board[6])
            {
                return 1;
            }

            //Winning Condition For Second Column  
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }

            //Winning Condition For Third Column  
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }

            else if (board[0] == board[4] && board[4] == board[8])
            {
                return 1;
            }

            else if (board[2] == board[4] && board[4] == board[6])
            {
                return 1;
            }

            // If all the cells or values filled with X or O then any player has won the match  
            else if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4' && board[4] != '5' && board[5] != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9')
            {
                return -1;
            }

            return 0;
        }
    }
}