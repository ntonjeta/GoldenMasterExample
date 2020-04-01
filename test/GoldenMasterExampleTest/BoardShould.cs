using NUnit.Framework;
using Tris;

namespace GoldenMasterExampleTest
{
    public class BoardShould
    {
        private const int Boardsize = 3;
        private const int PlayerOne = 1;
        private const int PlayerTwo = 0;
        private const int FirstChoice = 1;
        private const int SecondChoice = 2;
        private readonly char[,] InitialBoard = new char[Boardsize, Boardsize]{
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
        private readonly char[,] OneChangeBoard = new char[Boardsize, Boardsize]{
                { 'X' , '2', '3'},
                { '4', '5', '6' },
                { '7', '8', '9'}
            };
        private readonly char[,] TwoChangeBoard = new char[Boardsize, Boardsize]{
                { 'X' , 'O', '3'},
                { '4', '5', '6' },
                { '7', '8', '9'}
            };

        private Board _board;

        [SetUp]
        public void CreateBoard()
        {
            _board = new Board(Boardsize);
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
            Assert.AreEqual('-', _board.GetCellValue(FirstChoice));
            Assert.True(_board.UpdateBoard(PlayerOne,FirstChoice));
            Assert.AreEqual('X',_board.GetCellValue(FirstChoice));
        }
    }
}