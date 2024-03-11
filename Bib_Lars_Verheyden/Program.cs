using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;
namespace Bib_Lars_Verheyden
{
    internal class Program
    {
        public static void Main()
        {
            Library library = new Library("Bookworld");
            Book.BooksCsv(@"C:\Users\s136636\Desktop\OO Programmeren\Bib_Lars_Verheyden\Books.csv", library);

            bool exit = false;
            while (!exit)
            {
                exit = ShowMenu(library);
            }
            Console.WriteLine("Tot volgende keer!");
        }

        private static bool ShowMenu(Library library)
        {
            Console.WriteLine($"Welkom bij {library.Name}!");
            Console.WriteLine("Wat wilt u doen?\n");

            Console.WriteLine("1. Boek toevoegen.");
            Console.WriteLine("2. Informatie toevoegen.");
            Console.WriteLine("3. Geef alle info van een boek weer op basis van titel en auteur.");
            Console.WriteLine("4. Zoek boek(en).");
            Console.WriteLine("5. Verwijder boek");
            Console.WriteLine("6. Toon het hele aanbod.");

            Console.WriteLine("\n Type 'exit' om te stoppen.");

            string value = Console.ReadLine();
            if (value.ToLower() == "exit")
            {
                return true;
            }

            int choice = Convert.ToInt32(value);
            switch (choice)
            {
                case 1:
                    AddBook(library);
                    break;

                case 2:
                    AddInfoToBook(library);
                    break;
                case 3:
                    FindBook(library).ShowOverview();
                    break;
                case 4:
                    SearchBook(library);
                    break;
                case 5:
                    Console.WriteLine("Wat is het ISBN?");
                    library.BookRemove(Console.ReadLine());
                    break;
                case 6:
                    foreach (Book book in library.BookList)
                    {
                        Console.WriteLine($"Titel: {book.Title} \nAuteur: {book.Author}\n");
                    }
                    break;
                default:
                    Console.WriteLine("Geen geldige keuze.");
                    break;
            }
            return false;
        }
        private static void AddBook(Library library)
        {
            Console.WriteLine("Titel: ");
            string title = Console.ReadLine();
            Console.WriteLine("Auteur: ");
            string author = Console.ReadLine();

            Book book = new Book(title, author, library);

            Console.WriteLine("Boek toegevoegd!");

        }
         private static Book FindBook(Library library)
        {
            Console.WriteLine("Titel: ");
            string title = Console.ReadLine();
            Console.WriteLine("Auteur: ");
            string author = Console.ReadLine();

            return library.BookFinder(author, title);
        }

        private static void AddInfoToBook(Library library)
        {
            Book book = FindBook(library);

            Console.WriteLine("Wat wilt u toevoegen?");
            Console.WriteLine("1. Isbn");
            Console.WriteLine("2. Genre");
            Console.WriteLine("3. Onderwerp");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("ISBN: ");
                    string isbn = Console.ReadLine();
                    book.IsbnNumber = isbn;
                    return;
                case "2":
                    Console.WriteLine("Genre: ");
                    Genre genre = Enum.Parse<Genre>(Console.ReadLine());
                    book.Genre = genre;
                    return;
                case "3":
                    Console.WriteLine("Onderwerp: ");
                    string subject = Console.ReadLine();
                    book.Subject = subject;
                    return;
                default:
                    Console.WriteLine("Niet geldig.");
                    break;
            }
        }

        private static void SearchBook(Library library)
        {
            Console.WriteLine("Met welke info wilt u zoeken?");
            Console.WriteLine("1. ISBN");
            Console.WriteLine("2. Auteur");
            Console.WriteLine("3. Onderwerp");
            
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("ISBN: ");
                    string isbn = Console.ReadLine();
                    Book bookIsbn = library.IsbnFinder(isbn);
                    Console.WriteLine($"Titel: {bookIsbn.Title} \nAuteur: {bookIsbn.Author}");
                    return;
                case "2":
                    Console.WriteLine("Auteur: ");
                    string author = Console.ReadLine();
                    List<Book> booksAuthor = library.AuthorFinder(author);
                    foreach (Book book in booksAuthor)
                    {
                        Console.WriteLine($"Titel: {book.Title} \nAuteur: {book.Author}");
                    }
                    return;
                case "3":
                    Console.WriteLine("Onderwerp: ");
                    string subject = Console.ReadLine();
                    List<Book> booksSubject = library.SubjectFilter(subject);
                    foreach (Book book in booksSubject)
                    {
                        Console.WriteLine($"Titel: {book.Title} \nAuteur: {book.Author}");
                    }
                    return;
                default:
                    Console.WriteLine("Geen geldige keuze.");
                    break;

            }
        }
    }
}
