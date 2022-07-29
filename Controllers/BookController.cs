using bookApi.DTOs;
using bookApi.Models;
using bookApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookRepo _bookRepo;
    public BookController(BookRepo bookRepo)
    {
        _bookRepo = bookRepo;
    }

    [HttpPost]
    public ActionResult<Dictionary<string, object>> Create(BookDto bookDto)
    {
        Dictionary<string, object> response = new();
        try
        {
            Book book = new(){
                AuthorName = bookDto.AuthorName,
                Name = bookDto.Name,
                DateCreated = DateTime.Now
            };
            _bookRepo.Create(book);
            _bookRepo.Save();
            response.Add("data", book);
            response.Add("message", "Book added successfully");
        }
        catch (Exception)
        {
            response.Add("error", "An error has occurred.");
        }
        return response;
    }

    [HttpGet]
    public ActionResult<Dictionary<string, object>> GetById(int Id)
    {
        Dictionary<string, object> response = new();
        try
        {
            Book book = _bookRepo.Get(Id);
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
    public ActionResult<Dictionary<string, object>> Update(int Id, BookDto bookDto)
    {
        Dictionary<string, object> response = new();
        Book book = _bookRepo.Get(Id);
        if(book == null) response.Add("message", $"No Book with {Id}");
        try
        {
            Book newBook = new(){
                Id = book.Id,
                Name = bookDto.Name,
                AuthorName = bookDto.AuthorName,
                DateCreated = book.DateCreated,
                DateUpdated = DateTime.Now
            };
            _bookRepo.Update(newBook);
            _bookRepo.Save();
            response.Add("message", "Book updated successfully");
        }
        catch (Exception ex)
        {
            response.Add("error", ex.ToString());
        }
        return response;
    }

    [HttpDelete("{Id}")]
    public ActionResult<Dictionary<string, object>> Delete(int Id)
    {
        Dictionary<string, object> response = new();
        Book book = _bookRepo.Get(Id);
        if(book == null) response.Add("message", $"No Book with {Id}");
        try
        {
            _bookRepo.Delete(book);
            _bookRepo.Save();
            response.Add("message", "Book deleted successfully");
        }
        catch (Exception)
        {
            response.Add("error", "An error has occurred.");
        }
        return response;
    }
}
