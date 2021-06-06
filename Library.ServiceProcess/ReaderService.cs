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
        /// Private variable for IUnitOfWork.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="readerRepository">IReaderRepository interface.</param>
        /// <param name="unitOfWork">IUnitOfWork interface.</param>
        public ReaderService(IReaderRepository readerRepository, IUnitOfWork unitOfWork)
        {
            _readerRepository = readerRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get the list of readers.
        /// </summary>
        /// <returns>Returns list of readers.</returns>
        public async Task<IEnumerable<Reader>> ListAsync()
        {
            return await _readerRepository.ListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public async Task<SaveReaderResponse> SaveAsync(Reader reader)
        {
            try
            {
                await _readerRepository.AddAsync(reader);
                await _unitOfWork.CompleteAsync();

                return new SaveReaderResponse(reader);
            }
            catch (Exception ex)
            {
                return new SaveReaderResponse($"An error occurred when saving the reader: {ex.Message}");
            }
        }
    }
}
