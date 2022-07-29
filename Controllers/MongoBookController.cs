using bookApi.DTOs;
using bookApi.Models;
using bookApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MongoBookController : ControllerBase
    {
        private readonly MongoBookRepo _mongoBookRepo;
        public MongoBookController(MongoBookRepo mongoBookRepo)
        {
            _mongoBookRepo = mongoBookRepo;
        }

        [HttpPost]
        public ActionResult<Dictionary<string, object>> Create(BookDto bookDto)
        {
            Dictionary<string, object> response = new();
            try
            {
                mBook book = new(){
                    AuthorName = bookDto.AuthorName,
                    Name = bookDto.Name,
                    DateCreated = DateTime.Now
                };
                _mongoBookRepo.Create(book);
                response.Add("data", book);
                response.Add("message", "Book added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.Add("error", "An error has occurred.");
            }
            return response;
        }
        
        [HttpGet]
        public ActionResult<Dictionary<string, object>> GetById(string Id)
        {
            Dictionary<string, object> response = new();
            try
            {
                mBook book = _mongoBookRepo.Get(x => x.Id == Id);
                response.Add("data", book);
                response.Add("message", "Book fetched successfully");
            }
            catch (Exception)
            {
                response.Add("error", "An error has occurred.");
            }
            return response;
        }

        [HttpPut("{Id}")]
        public ActionResult<Dictionary<string, object>> Update(string Id, BookDto bookDto)
        {
            Dictionary<string, object> response = new();
            mBook book = _mongoBookRepo.Get(x => x.Id == Id);
            if(book == null) response.Add("message", $"No Book with {Id}");
            try
            {
                mBook newBook = new(){
                    Id = book.Id,
                    Name = bookDto.Name,
                    AuthorName = bookDto.AuthorName,
                    DateCreated = book.DateCreated,
                    DateUpdated = DateTime.Now
                };
                _mongoBookRepo.Update(x => x.Id == Id, newBook);
                response.Add("message", "Book updated successfully");
            }
            catch (Exception ex)
            {
                response.Add("error", ex.ToString());
            }
            return response;
        }

        [HttpDelete("{Id}")]
        public ActionResult<Dictionary<string, object>> Delete(string Id)
        {
            Dictionary<string, object> response = new();
            mBook book = _mongoBookRepo.Get(x => x.Id == Id);
            if(book == null) response.Add("message", $"No Book with {Id}");
            try
            {
                _mongoBookRepo.Remove(x => x.Id == Id);
                response.Add("message", "Book deleted successfully");
            }
            catch (Exception)
            {
                response.Add("error", "An error has occurred.");
            }
            return response;
        }

    }
}