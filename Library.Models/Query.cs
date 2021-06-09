// <copyright file="Query.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Query
    {
        /// <summary>
        /// 
        /// </summary>
        public int Page { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public int ItemsPerPage { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        public Query(int page, int itemsPerPage)
        {
            Page = page;
            ItemsPerPage = itemsPerPage;

            if (Page <= 0)
            {
                Page = 1;
            }

            if (ItemsPerPage <= 0)
            {
                ItemsPerPage = 2;
            }
        }
    }
}
