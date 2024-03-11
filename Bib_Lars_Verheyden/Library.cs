using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Lars_Verheyden
{
    internal class Library
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private List<Book> bookList = new List<Book>();

		public List<Book> BookList
		{
			get { return bookList; }
			set { bookList = value; }
		}

		public Library(string name)
		{
			this.name = name;
		}

		public void BookRemove(string isbn)
		{
			Book? book = bookList.Find(book => book.IsbnNumber == isbn);
			if (book is not null) bookList.Remove(book);

		}
		
		public Book? BookFinder(string author, string title)
		{
            Book? book = bookList.Find(book => book.Author.ToLower() == author.ToLower() && book.Title.ToLower() == title.ToLower());

			return book;
        }

		public Book? IsbnFinder(string isbn)
		{
            Book? book = bookList.Find(book => book.IsbnNumber == isbn);

			return book;
        }
		public List<Book> AuthorFinder(string author)
		{
			List<Book> listBook = bookList.FindAll(book => book.Author.ToLower() == author.ToLower());

			return listBook;

        }

		public List<Book> SubjectFilter(string subject)
		{
			List<Book> bookSubject = bookList.FindAll(book =>book.Subject.ToLower() == subject.ToLower());

			return bookSubject;
		}
	}
}
