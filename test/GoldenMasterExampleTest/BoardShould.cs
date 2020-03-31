using NUnit.Framework;
using Tris;

namespace GoldenMasterExampleTest
{
    public class BoardShould
    {
        private Board _board;

        private const int PlayerOne = 1;
        private const int PlayerTwo = 0;
        private const int PlayerOneChoice = 1;
        private const int PlayerTwoChoice = 2;
        private readonly char[] InitialBoard = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private readonly char[] UpdatedBoard = { 'X', 'O', '3', '4', '5', '6', '7', '8', '9' };

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
        }

        [Test]
        public void ReturnBoard()
        {
            Assert.AreEqual(InitialBoard, _board.GetBoard());
        }
    }
}