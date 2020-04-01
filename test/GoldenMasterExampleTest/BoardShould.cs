using System;
using NUnit.Framework;
using Tris;

namespace GoldenMasterExampleTest
{
    public class BoardShould
    {
        private const int BoardSize = 3;
        private const int PlayerOne = 1;
        private const int PlayerTwo = 0;
        private const int FirstChoice = 1;
        private const int SecondChoice = 2;
        private const char NotMarkedCellValue = '-';
        private const char PlayerOneMark = 'X';
        private const int LargestBoardSize = 4;
        private const int Win = 1;
        private const int FourtChoice = 4;
        private const int SeventhChoice = 7;
        private const int FivethChoice = 5;
        private const int EighthChoice = 8;
        private const int ThirdChoice = 3;
        private const int NinthChoice = 9;
        private readonly char[,] InitialBoard = new char[BoardSize, BoardSize]{
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
        private readonly char[,] OneChangeBoard = new char[BoardSize, BoardSize]{
                { 'X' , '2', '3'},
                { '4', '5', '6' },
                { '7', '8', '9'}
            };
        private readonly char[,] TwoChangeBoard = new char[BoardSize, BoardSize]{
                { 'X' , 'O', '3'},
                { '4', '5', '6' },
                { '7', '8', '9'}
            };

        private Board _board;

        [SetUp]
        public void CreateBoard()
        {
            _board = new Board(BoardSize);
        }

        [Test]
        public void ReturnBoard()
        {
            Assert.AreEqual(InitialBoard, _board.GetBoard());
        }

        [Test]
        public void UpdateBoard()
        {
            Assert.True(_board.UpdateBoard(PlayerOne, FirstChoice));
            Assert.True(_board.UpdateBoard(PlayerTwo, SecondChoice));
            Assert.AreEqual(TwoChangeBoard, _board.GetBoard());
        }

        [Test]
        public void ReturnErrorWhenUpdateAlreadyTakenCell()
        {
            Assert.True(_board.UpdateBoard(PlayerOne, FirstChoice));

            Assert.False(_board.UpdateBoard(PlayerTwo, FirstChoice));
            Assert.AreEqual(OneChangeBoard, _board.GetBoard());
        }

        [Test]
        public void ReturnCellValueForChoice()
        {
            Assert.AreEqual(NotMarkedCellValue, _board.GetCellValue(FirstChoice));
            Assert.True(_board.UpdateBoard(PlayerOne, FirstChoice));
            Assert.AreEqual(PlayerOneMark, _board.GetCellValue(FirstChoice));
        }

        [Test]
        public void PrintBoard()
        {
            var expectedBoard =
                "     |     |     \n" +
                "  X  |  2  |  3  \n" +
                "_____|_____|_____\n" +
                "     |     |     \n" +
                "  4  |  5  |  6  \n" +
                "_____|_____|_____\n" +
                "     |     |     \n" +
                "  7  |  8  |  9  \n" +
                "     |     |     \n";

            _board.UpdateBoard(PlayerOne, FirstChoice);

            StringAssert.AreEqualIgnoringCase(expectedBoard, _board.Print());
        }

        [Test]
        public void CheckVerticalWinningCondition()
        {
            _board.UpdateBoard(PlayerOne, FirstChoice);
            _board.UpdateBoard(PlayerOne, FourtChoice);
            _board.UpdateBoard(PlayerOne, SeventhChoice);

            Assert.AreEqual(Win, _board.CheckWin());

            _board = new Board(BoardSize);
            _board.UpdateBoard(PlayerOne, SecondChoice);
            _board.UpdateBoard(PlayerOne, FivethChoice);
            _board.UpdateBoard(PlayerOne, EighthChoice);

            Assert.AreEqual(Win, _board.CheckWin());
        }

        [Test]
        public void CheckOrizontalWinningCondition()
        {
            _board.UpdateBoard(PlayerOne, FirstChoice);
            _board.UpdateBoard(PlayerOne, SecondChoice);
            _board.UpdateBoard(PlayerOne, ThirdChoice);

            Assert.AreEqual(Win, _board.CheckWin());
        }

        [Test]
        public void CheckDiagonalWinningCondition()
        {
            _board.UpdateBoard(PlayerOne, FirstChoice);
            _board.UpdateBoard(PlayerOne, FivethChoice);
            _board.UpdateBoard(PlayerOne, NinthChoice);

            Assert.AreEqual(Win, _board.CheckWin());

            _board = new Board(BoardSize);
            _board.UpdateBoard(PlayerOne, ThirdChoice);
            _board.UpdateBoard(PlayerOne, FivethChoice);
            _board.UpdateBoard(PlayerOne, SeventhChoice);

            Assert.AreEqual(Win, _board.CheckWin());
        }
    }
}