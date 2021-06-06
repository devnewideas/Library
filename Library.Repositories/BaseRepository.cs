// <copyright file="BaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Repositories
{
    /// <summary>
    /// This class is just an abstract class that all our repositories will inherit. 
    /// </summary>
    public abstract class BaseRepository
    {
        /// <summary>
        /// A property that can only be accessible by the children classes.
        /// </summary>
        protected readonly AppDbContext _context;

        /// <summary>
        /// The BaseRepository receives an instance of our AppDbContext through dependency injection 
        /// and exposes a protected property called _context, that gives access to all methods 
        /// we need to handle database operations.
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
