using my_book.Data.Models;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Services
{
    public class BooksService
    {
        private ApplicationDBContext _context;
        public BooksService(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthor(BookViewModel book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Genre = book.Genre,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                Description = book.Description,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach(var id in book.AuthorsId)
            {
                var book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() =>_context.Books.ToList();
        public BookWithAuthorsViewModel GetBookById(int bookId)
        {
            var bookWithAuthors = _context.Books.Where(x => x.Id == bookId).Select(book => new BookWithAuthorsViewModel
            {
                Title = book.Title,
                Genre = book.Genre,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                CoverUrl = book.CoverUrl,
                Description = book.Description,
                PublisherName = book.Publisher.Name,
                AuthorsName = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();

            return bookWithAuthors;
        }

        public Book UpdateBookById(int bookid, BookViewModel book)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookid);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Genre = book.Genre;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.CoverUrl = book.CoverUrl;
                _book.DateAdded = DateTime.Now;
                _book.Description = book.Description;

                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }

    }
}
