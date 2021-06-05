// <copyright file="ReadersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.RestApi.Controllers
{
    using Library.Models;
    using Library.ServiceProcess;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// This controller is used to trigger the CRUD operations.
    /// </summary>
    [Route("api/readers")]
    [Produces("application/json")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        /// <summary>
        /// Declare private variable.
        /// </summary>
        private readonly IReaderService _readerService;

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="readerService">IReaderService interface</param>
        public ReadersController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        /// <summary>
        /// Read the list of readers.
        /// </summary>
        /// <returns>Returns list of readers.</returns>
        [HttpGet]
        public async Task<IEnumerable<Reader>> GetAllAsync()
        {
            var readers = await _readerService.ListAsync();
            return readers;
        }

    }
}
