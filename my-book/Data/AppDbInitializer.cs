using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuider)
        {
            using (var servicescope = applicationBuider.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<ApplicationDBContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Models.Book
                        {
                            CoverUrl = "www.hermanHesse.com",
                            Title = "Siddhartha",
                            Rate = 99,
                            DateAdded = DateTime.Now,
                            DateRead = DateTime.Now.AddDays(-10),
                            Description = "A book about a young boy",
                            Genre = "Spritual/Fiction",
                            IsRead = true
                        },
                        new Models.Book
                        {
                            CoverUrl = "www.Paulo.com",
                            Title = "Alchemist",
                            Rate = 219,
                            DateAdded = DateTime.Now,
                            DateRead = DateTime.Now.AddDays(-10),
                            Description = "A book about a young boy",
                            Genre = "Spritual/Fiction",
                            IsRead = true
                        }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
