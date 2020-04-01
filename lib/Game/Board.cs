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
        private char[,] _board { get; set; }

        public Board(int boardsize)
        {
            this.BoardSize = boardsize;
            InitializeBoard(boardsize);
        }

        private void InitializeBoard(int boardsize)
        {
            _board = new char[boardsize, boardsize];
            int count = 1;
            for (int i = 0; i < boardsize; i++)
            {
                for (int j = 0; j < boardsize; j++)
                {
                    _board[i, j] = (char)(count + IntToAsciiOfSet);
                    count++;
                }
            }
        }

        public char[,] GetBoard()
        {
            return _board;
        }

        public char GetCellValue(int choice)
        {
            var row = GetRow(choice);
            var col = GetCol(choice);

            return (_board[row, col] != PlayerOneMark && _board[row, col] != PlayerTwoMark)
            ? '-'
            : _board[row, col];
        }

        public bool UpdateBoard(int player, int choice)
        {
            var row = GetRow(choice);
            var col = GetCol(choice);

            if (isCellAlreadyTaken(row, col))
                return false;

            _board[row, col] = GetPlayerMarker(player);
            return true;
        }

        private int GetCol(int choice)
        {
            return (choice - 1) % BoardSize;
        }

        private int GetRow(int choice)
        {
            return (choice - 1) / BoardSize;
        }

        private bool isCellAlreadyTaken(int row, int col)
        {
            var cellValue = _board[row, col];
            return cellValue == PlayerOneMark || cellValue == PlayerTwoMark;
        }

        private static char GetPlayerMarker(int actualPlayer)
        {
            return (actualPlayer == PlayerTwoId) ? PlayerTwoMark : PlayerOneMark;
        }

    }
}