// <copyright file="IReaderRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Repositories
{
    using Library.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This interface is used to manage data from databases.
    /// </summary>
    public interface IReaderRepository
    {
        /// <summary>
        /// Gets list of readers.
        /// </summary>
        /// <returns>Returns list of readers.</returns>
        Task<QueryResult<Reader>> ListAsync(ReadersQuery query);

        /// <summary>
        /// create a new record into database.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        Task AddAsync(Reader reader);

        /// <summary>
        /// Get the data based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Reader> FindByIdAsync(int id);

        /// <summary>
        /// Get the data based on name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Reader> FindByNameAsync(string name);

        /// <summary>
        /// Update the record.
        /// </summary>
        /// <param name="reader"></param>
        void Update(Reader reader);

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="reader"></param>
        void Remove(Reader reader);
    }
}
