// <copyright file="Reader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    using System;

    /// <summary>
    /// This Model class is used to declare the properties for reader.
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// Gets or sets identity Value.
        /// </summary>
        /// <type>int.</type>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of the reader.
        /// </summary>
        /// <type>string.</type>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets date of birth.
        /// </summary>
        /// <type>DateTime.</type>
        public DateTime DOB { get; set; }
    }
}
