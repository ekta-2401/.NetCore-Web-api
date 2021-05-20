using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Services;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorViewModel _author)
        {
            _authorService.AddAuthor(_author);
            return Ok();
        }

        [HttpGet("get-author-with-books/{authorId}")]
        public IActionResult GetAuthorWithBooks(int authorId)
        {
           var author =  _authorService.GetAuthorWithBooks(authorId);
           return Ok(author);
        }
    }
}
