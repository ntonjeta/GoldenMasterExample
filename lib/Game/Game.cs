using System;
using System.Threading;

namespace Tris
{
    public class Game
    {
        private const char Player2Mark = 'O';
        private const char Player1Mark = 'X';
        private const int Player2 = 0;

        public static void run()
        {
            char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int actualPlayer = 1;
            int choice;
            int flag = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                if (actualPlayer == Player2)
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }

                Console.WriteLine("\n");
                PrintBoard(board);

                choice = int.Parse(Console.ReadLine());//Taking users choice   

                if (isBoardCellAlreadyTaken(board, choice))
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, board[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                    continue;
                }

                if (actualPlayer % 2 == Player2)
                {
                    board[choice] = Player2Mark;
                    actualPlayer = UpdatePlayer(actualPlayer);
                }
                else
                {
                    board[choice] = Player1Mark;
                    actualPlayer = UpdatePlayer(actualPlayer);
                }

                flag = CheckWin(board);

            } while (flag != 1 && flag != -1);// This loof will be run until all cell of the grid is not marked with X and O or some player is not win  

            Console.Clear();

            PrintBoard(board);

            if (flag == 1)// if flag value is 1 then some one has win or means who played marked last time which has win  
            {
                Console.WriteLine("Player {0} has won", (actualPlayer % 2) + 1);
            }

            else// if flag value is -1 the match will be draw and no one is winner  
            {
                Console.WriteLine("Draw");
            }

            Console.ReadLine();
        }

        private static int UpdatePlayer(int actualPlayer)
        {
            actualPlayer = (actualPlayer + 1) % 2;
            return actualPlayer;
        }

        private static bool isBoardCellAlreadyTaken(char[] board, int choice)
        {
            return board[choice] == Player1Mark || board[choice] == Player2Mark;
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

            else
            {
                return 0;
            }
        }
    }
}