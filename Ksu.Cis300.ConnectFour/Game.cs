using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KSU.CIS300.ConnectFour
{
    public enum PlayersTurn
    {
        Red,
        Black
    }
    /// <summary>
    /// 
    /// </summary>
    public class Game
    {
        public const int ColumnSize = 6;
        public const string ColumnLabels = "ABCDEFG";
        public readonly Color[] PlayerColors = new Color[] { Color.Red, Color.Black };

        public PlayersTurn Turn { get; set; } = PlayersTurn.Red;

        public DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> Column { get; set; } = null;

        
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="columnId"></param>
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
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <param name="found"></param>
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
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="rowDirection"></param>
        /// <param name="colDirection"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private bool Check(int row, char col, int rowDirection, int colDirection, Color color)
        {   

            DoubleLinkedListCell<GamePiece> FoundRow;
            int InRow = 0;
            int Counter = 0;

            FindCell((char)(col + colDirection), row + rowDirection, out FoundRow);
            while (FoundRow != null && Counter < 3) {
                    
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
        /// 
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
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
