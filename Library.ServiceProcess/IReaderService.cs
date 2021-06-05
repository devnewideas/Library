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
    }
}
