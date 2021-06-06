// <copyright file="IBookService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.ServiceProcess
{
    using Library.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// This interface will be the middlelayer between service and dataaccess.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// List of readers.
        /// </summary>
        Task<QueryResult<Book>> ListAsync(BooksQuery query);

        /// <summary>
        /// This will be used to create the reader details.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<BookResponse> SaveAsync(Book book);

        /// <summary>
        /// Update the reader details.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<BookResponse> UpdateAsync(int id, Book book);

        /// <summary>
        /// Delete the reader details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BookResponse> DeleteAsync(int id);
    }
}
