// <copyright file="ReaderService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.ServiceProcess
{
    using Library.Models;
    using Library.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class is used to act as a middlelayer between api and dataaccess.
    /// </summary>
    public class ReaderService : IReaderService
    {

        /// <summary>
        /// Private variable for IReaderRepository.
        /// </summary>
        private readonly IReaderRepository _readerRepository;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="readerRepository">IReaderRepository interface.</param>
        public ReaderService(IReaderRepository readerRepository)
        {
            this._readerRepository = readerRepository;
        }

        /// <summary>
        /// Get the list of readers.
        /// </summary>
        /// <returns>Returns list of readers.</returns>
        public async Task<IEnumerable<Reader>> ListAsync()
        {
            return await _readerRepository.ListAsync();
        }
    }
}
