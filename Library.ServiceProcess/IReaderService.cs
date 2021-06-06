// <copyright file="IReaderService.cs" company="PlaceholderCompany">
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
    public interface IReaderService
    {
        /// <summary>
        /// List of readers.
        /// </summary>
        Task<IEnumerable<Reader>> ListAsync();

        /// <summary>
        /// This will be used to create the reader details.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        Task<SaveReaderResponse> SaveAsync(Reader reader);

        /// <summary>
        /// Update the reader details.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        Task<SaveReaderResponse> UpdateAsync(int id, Reader reader);
    }
}
