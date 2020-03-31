using NUnit.Framework;
using Tris;

namespace GoldenMasterExampleTest
{
    public class BoardShould
    {
        private const int Boardsize = 3;
        private readonly char[,] InitialBoard = new char[Boardsize, Boardsize]{
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
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

        // [Test]
        // public void UpdateBoard()
        // {
        //     Assert.AreEqual(new byte[Boardsize, Boardsize]{
        //        { 'X' , 2, 3},
        //     { 4, 5, 6 },
        //     { 7, 8, 9}}, _board.UpdateBoard(1, 1));
        // }
    }
}