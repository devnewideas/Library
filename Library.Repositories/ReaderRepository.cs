// <copyright file="ReaderRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Repositories
{
    using Library.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
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
        /// This method is use the Readers  database set to access the Readers table 
        /// and then call the extension method ToListAsync which is responsible for transforming
        /// the result of a query into a collection of Readers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Reader>> ListAsync()
        {
            return await _context.Readers.ToListAsync();
        }
    }
}
