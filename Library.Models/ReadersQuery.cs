// <copyright file="ReadersQuery.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ReadersQuery : Query
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        public ReadersQuery(string name, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            Name = name;
        }
    }
}
