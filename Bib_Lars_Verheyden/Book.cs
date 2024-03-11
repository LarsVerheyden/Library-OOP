using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bib_Lars_Verheyden
{
    internal class Book
    {
		private string isbnNumber;

		public string IsbnNumber
		{
			get { return isbnNumber; }
			set { isbnNumber = value; }
		}

		private string title; 

		public string Title
		{
			get { return title; }
			set 
			{ if(value == "")
				{
                    Console.WriteLine("Titel kan niet leeg zijn.");
					return;
                }
				title = value;
			 }
		}

		private string author;

		public string Author
		{
			get { return author; }
			set
            {
                if (value == "")
                {
                    Console.WriteLine("Auteur kan niet leeg zijn.");
                    return;
                }
                author = value;
            }
        }

		private int releaseYear;

		public int ReleaseYear
		{
			get { return releaseYear; }
			set { releaseYear = value; }
		}

		private Genre genre;

		public  Genre Genre
		{
			get { return genre; }
			set { genre = value; }
		}

		private double price;

		public double Price
		{
			get { return price; }	
			set
            {
                if (value < 0)
                {
                    Console.WriteLine("Prijs kan niet onder 0 zijn.");
                    return;
                }
                price = value;
            }
        }

		private string publisher;

		public string Publisher
		{
			get { return publisher; }
			set
            {
                if (value == "")
                {
                    Console.WriteLine("Uitgever kan niet leeg zijn.");
                    return;
                }
                publisher = value;
            }
        }

		private string subject = "ongeldig";

		public string Subject
		{
			get { return subject; }
			set { subject = value; }
		}

		public Book(string title, string author, Library library)
		{
			this.title = title;
			this.author = author;

			library.BookList.Add(this);
		}

		public static List<Book> BooksCsv(string filePath, Library library)
		{
			string[] rows = File.ReadAllLines(filePath);
			List<Book> books = new List<Book>();
			foreach (string row in rows)
			{
				string[] data = row.Split(",");
				books.Add(new Book(data[0], data[1], library));

			}
			return books;
		}


		public void ShowOverview()
		{
            Console.WriteLine($"ISBN nummer: {isbnNumber}");
            Console.WriteLine($"Titel: {title}");
            Console.WriteLine($"Auteur: {author}");
			Console.WriteLine($"Jaar van uitgave: {releaseYear}");
			Console.WriteLine($"Genre: {genre}");
            Console.WriteLine($"Prijs: {price}");
			Console.WriteLine($"Uitgever: {publisher}");
            Console.WriteLine($"Onderwerp: {subject}");

        }




	}
}
