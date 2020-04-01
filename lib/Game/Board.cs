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
        private const char NotMarkedCellValue = '-';
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
                    _board[i, j] = (char)count; 
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
            ? NotMarkedCellValue
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
        public string Print()
        {
            string result = "";
            for (int i = 0; i < BoardSize; i++)
            {
                result += PrintRow(i);
            }
            return result;
        }

        private string PrintRow(int rowIndex)
        {
            string emptyLine = BuildEmptyLine();
            string breakLine = BuildBreakLine();

            var row = emptyLine;
            row += BuildValueLine(rowIndex);
            row += (rowIndex != BoardSize - 1)
                ? breakLine
                : emptyLine;

            return row;
        }

        private string BuildValueLine(int rowIndex)
        {
            var result = "";
            for (int i = 0; i < BoardSize; i++)
            {
                result += "  " + GetBoardMarker(rowIndex, i) + "  ";
                result += (i == BoardSize - 1) ? "" : "|";
            }
            return result + "\n";
        }

        private string GetBoardMarker(int row, int col)
        {
            switch (_board[row,col]){
                case PlayerOneMark:
                return PlayerOneMark.ToString();
                case PlayerTwoMark:
                return PlayerTwoMark.ToString();
                default:
                 return((int)_board[row, col]).ToString(); 
            }
        }

        private string BuildBreakLine()
        {
            var result = "";
            for (int i = 0; i < BoardSize; i++)
            {
                result += "_____";
                result += (i == BoardSize - 1) ? "" : "|";

            }
            return result + "\n";
        }

        private string BuildEmptyLine()
        {
            var result = "";
            for (int i = 0; i < BoardSize; i++)
            {
                result += "     ";
                result += (i == BoardSize - 1) ? "" : "|";

            }
            return result + "\n";
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

        public int CheckWin()
        {
            if (CheckVerticalWinning()) return 1;
            if (CheckOrizontalWinning()) return 1;
            if (CheckDiagonalWinning()) return 1;
            if (CheckDraw()) return 0;
            return -1;
        }

        private bool CheckDraw()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (_board[i, j] != PlayerOneMark && _board[i, j] != PlayerTwoMark)
                        return false;
                }
            }
            return true;
        }

        private bool CheckDiagonalWinning()
        {
            if (CheckMajorDiagonal())
                return true;

            if (CheckMinorDiagonal())
                return true;

            return false;
        }

        private bool CheckMajorDiagonal()
        {
            var v = _board[0, 0];
            for (int i = 1; i < BoardSize; i++)
            {
                if (_board[i, i] != v) return false;
            }
            return true;
        }

        private bool CheckMinorDiagonal()
        {
            var value = _board[0, BoardSize - 1];
            for (int i = 1; i < BoardSize; i++)
            {
                if (_board[i, BoardSize - (i + 1)] != value) return false;
            }
            return true;
        }

        private bool CheckVerticalWinning()
        {
            for (int col = 0; col < BoardSize; col++)
            {
                var result = 1;
                var value = _board[0, col];
                for (int row = 1; row < BoardSize; row++)
                {
                    if (_board[row, col] != value) result = -1;
                }
                if (result == 1)
                    return true;
            }
            return false;
        }

        private bool CheckOrizontalWinning()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                var result = 1;
                var value = _board[row, 0];
                for (int col = 1; col < BoardSize; col++)
                {
                    if (_board[row, col] != value) result = -1;
                }
                if (result == 1)
                    return true;
            }
            return false;
        }
    }
}