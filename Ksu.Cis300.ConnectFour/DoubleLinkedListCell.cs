/* DoubleLinkedListCell.cs
 * Author: Michael Keleti
 */

namespace KSU.CIS300.ConnectFour
{
    /// <summary>
    /// Class for the Double Linked List Cell
    /// </summary>
    /// <typeparam name="T">Specific type of data to store in the Double Linked List cell</typeparam>
    public class DoubleLinkedListCell<T>
    {
        /// <summary>
        /// The next cell in the double linked list cell
        /// </summary>
        public DoubleLinkedListCell<T> Next
        {
            get; set;
        }

        /// <summary>
        /// The previous cell in the double linked list cell.
        /// </summary>
        public DoubleLinkedListCell<T> Previous
        {
            get; set;
        }

        /// <summary>
        /// The data stored within the double linked list cell node.
        /// </summary>
        public T Data
        {
            get; set;
        }

        /// <summary>
        /// The specific ID of the double linked list cell
        /// </summary>
        public string Id
        {
            get; set;
        }

        /// <summary>
        /// Constructor for double linked list cell which sets the ID of the cell.
        /// </summary>
        /// <param name="identifier">ID to set to the initialized cell.</param>
        public DoubleLinkedListCell(string identifier)
        {
            Id = identifier;
        }
    }
}