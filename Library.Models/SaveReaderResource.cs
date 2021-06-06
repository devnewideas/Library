// <copyright file="SaveReaderResource.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class is used to create a new reader details.
    /// </summary>
    public class SaveReaderResource
    {
        /// <summary>
        /// Gets or sets name of the reader.
        /// </summary>
        /// <type>string.</type>
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets date of birth.
        /// </summary>
        /// <type>DateTime.</type>
        [Required]
        public DateTime DOB { get; set; }
    }
}
