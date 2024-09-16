using BookApi.Interfaces;
using BookApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;

[ApiController]
[Route("api/book")]
public class BookController : ControllerBase
{
    private readonly IBookservice _bookService;

    public BookController(IBookservice bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> Get()
    {
      return Ok(await _bookService.Get());  
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> Get(string id)
    {
        return Ok(await _bookService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(Book book)
    {
        var result = await _bookService.Create(book);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(string id, Book book)
    {
        var result = await _bookService.Update(id,book);
        if(result == null)
        {
            return BadRequest("Something Went Wrong");
        }
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _bookService.Delete(id);
        if(!result)
        {
            return BadRequest("Something Went Wrong");
        }
        return Ok(result);
    }
}
