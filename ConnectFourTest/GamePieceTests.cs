using NUnit.Framework;
using KSU.CIS300.ConnectFour;
using System;

using System.Drawing;

namespace KSU.CIS300.ConnectFour.Test
{
    public class GamePieceTests
    {
        [Test]
        [Category("A-GamePiece")]
        public void A3_GamePieceUnitTest_NewPiece()
        {
            GamePiece gp = new GamePiece(Color.Purple, 2, 'Z');
            Assert.AreEqual(Color.Purple, gp.PieceColor);
            Assert.AreEqual(2, gp.Row);
            Assert.AreEqual('Z', gp.Column);
        }
        
    }
}