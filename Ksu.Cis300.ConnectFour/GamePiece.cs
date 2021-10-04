using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KSU.CIS300.ConnectFour
{
    public class GamePiece
    {
        public Color PieceColor
        {
            get; set;
        }

        public int Row
        {
            get; set;
        }

        public char Column
        {
            get; set;
        }

        public GamePiece(Color color, int row, char column)
        {
            PieceColor = color;
            Row = row;
            Column = column;
        }


    }
}
