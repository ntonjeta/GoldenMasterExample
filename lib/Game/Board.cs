using System;

namespace Tris
{
    public class Board
    {
        private const char PlayerOneMark = 'X';
        private const char PlayerTwoMark = 'O';
        private const int PlayerOneId = 1;
        private const int PlayerTwoId = 0;
        private const int IntToAsciiOfSet = 48;

        private int boardsize;
        public char[,] board { get; private set; }

        public Board(int boardsize)
        {
            this.boardsize = boardsize;
            InitializeBoard(boardsize);
        }

        private void InitializeBoard(int boardsize)
        {
            board = new char[boardsize, boardsize];
            int count = 1;
            for (int i = 0; i < boardsize; i++)
            {
                for (int j = 0; j < boardsize; j++)
                {
                    board[i, j] = (char)(count + IntToAsciiOfSet);
                    count++;
                }
            }
        }

        public char[,] GetBoard()
        {
            return board;
        }

        public void UpdateBoard(int player, int choice)
        {
            var row = (choice -1) / 3;
            var col = (choice -1) % 3;
            board[row, col] = GetPlayerMarker(player);
        }

        private static char GetPlayerMarker(int actualPlayer)
        {
            return (actualPlayer == PlayerTwoId) ? PlayerTwoMark : PlayerOneMark;
        }
    }
}