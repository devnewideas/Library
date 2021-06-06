// <copyright file="ReadersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.RestApi.Controllers
{
    using AutoMapper;
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
        /// Declare private variable for reader interface.
        /// </summary>
        private readonly IReaderService _readerService;

        /// <summary>
        /// Declare private variable for mapper interface.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="readerService">IReaderService interface</param>
        /// <param name="mapper">IMapper interface</param>
        public ReadersController(IReaderService readerService, IMapper mapper)
        {
            _readerService = readerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Read the list of readers.
        /// </summary>
        /// <returns>Returns list of readers.</returns>
        [HttpGet]
        public async Task<IEnumerable<ReaderResource>> GetAllAsync()
        {
            var readers = await _readerService.ListAsync();
            
            var resources = _mapper.Map<IEnumerable<Library.Models.Reader>, IEnumerable<Library.Models.ReaderResource>>(readers);
            
            return resources;
        }

    }
}
