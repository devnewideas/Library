// <copyright file="BooksQuery.cs" company="PlaceholderCompany">
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
    public class BooksQuery : Query
    {
        /// <summary>
        /// 
        /// </summary>
        public int? ReaderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerId"></param>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        public BooksQuery(int? readerId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            ReaderId = readerId;
        }
    }
}
