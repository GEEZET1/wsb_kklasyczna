using System;
using System.Linq;
using ProjektLibrary;

namespace Projekt
{
    internal class Program
    {
        public static List<Book> books = new List<Book>();
        public void DisplayMenu(int decision)
        {
            switch (decision)
            {
                case 1:
                    DisplayBooks();
                    break;
                case 2:
                    BorrowBooks();
                    break;
                case 3:
                    ReturnBooks();
                    break;
                case 4:
                    SearchBooks();
                    break;
                default:
                    break;
            }
        }

        public void DisplayBooks()
        {
            Console.Clear();
            foreach (var book in books)
            {
                book.BookInfo();
            }
            Welcome();
        }

        public void BorrowBooks()
        {
            Console.Clear();
            Console.Write("Jaką książkę chcesz wypożyczyć? Podaj tytuł: ");
            string bookToBorrow = Console.ReadLine();
            try
            {
                var bookQuery = (from bookTB in books where bookTB.title == bookToBorrow select bookTB).Distinct();
                if(bookQuery.Count() <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Nie ma takiej książki");
                    Welcome();
                } else
                {
                    Console.Clear();
                    foreach (var item in bookQuery)
                    {
                        item.BorrowBook();
                    }
                    Welcome();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Nie ma takiej książki");
                Welcome();
            }
        }

        public void ReturnBooks()
        {
            Console.Clear();
            Console.Write("Jaką książkę chcesz oddać? Podaj tytuł: ");
            string bookToReturn = Console.ReadLine();
            try
            {
                var bookQuery = (from bookTR in books where bookTR.title == bookToReturn select bookTR).Distinct();
                if (bookQuery.Count() <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Nie ma posiadamy takiej książki w rejestrze");
                    Welcome();
                }
                else
                {
                    Console.Clear();
                    foreach (var item in bookQuery)
                    {
                        item.ReturnBook();
                    }
                    Welcome();
                }
            } catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Nie ma posiadamy takiej książki w rejestrze");
                Welcome();
            }
        }

        public void SearchBooks()
        {
            Console.Write("Numer unikatowy: ");
            int id = int.Parse(Console.ReadLine());
            var bookQuery = (from bookID in books where bookID.id == id select bookID).Distinct();
            if (bookQuery.Count() <= 0)
            {
                Console.Clear();
                Console.WriteLine("Nie ma posiadamy takiej książki w rejestrze");
                Welcome();
            }
            else
            {
                Console.Clear();
                foreach (var item in bookQuery)
                {
                    item.BookInfo(id);
                }
                Welcome();
            }
        }

        public void Welcome()
        {
            Console.Write("[1] Pokaż książki dostępne w księgarni\n[2] Wypożycz książkę\n[3] Oddaj książkę\n[4] Wyszukaj książkę po numerze unikatowym\nWybierz opcję: ");

            int decision = Convert.ToInt32(Console.ReadLine());

            DisplayMenu(decision);
        }

        static void Main(string[] args)
        {
            books.Add(new Book("Tytuł1", "Autor1", 1, 2));
            books.Add(new Book("Tytuł2", "Autor1", 2, 3));

            var Menu = new Program();
            Menu.Welcome();
        }
    }
}