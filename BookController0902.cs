using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController0902 : ControllerBase
    {
        private readonly IBookRepo0902 _bookRepo;

        public BookController0902(IBookRepo0902 bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpPost("Add New Book")]
        public IActionResult AddNewBook([FromBody] BookModel0902 book)
        {
            _bookRepo.AddNewBook(book);
            return Ok();
        }

        [HttpPost("Add Bulk Books")]
        public IActionResult AddBulkBooks([FromBody] List<BookModel0902> books)
        {
            _bookRepo.AddBulkBooks(books);
            return Ok();
        }

        [HttpDelete("Remove Book By Id")]
        public IActionResult RemoveBookById(int id)
        {
            _bookRepo.RemoveBookById(id);
            return Ok();
        }

        [HttpGet("Get Book By Id")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookRepo.GetBookById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("Get All Books By Genre")]
        public IActionResult GetAllBooksByGenre(string genre)
        {
            var books = _bookRepo.GetAllBooksByGenre(genre);
            return Ok(books);
        }

        [HttpGet("Display Books Sorted By Price")]
        public IActionResult DisplayBooksSortedByPrice()
        {
            var books = _bookRepo.DisplayBooksSortedByPrice();
            return Ok(books);
        }

        [HttpPatch("Update Book By Id")]
        public IActionResult UpdateBookById(int id, [FromBody] JsonPatchDocument<BookModel0902> patch)
        {
            _bookRepo.UpdateBookById(id, patch);
            return Ok();
        }

        [HttpGet("Get All Authors")]
        public IActionResult GetAllAuthors()
        {
            var authors = _bookRepo.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("Get All Books By Publisher")]
        public IActionResult GetAllBooksByPublisher(string publisher)
        {
            var books = _bookRepo.GetAllBooksByPublisher(publisher);
            return Ok(books);
        }

        [HttpDelete("Remove All Books By Publisher")]
        public IActionResult RemoveAllBooksByPublisher(string publisher)
        {
            _bookRepo.RemoveAllBooksByPublisher(publisher);
            return Ok();
        }

        [HttpGet("Display Books Sorted By Year Of Publishing")]
        public IActionResult DisplayBooksSortedByYearOfPublishing()
        {
            var books = _bookRepo.DisplayBooksSortedByYearOfPublishing();
            return Ok(books);
        }
    }
}
