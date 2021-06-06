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
    public class SaveReaderResponse : BaseResponse
    {
        /// <summary>
        /// This property is going to contain our reader data if the request successfully finishes.
        /// </summary>
        public Reader Reader { get; private set; }

        /// <summary>
        /// This constructor is used to pass the success and message parameters to the base class
        /// and also sets the reader property.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="reader"></param>
        private SaveReaderResponse(bool success, string message, Reader reader) : base(success, message)
        {
            Reader = reader;
        }

        /// <summary>
        /// This constructor that receives only the reader as a parameter.
        /// Creates a success response, calling the private constructor to set the respective properties.
        /// </summary>
        /// <param name="reader"></param>
        public SaveReaderResponse(Reader reader) : this(true, string.Empty, reader)
        { }

        /// <summary>
        /// This constructor will be used to creates a error response.
        /// </summary>
        /// <param name="message"></param>
        public SaveReaderResponse(string message) : this(false, message, null)
        { }
    }
}
