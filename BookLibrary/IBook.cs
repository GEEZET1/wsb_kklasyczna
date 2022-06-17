using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    internal interface IBook
    {
        void BookInfo();
        int BorrowBook();
        int ReturnBook();
    }
}
