﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public bool IsRead { get; set; }

        public int PublisherId { get; set; }
        public List<int> AuthorsId { get; set; }
    }
    public class BookWithAuthorsViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public bool IsRead { get; set; }

        public string PublisherName { get; set; }
        public List<string> AuthorsName { get; set; }
    }
}