// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    using System;

    /// <summary>
    /// This Model class is used to declare the properties for book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets identity Value.
        /// </summary>
        /// <type>int.</type>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        /// <type>string.</type>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the international standard book number.
        /// </summary>
        /// <type>string.</type>
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets the checkout date of book.
        /// </summary>
        /// <type>DateTime.</type>
        public DateTime? CheckOutDate { get; set; }

        /// <summary>
        /// Gets or sets the Reader Object.
        /// </summary>
        /// <type>Reader.</type>
        public Reader Reader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets a flag value.
        /// </summary>
        /// <type>bool.</type>
        public bool Lost { get; set; }
    }
}
