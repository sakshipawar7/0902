using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WebApplication1.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace WebApplication1.Repository
{
    public interface IBookRepo0902
    {
        void AddNewBook(BookModel0902 book);
        void AddBulkBooks(List<BookModel0902> b);
        void RemoveBookById(int id);
        BookModel0902 GetBookById(int id);
        List<BookModel0902> GetAllBooksByGenre(string genre);
        List<BookModel0902> DisplayBooksSortedByPrice();
        void UpdateBookById(int bookId, JsonPatchDocument<BookModel0902> patch);
        IEnumerable<string> GetAllAuthors();
        List<BookModel0902> GetAllBooksByPublisher(string publisher);
        void RemoveAllBooksByPublisher(string publisher);
        List<BookModel0902> DisplayBooksSortedByYearOfPublishing();
    }
    public class BookRepo0902 : IBookRepo0902
    {
        private readonly string _filePath = @"C:\Users\Admin\source\repos\WebApplication1\WebApplication1\book.json";
        private List<BookModel0902> LoadBooks()
        {
            if(File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<BookModel0902>>(json) ?? new List<BookModel0902>();
            }
            return new List<BookModel0902>();
        }

        private void SaveBooks(List<BookModel0902> books)
        {
            var json = JsonSerializer.Serialize(books);
            File.WriteAllText(_filePath, json);
        }

        public void AddNewBook(BookModel0902 book)
        {
            var books = LoadBooks();
            books.Add(book);
            SaveBooks(books);
        }

        public void AddBulkBooks(List<BookModel0902> b)
        {
            var books = LoadBooks();
            foreach(var book in b)
            {
                books.Add(book);
            }
            SaveBooks(books);
        }
        
        public void RemoveBookById(int id)
        {
            var books = LoadBooks();
            for(int i = 0; i < books.Count; i++)
            {
                if (books[i].BookId == id)
                {
                    books.Remove(books[i]);
                    break;
                }
            }
            SaveBooks(books);
        }

        public BookModel0902 GetBookById(int id)
        {
            var books = LoadBooks();
            foreach(var book in books)
            {
                if (book.BookId == id)
                    return book;
            }
            return null;
        }

        public List<BookModel0902> GetAllBooksByGenre(string genre)
        {
            var books = LoadBooks();
            List<BookModel0902> result = new List<BookModel0902>();
            foreach(var book in books)
            {
                if(book.Genre == genre)
                {
                    result.Add(book);
                }
            }
            return result;
        }

        public List<BookModel0902> DisplayBooksSortedByPrice()
        {
            var books = LoadBooks();
            books.Sort((x, y) => x.Price.CompareTo(y.Price));
            return books;
        }

        public void UpdateBookById(int bookId, JsonPatchDocument<BookModel0902> patch)
        {
            var books = LoadBooks();
            for(int i = 0;i < books.Count;i++)
            {
                if (books[i].BookId == bookId)
                {
                    patch.ApplyTo(books[i]);
                    SaveBooks(books);
                    return;
                }
            }
        }

        public IEnumerable<string> GetAllAuthors()
        {
            var books = LoadBooks();
            var authors = new HashSet<string>();
            foreach(var book in books)
            {
                authors.Add(book.Author);
            }
            return authors;
        }

        public List<BookModel0902> GetAllBooksByPublisher(string publisher)
        {
            var books = LoadBooks();
            var result = new List<BookModel0902>();
            foreach(var book in books)
            {
                if (book.Publisher == publisher)
                    result.Add(book);
            }
            return result;
        }

        public void RemoveAllBooksByPublisher(string publisher)
        {
            var books = LoadBooks();
            for(int i = 0; i < books.Count; i++)
            {
                if (books[i].Publisher == publisher)
                    books.Remove(books[i]);
            }
            SaveBooks(books);
        }

        public List<BookModel0902> DisplayBooksSortedByYearOfPublishing()
        {
            var books = LoadBooks();
            books.Sort((x, y) => x.YearOfPublishing.CompareTo(y.YearOfPublishing));
            return books;
        }
    }
}
