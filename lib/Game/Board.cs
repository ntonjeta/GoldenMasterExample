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

        private int BoardSize;
        public char[,] result { get; private set; }

        public Board(int boardsize)
        {
            this.BoardSize = boardsize;
            InitializeBoard(boardsize);
        }

        private void InitializeBoard(int boardsize)
        {
            result = new char[boardsize, boardsize];
            int count = 1;
            for (int i = 0; i < boardsize; i++)
            {
                for (int j = 0; j < boardsize; j++)
                {
                    result[i, j] = (char)(count + IntToAsciiOfSet);
                    count++;
                }
            }
        }

        public char[,] GetBoard()
        {
            return result;
        }

        public void UpdateBoard(int player, int choice)
        {
            var row = (choice -1) / BoardSize;
            var col = (choice -1) % BoardSize;
            result[row, col] = GetPlayerMarker(player);
        }

        private static char GetPlayerMarker(int actualPlayer)
        {
            return (actualPlayer == PlayerTwoId) ? PlayerTwoMark : PlayerOneMark;
        }
    }
}