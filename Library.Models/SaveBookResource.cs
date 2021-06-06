// <copyright file="SaveBookResource.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class is used to create a new reader details.
    /// </summary>
    public class SaveBookResource
    {
        /// <summary>
        /// Gets or sets title of the book.
        /// </summary>
        /// <type>string.</type>
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the international standard book number.
        /// </summary>
        /// <type>string.</type>
        [Required]
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets the checkout date of book.
        /// </summary>
        /// <type>DateTime.</type>
        public DateTime? CheckOutDate { get; set; }

        /// <summary>
        /// Gets or sets the Reader Id.
        /// </summary>
        /// <type>int.</type>
        [Required]
        public int ReaderId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets a flag value.
        /// </summary>
        /// <type>bool.</type>
        public bool Lost { get; set; }
    }
}
