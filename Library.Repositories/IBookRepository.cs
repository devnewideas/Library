// <copyright file="IBookRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Repositories
{
    using Library.Models;
    using System.Threading.Tasks;

    /// <summary>
    /// This interface is used to manage data from databases.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Gets list of books.
        /// </summary>
        /// <returns>Returns list of readers.</returns>
        Task<QueryResult<Book>> ListAsync(BooksQuery query);

        /// <summary>
        /// create a new record into database.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task AddAsync(Book book);

        /// <summary>
        /// Get the data based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Book> FindByIdAsync(int id);

        /// <summary>
        /// Get the data based on isbn.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Book> FindByIsbnAsync(string name);

        /// <summary>
        /// Update the record.
        /// </summary>
        /// <param name="book"></param>
        void Update(Book book);

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="book"></param>
        void Remove(Book book);
    }
}
