using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IBook
    {
        public string title;
        public string author;
        public int id;
        private int quanity;

        public Book()
        {
            title = "";
            author = "";
            id = 0;
            quanity = 0;
        }

        public Book(string t, string a, int i, int q)
        {
            title = t;
            author = a;
            id = i;
            quanity = q;
        }

        public int ReturnBook()
        {
            Console.WriteLine($"Oddano {title}\n");
            return quanity++;
        }

        public int BorrowBook()
        {
            if (quanity > 0)
            {
                Console.WriteLine($"Wypożyczono {title}\n");
                return quanity--;
            }
            else
            {
                Console.WriteLine("Nie posiadamy tej książki na stanie");
                return 0;
            }

        }
        public void BookInfo()
        {
            Console.WriteLine($"Tytuł: {title}");
            Console.WriteLine($"Autor: {author}");
            Console.WriteLine($"Dostępna ilość: {quanity}\n");
        }
        public void BookInfo(int id)
        {
            Console.WriteLine($"Numer unikatowy: {id}");
            Console.WriteLine($"Dostępna ilość: {quanity}\n");
        }
    }
}