// <copyright file="ReaderRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Repositories
{
    using Library.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class repository inherits the BaseRepository
    /// and implements IReaderRepository.
    /// </summary>
    public class ReaderRepository : BaseRepository, IReaderRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ReaderRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// This method is use the Readers database set to access the Readers table 
        /// and then call the extension method ToListAsync which is responsible for transforming
        /// the result of a query into a collection of Readers.
        /// </summary>
        /// <returns></returns>
        public async Task<QueryResult<Reader>> ListAsync(ReadersQuery query)
        {
            IQueryable<Reader> queryable = _context.Readers
                                                    .Select(p=>p)
                                                    .AsNoTracking();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
            if (!string.IsNullOrEmpty(query.Name))
            {
                queryable = queryable.Where(p => p.Name == query.Name);
            }

            // Here I apply a simple calculation to skip a given number of items, according to the current page and amount of items per page,
            // and them I return only the amount of desired items. The methods "Skip" and "Take" do the trick here.
            List<Reader> readers = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();

            // Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
            return new QueryResult<Reader>
            {
                Items = readers,
            };
        }

        /// <summary>
        /// This method is used to create a new record into readers database.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public async Task AddAsync(Reader reader)
        {
            await _context.Readers.AddAsync(reader);
        }

        /// <summary>
        /// This will asynchronously return a reader from the database.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Reader> FindByNameAsync(string name)
        {
            return await _context.Readers
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        /// <summary>
        /// This will asynchronously return a reader from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Reader> FindByIdAsync(int id)
        {
            return await _context.Readers.FindAsync(id);
        }

        /// <summary>
        /// This will be used to update the reader into the database.
        /// </summary>
        /// <param name="reader"></param>
        public void Update(Reader reader)
        {
            _context.Readers.Update(reader);
        }

        /// <summary>
        /// This will be used to delete the reader details from database.
        /// </summary>
        /// <param name="reader"></param>
        public void Remove(Reader reader)
        {
            _context.Readers.Remove(reader);
        }
    }
}
