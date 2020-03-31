using System;

namespace Tris
{
    public class Board
    {
        private int boardsize;
        public byte[,] board { get; private set; }

        public Board(int boardsize)
        {
            this.boardsize = boardsize;
            board = new byte[boardsize, boardsize];
            int count = 1;
            for (int i = 0; i < boardsize; i++)
            {
                for (int j = 0; j < boardsize; j++)
                {
                    board[i, j] = (byte)count;
                    count++;
                }
            }
        }


        public byte[,] GetBoard()
        {
            return board;
        }
    }
}