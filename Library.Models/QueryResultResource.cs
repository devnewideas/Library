// <copyright file="QueryResultResource.cs" company="PlaceholderCompany">
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
    public class QueryResultResource<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public List<T> BookList { get; set; } = new List<T>();
    }
}
