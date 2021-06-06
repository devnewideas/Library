// <copyright file="ReaderService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.ServiceProcess
{
    using Library.Models;
    using Library.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        /// Get the reader details.
        /// </summary>
        /// <returns>Returns reader details.</returns>
        public async Task<ReaderResponse> SingleAsync(string name)
        {
            var listOfReaders = await _readerRepository.ListAsync();

            var reader = listOfReaders.Where(x => x.Name == name).Select(p => p).FirstOrDefault();

            if (reader == null)
                return new ReaderResponse("Reader not found.");

            return new ReaderResponse(reader);
        }

        /// <summary>
        /// Create a new item in reader table.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public async Task<ReaderResponse> SaveAsync(Reader reader)
        {
            try
            {
                await _readerRepository.AddAsync(reader);
                await _unitOfWork.CompleteAsync();

                return new ReaderResponse(reader);
            }
            catch (Exception ex)
            {
                return new ReaderResponse($"An error occurred when saving the reader: {ex.Message}");
            }
        }

        /// <summary>
        /// Update a reader record.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        public async Task<ReaderResponse> UpdateAsync(int id, Reader reader)
        {
            var existingReader = await _readerRepository.FindByIdAsync(id);

            if (existingReader == null)
                return new ReaderResponse("Reader not found.");

            existingReader.Name = reader.Name;
            existingReader.DOB = reader.DOB;

            try
            {
                _readerRepository.Update(existingReader);
                await _unitOfWork.CompleteAsync();

                return new ReaderResponse(existingReader);
            }
            catch (Exception ex)
            {
                return new ReaderResponse($"An error occurred when updating the reader: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a record.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReaderResponse> DeleteAsync(int id)
        {
            var existingReader = await _readerRepository.FindByIdAsync(id);

            if (existingReader == null)
                return new ReaderResponse("Reader not found.");

            try
            {
                _readerRepository.Remove(existingReader);
                await _unitOfWork.CompleteAsync();

                return new ReaderResponse(existingReader);
            }
            catch (Exception ex)
            {
                return new ReaderResponse($"An error occurred when deleting the reader: {ex.Message}");
            }
        }
    }
}
