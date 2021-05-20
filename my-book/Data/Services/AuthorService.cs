using my_book.Data.Models;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Services
{
    public class AuthorService
    {
        private ApplicationDBContext _context;
        public AuthorService(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorViewModel author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksViewModel GetAuthorWithBooks(int authorId)
        {
            return _context.Authors.Where(x => x.Id == authorId).Select(n => new AuthorWithBooksViewModel
            {
                FullName = n.FullName,
                BooksTitles = n.Book_Authors.Select(k => k.Book.Title).ToList()
            }).FirstOrDefault();
            
        }
    }
}
