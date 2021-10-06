/* Game.cs
 * Author: Michael Keleti
 */

using System;
using System.Drawing;
using System.Linq;

namespace KSU.CIS300.ConnectFour
{
    /// <summary>
    /// Enum used to determine which players turn it is.
    /// </summary>
    public enum PlayersTurn
    {
        Red,
        Black
    }

    /// <summary>
    /// This class represents the game board and controls every possible action in the game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The total amounts of rows in each column.
        /// </summary>
        public const int ColumnSize = 6;

        /// <summary>
        /// A string containing each ID for every column and its respective button.
        /// </summary>
        public const string ColumnLabels = "ABCDEFG";

        /// <summary>
        /// An array of the player colors, which is Red and Black.
        /// </summary>
        public readonly Color[] PlayerColors = new Color[] { Color.Red, Color.Black };

        /// <summary>
        /// Which player is currently playing.
        /// </summary>
        public PlayersTurn Turn { get; set; } = PlayersTurn.Red;

        /// <summary>
        /// The column which contains each column in a double linked list which also
        /// stores every row in another doubled linked list.
        /// </summary>
        public DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> Column { get; set; } = null;

        /// <summary>
        /// Constructs the Game class as an object and sets each label in ColumnLabels to it's specific Column.
        /// </summary>
        public Game()
        {
            foreach (char label in ColumnLabels)
            {
                DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> PreviousColumn = Column;
                string OutputLabel = Convert.ToString(label);
                if (label == 'A')
                {
                    Column = new DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>>(OutputLabel);
                    Column.Previous = PreviousColumn;
                }
                else
                {
                    Column.Next = new DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>>(OutputLabel);
                    Column = Column.Next;
                    Column.Previous = PreviousColumn;
                }
            }
        }

        /// <summary>
        /// Changes the selected Column to the column that has the specified column ID in the parameter.
        /// </summary>
        /// <param name="columnId">Column ID to search for</param>
        public void ChangeColumn(string columnId)
        {
            DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> Current = Column;
            while (Current.Previous != null)
            {
                if (Current.Previous.Id == columnId)
                {
                    Column = Current.Previous;
                    return;
                }
                else
                {
                    Current = Current.Previous;
                }
            }
            Current = Column;
            while (Current.Next != null)
            {
                if (Current.Next.Id == columnId)
                {
                    Column = Current.Next;
                    return;
                }
                else
                {
                    Current = Current.Next;
                }
            }
        }

        /// <summary>
        /// A method that places a new piece in a specific row and column and sets the color of the piece within the Column Field.
        /// </summary>
        /// <param name="color">Color to set the new piece to</param>
        /// <param name="col">The column in which the Piece will be placed</param>
        /// <param name="row">The row of the column in which the piece will be placed</param>
        /// <returns>The ID of the piece that was placed: format (col+row)</returns>
        public string PlaceNewPiece(Color color, string col, out int row)
        {
            ChangeColumn(col);

            if (Column.Data == null)
            {
                Column.Data = new DoubleLinkedListCell<GamePiece>(Convert.ToString(col) + "1");
                Column.Data.Data = new GamePiece(color, 1, Convert.ToChar(col));
                row = 1;
            }
            else
            {
                row = Column.Data.Data.Row + 1;
                Column.Data.Next = new DoubleLinkedListCell<GamePiece>(Convert.ToString(col) + Convert.ToString(row));
                Column.Data.Next.Previous = Column.Data;
                Column.Data.Next.Data = new GamePiece(color, row, Convert.ToChar(col));
                Column.Data = Column.Data.Next;
            }
            string returnValue = col + row;
            return returnValue;
        }

        /// <summary>
        /// A method to find a specific piece in a cell in the Column Field.
        /// </summary>
        /// <param name="col">Character Column to search for vertically</param>
        /// <param name="row">String Row to search in Horizontally</param>
        /// <param name="found">Out double linked list cell that is found </param>
        /// <returns></returns>
        public bool FindCell(char col, int row, out DoubleLinkedListCell<GamePiece> found)
        {
            ChangeColumn(Convert.ToString(col));

            DoubleLinkedListCell<GamePiece> Row = Column.Data;
            if (Column.Data != null)
            {
                int Index = Convert.ToInt32(Column.Data.Id.Substring(1));

                for (int i = 0; i < Index; i++)
                {
                    int RowNum = Convert.ToInt32(Row.Id.Substring(1));

                    if (RowNum == row && ColumnLabels.Contains(col))
                    {
                        found = Row;
                        return true;
                    }
                    else
                    {
                        Row = Row.Previous;
                    }
                }
            }
            found = null;
            return false;
        }

        /// <summary>
        /// Checks to the board in a specific directio direction and col direction to see
        /// if the player has made a move of four in a row.
        /// </summary>
        /// <param name="row">First row to check win</param>
        /// <param name="col">First column to check for win</param>
        /// <param name="rowDirection">Increment in which rows should be searched</param>
        /// <param name="colDirection">Increment in which columns can be searched</param>
        /// <param name="color">Color of the piece to check for repeatedly</param>
        /// <returns>A boolean stating if the the player has successfuly won</returns>
        private bool Check(int row, char col, int rowDirection, int colDirection, Color color)
        {
            DoubleLinkedListCell<GamePiece> FoundRow;
            int InRow = 0;
            int Counter = 0;

            FindCell((char)(col + colDirection), row + rowDirection, out FoundRow);
            while (FoundRow != null && Counter < 3)
            {
                if (FoundRow.Data.PieceColor == color)
                {
                    Counter += 1;
                    InRow += 1;
                    FindCell((char)(FoundRow.Data.Column + colDirection), FoundRow.Data.Row + rowDirection, out FoundRow);
                }
                else
                {
                    break;
                }
            }

            Counter = 0;
            FindCell((char)(col - colDirection), row - rowDirection, out FoundRow);

            while (FoundRow != null && Counter < 3)
            {
                if (FoundRow.Data.PieceColor == color)
                {
                    Counter += 1;
                    InRow += 1;
                    FindCell((char)(FoundRow.Data.Column - colDirection), FoundRow.Data.Row - rowDirection, out FoundRow);
                }
                else
                {
                    break;
                }
            }

            if (InRow >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks to see if the player has won.
        /// </summary>
        /// <param name="cell">The specific cell to start checking from in every surrounding direction.</param>
        /// <returns>If the player has won then return true else return false</returns>
        public bool CheckWin(DoubleLinkedListCell<GamePiece> cell)
        {
            Color PieceColor = cell.Data.PieceColor;
            int row = cell.Data.Row;
            char col = Convert.ToChar(cell.Id.Substring(0, 1));
            bool returnValue = (Check(row, col, -1, 1, PieceColor) || Check(row, col, 1, 0, PieceColor) || Check(row, col, 0, 1, PieceColor) || Check(row, col, -1, -1, PieceColor));
            if (returnValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}