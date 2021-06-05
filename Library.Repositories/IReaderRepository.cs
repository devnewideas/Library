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
        Task<IEnumerable<Reader>> ListAsync();
    }
}
