// <copyright file="SaveReaderResponse.cs" company="PlaceholderCompany">
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
    public class ReaderResponse : BaseResponse<Reader>
    {
        /// <summary>
        /// This constructor that receives only the reader as a parameter.
        /// Creates a success response, calling the private constructor to set the respective properties.
        /// </summary>
        /// <param name="reader"></param>
        public ReaderResponse(Reader reader) : base(reader)
        { }

        /// <summary>
        /// This constructor will be used to creates a error response.
        /// </summary>
        /// <param name="message"></param>
        public ReaderResponse(string message) : base(message)
        { }
    }
}
