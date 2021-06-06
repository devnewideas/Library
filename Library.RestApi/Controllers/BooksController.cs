// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.RestApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This controller is used to trigger the CRUD operations.
    /// </summary>
    [Route("api/books")]
    [Produces("application/json")]
    [ApiController]
    public class BooksController : ControllerBase
    {
    }
}
