// <copyright file="QueryResultResource.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class QueryResultResource<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();
    }
}
