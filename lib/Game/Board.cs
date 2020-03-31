using System;

namespace Tris
{
    public class Board
    {
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
                    board[i, j] = (char) (count + IntToAsciiOfSet);
                    count++;
                }
            }
        }

        public char[,] GetBoard()
        {
            return board;
        }

        public byte UpdateBoard(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}