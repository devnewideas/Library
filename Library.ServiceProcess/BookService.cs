// <copyright file="BookService.cs" company="PlaceholderCompany">
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
    public class BookService : IBookService
    {

        /// <summary>
        /// Private variable for IBookRepository.
        /// </summary>
        private readonly IBookRepository _bookRepository;

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
        /// <param name="bookRepository">IBookRepository interface.</param>
        /// <param name="readerRepository">IReaderRepository interface.</param>
        /// <param name="unitOfWork">IUnitOfWork interface.</param>
        public BookService(IBookRepository bookRepository, IReaderRepository readerRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get the list of books.
        /// </summary>
        /// <returns>Returns list of books.</returns>
        public async Task<QueryResult<Book>> ListAsync(BooksQuery query)
        {
            return await _bookRepository.ListAsync(query);
        }

        /// <summary>
        /// Create a new item in book table.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<BookResponse> SaveAsync(Book book)
        {
            try
            {
                /*
                 Notice here we have to check if the reader ID is valid before adding the book, to avoid errors.
                 You can create a method into the ReaderService class to return the reader and inject the service here if you prefer, but 
                 it doesn't matter given the API scope.
                */

                var existingReader = await _readerRepository.FindByIdAsync(book.ReaderId);
                if (existingReader == null)
                    return new BookResponse("Invalid reader.");

                await _bookRepository.AddAsync(book);
                await _unitOfWork.CompleteAsync();

                return new BookResponse(book);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when saving the book: {ex.Message}");
            }
        }

        /// <summary>
        /// Update a reader record.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<BookResponse> UpdateAsync(int id, Book book)
        {
            var existingBook = await _bookRepository.FindByIdAsync(id);

            if (existingBook == null)
                return new BookResponse("Book not found.");

            var existingReader = await _readerRepository.FindByIdAsync(book.ReaderId);
            if (existingReader == null)
                return new BookResponse("Invalid reader.");

            existingBook.Title = book.Title;
            existingBook.CheckOutDate = book.CheckOutDate;
            existingBook.ISBN = book.ISBN;
            existingBook.ReaderId = book.ReaderId;
            existingBook.Lost = book.Lost;

            try
            {
                _bookRepository.Update(existingBook);
                await _unitOfWork.CompleteAsync();

                return new BookResponse(existingBook);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when updating the book: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a record.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BookResponse> DeleteAsync(int id)
        {
            var existingBook = await _bookRepository.FindByIdAsync(id);

            if (existingBook == null)
                return new BookResponse("Book not found.");

            try
            {
                _bookRepository.Remove(existingBook);
                await _unitOfWork.CompleteAsync();

                return new BookResponse(existingBook);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when deleting the reader: {ex.Message}");
            }
        }

    }
}
