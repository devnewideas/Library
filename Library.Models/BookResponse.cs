// <copyright file="BookResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class BookResponse : BaseResponse<Book>
    {
        /// <summary>
        /// This constructor that receives only the book as a parameter.
        /// Creates a success response, calling the private constructor to set the respective properties.
        /// </summary>
        /// <param name="book"></param>
        public BookResponse(Book book) : base(book)
        { }

        /// <summary>
        /// This constructor will be used to creates a error response.
        /// </summary>
        /// <param name="message"></param>
        public BookResponse(string message) : base(message)
        { }
    }
}
