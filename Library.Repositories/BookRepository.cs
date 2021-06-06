// <copyright file="BookRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Repositories
{
    using Library.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// This class repository inherits the BaseRepository
    /// and implements IBookRepository.
    /// </summary>
    public class BookRepository : BaseRepository, IBookRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// This method is use the books database set to access the books table 
        /// and then call the extension method ToListAsync which is responsible for transforming
        /// the result of a query into a collection of books.
        /// </summary>
        /// <returns></returns>
        public async Task<QueryResult<Book>> ListAsync(BooksQuery query)
        {
            IQueryable<Book> queryable = _context.Books
                                                    .Include(p => p.Reader)
                                                    .AsNoTracking();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
            if (query.ReaderId.HasValue && query.ReaderId > 0)
            {
                queryable = queryable.Where(p => p.ReaderId == query.ReaderId);
            }

            // Here I count all items present in the database for the given query, to return as part of the pagination data.
            int totalItems = await queryable.CountAsync();

            // Here I apply a simple calculation to skip a given number of items, according to the current page and amount of items per page,
            // and them I return only the amount of desired items. The methods "Skip" and "Take" do the trick here.
            List<Book> books = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();

            // Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
            return new QueryResult<Book>
            {
                Items = books,
            };
        }

        /// <summary>
        /// This method is used to create a new record into books database.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        /// <summary>
        /// This will asynchronously return a book from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Book> FindByIdAsync(int id)
        {
            return await _context.Books
                                 .Include(p => p.Reader)
                                 .FirstOrDefaultAsync(p => p.Id == id); // Since Include changes the method's return type, we can't use FindAsync
        }

        /// <summary>
        /// This will be used to update the book into the database.
        /// </summary>
        /// <param name="book"></param>
        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

        /// <summary>
        /// This will be used to delete the book details from database.
        /// </summary>
        /// <param name="book"></param>
        public void Remove(Book book)
        {
            _context.Books.Remove(book);
        }
    }
}
