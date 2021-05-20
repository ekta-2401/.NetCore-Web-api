using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.ViewModels
{
    public class PublisherViewModel
    {
        public string Name { get; set; }
    }
    public class PublisherWithBooksAndAuthorsViewModel
    {
        public string Name { get; set; }
        public List<BookAuthViewModel> BookAuthors { get; set; }
    }

    public class BookAuthViewModel
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }

    }
}
