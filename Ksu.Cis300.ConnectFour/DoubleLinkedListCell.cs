using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU.CIS300.ConnectFour
{
    public class DoubleLinkedListCell<T>
    {
        public DoubleLinkedListCell<T> Next
        {
            get; set;
        }

        public DoubleLinkedListCell<T> Previous
        {
            get; set;
        }

        public T Data
        {
            get; set;
        }

        public string Id
        {
            get; set;
        }

        public DoubleLinkedListCell(string identifier)
        {
            Id = identifier;
        }
    }
}
