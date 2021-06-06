// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.RestApi.Controllers
{
    using AutoMapper;
    using Library.Models;
    using Library.ServiceProcess;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    /// <summary>
    /// This controller is used to trigger the CRUD operations.
    /// </summary>
    [Route("api/books")]
    [Produces("application/json")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookService"></param>
        /// <param name="mapper"></param>
        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existing books.
        /// </summary>
        /// <returns>List of books.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<BookResource>), 200)]
        public async Task<QueryResultResource<BookResource>> ListAsync([FromQuery] BooksQueryResource query)
        {
            var booksQuery = _mapper.Map<BooksQueryResource, BooksQuery>(query);
            var queryResult = await _bookService.ListAsync(booksQuery);

            var resource = _mapper.Map<QueryResult<Book>, QueryResultResource<BookResource>>(queryResult);
            return resource;
        }

        /// <summary>
        /// Saves a new book.
        /// </summary>
        /// <param name="resource">book data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BookResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveBookResource resource)
        {
            var book = _mapper.Map<SaveBookResource, Book>(resource);
            var result = await _bookService.SaveAsync(book);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bookResource = _mapper.Map<Book, BookResource>(result.Resource);
            return Ok(bookResource);
        }

        /// <summary>
        /// Updates an existing book according to an identifier.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <param name="resource">Book data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BookResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBookResource resource)
        {
            var book = _mapper.Map<SaveBookResource, Book>(resource);
            var result = await _bookService.UpdateAsync(id, book);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var productResource = _mapper.Map<Book, BookResource>(result.Resource);
            return Ok(productResource);
        }

        /// <summary>
        /// Deletes a given book according to an identifier.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BookResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _bookService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Book, BookResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}
