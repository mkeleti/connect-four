/* GamePiece.cs
 * Author: Michael Keleti
 */

using System.Drawing;

namespace KSU.CIS300.ConnectFour
{
    // Class for the game pieces to be set on the board and stored within the double linked list cells.
    public class GamePiece
    {
        // The color of the piece on the board can be either red or black.
        public Color PieceColor
        {
            get; set;
        }

        // The row in which the game piece is stored
        public int Row
        {
            get; set;
        }

        // The column in which the game piece is stored
        public char Column
        {
            get; set;
        }

        /// <summary>
        ///  Constructs a new game piece with a set color, row, and column.
        /// </summary>
        /// <param name="color">Color of the game piece</param>
        /// <param name="row">Row of the game piece</param>
        /// <param name="column">Column of the game piece</param>
        public GamePiece(Color color, int row, char column)
        {
            PieceColor = color;
            Row = row;
            Column = column;
        }
    }
}