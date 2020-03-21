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

        public static void run()
        {
            char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int actualPlayer = 1;

            while (CheckWin(board) == 0)
            {
                PrintPlayerChoise(actualPlayer);
                PrintBoard(board);
                var choice = ReadPlayerChoise();
                if (isBoardCellAlreadyTaken(board[choice]))
                {
                    PrintCellIsAlreadyMarketMessage(board[choice], choice);
                    continue;
                }
                board[choice] = GetPlayerMarker(actualPlayer);
                actualPlayer = UpdatePlayer(actualPlayer);
            }

            PrintResult(board, actualPlayer);
        }

        private static void PrintResult(char[] board, int actualPlayer)
        {
            Console.Clear();
            PrintBoard(board);
            Console.WriteLine((ActualPlayerWin(board))
                    ? string.Format("Player {0} has won", (actualPlayer % NumberOfPlayer) + 1)
                    : "Draw");
            Console.ReadLine();
        }

        private static bool ActualPlayerWin(char[] board)
        {
            return CheckWin(board) == 1;
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
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin(char[] board)
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row   
            if (board[1] == board[2] && board[2] == board[3])
            {
                return 1;
            }

            //Winning Condition For Second Row   
            else if (board[4] == board[5] && board[5] == board[6])
            {
                return 1;
            }

            //Winning Condition For Third Row   
            else if (board[6] == board[7] && board[7] == board[8])
            {
                return 1;
            }

            #endregion

            #region vertical Winning Condtion

            //Winning Condition For First Column       
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }

            //Winning Condition For Second Column  
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }

            //Winning Condition For Third Column  
            else if (board[3] == board[6] && board[6] == board[9])
            {
                return 1;
            }

            #endregion

            #region Diagonal Winning Condition
            else if (board[1] == board[5] && board[5] == board[9])
            {
                return 1;
            }

            else if (board[3] == board[5] && board[5] == board[7])
            {
                return 1;
            }

            #endregion

            #region Checking For Draw

            // If all the cells or values filled with X or O then any player has won the match  
            else if (board[1] != '1' && board[2] != '2' && board[3] != '3' && board[4] != '4' && board[5] != '5' && board[6] != '6' && board[7] != '7' && board[8] != '8' && board[9] != '9')
            {
                return -1;
            }

            #endregion

            return 0;
        }
    }
}