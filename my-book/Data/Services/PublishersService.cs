using my_book.Data.Models;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Services
{
    public class PublishersService
    {
        private ApplicationDBContext _context;
        public PublishersService(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherViewModel publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsViewModel GetPublisherData(int publisherId)
        {
            var publisherData = _context.Publishers.Where(x => x.Id == publisherId).
                Select(n => new PublisherWithBooksAndAuthorsViewModel
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthViewModel
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);
            if(publisher!= null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
            
        }
    }
}
