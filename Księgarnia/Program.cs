using System;
using System.Linq;
using ProjektLibrary;

namespace Projekt
{
    internal class Program
    {
        // lista wszystkich książek
        public static List<Book> books = new List<Book>();
        // menu główne
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
        // wyświetlenie informacji o wszystkich książkach
        public void DisplayBooks()
        {
            Console.Clear();
            foreach (var book in books)
            {
                book.BookInfo();
            }
            Welcome();
        }
        // wypożyczenie książki
        public void BorrowBooks()
        {
            Console.Clear();
            Console.Write("Jaką książkę chcesz wypożyczyć? Podaj tytuł: ");
            string bookToBorrow = Console.ReadLine();
            try
            {
                // bookTB = bookToBorrow = książka do wypożyczneia
                // books = lista wszystkich książek
                // bookTB.title = tytuł książki do wypożyczenia
                // .Distinct() = bez powtórzeń - może być kilka sztuk tej samej książki
                var bookQuery = (from bookTB in books where bookTB.title == bookToBorrow select bookTB).Distinct();
                // jeśli nie znajdzie żadnej książki to zwraca odpowiedni komunikat i wraca do menu głównego
                if(bookQuery.Count() <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Nie ma takiej książki");
                    Welcome();
                } else
                {
                    // jeśli znajdzie książkę, to ją wypożycza - zmniejsza ilość dostępnych książek o 1
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
                // każdy inny błąd zwraca z odpowiednim komunikatem
                Console.Clear();
                Console.WriteLine("Nie ma takiej książki");
                Welcome();
            }
        }
        // zwrot książki
        public void ReturnBooks()
        {
            // książkę oddajemy po tytule, np. Tytuł1
            Console.Clear();
            Console.Write("Jaką książkę chcesz oddać? Podaj tytuł: ");
            string bookToReturn = Console.ReadLine();
            try
            {
                // bookTR = bookToReturn = książka do zwrotu
                // books = lista książek
                // bookTR.title = tytuł książki do zwrotu 
                // .Distinct() = bez powtórzeń 
                var bookQuery = (from bookTR in books where bookTR.title == bookToReturn select bookTR).Distinct();
                // jeśli nie znajdzie takiego tytułu to zwraca odpowiedni komunikat i wraca do menu głównego
                if (bookQuery.Count() <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Nie ma posiadamy takiej książki w rejestrze");
                    Welcome();
                }
                else
                {
                    // jeśli znajdzie książkę to zwiększa dostępną ilość o 1 i wraca do menu głównego
                    Console.Clear();
                    foreach (var item in bookQuery)
                    {
                        item.ReturnBook();
                    }
                    Welcome();
                }
            } catch (Exception)
            {
                // każdy inny błąd zwaraca odpowiedni komunikat i wraca do menu głównego
                Console.Clear();
                Console.WriteLine("Nie ma posiadamy takiej książki w rejestrze");
                Welcome();
            }
        }
        // wyszukiwanie książek w rejestrze - przeszukuje listę books
        public void SearchBooks()
        {
            // wyszukuje po numerze unikatowym - ID książki
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
                // wyświetla autora, tytuł i dostępną ilość książek o podanym id
                Console.Clear();
                foreach (var item in bookQuery)
                {
                    item.BookInfo(id);
                }
                Welcome();
            }
        }
        // wyświetla menu główne - opcje 1,2,3,4 i przekazuje do funkcji DisplayMenu()
        public void Welcome()
        {
            Console.Write("[1] Pokaż książki dostępne w księgarni\n[2] Wypożycz książkę\n[3] Oddaj książkę\n[4] Wyszukaj książkę po numerze unikatowym\nWybierz opcję: ");

            int decision = Convert.ToInt32(Console.ReadLine());

            DisplayMenu(decision);
        }
        static void Main(string[] args)
        {
            // towrzy i dodaje książki do listy books
            // Book("tytuł", "autor", id, ilość)
            books.Add(new Book("Tytuł1", "Autor1", 1, 2));
            books.Add(new Book("Tytuł2", "Autor1", 2, 3));

            var Menu = new Program();
            Menu.Welcome();
        }
    }
}