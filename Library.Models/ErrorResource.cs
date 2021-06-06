// <copyright file="ErrorResource.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class ErrorResource
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Success => false;
        
        /// <summary>
        /// 
        /// </summary>
        public List<string> Messages { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages"></param>
        public ErrorResource(List<string> messages)
        {
            this.Messages = messages ?? new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ErrorResource(string message)
        {
            this.Messages = new List<string>();

            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Messages.Add(message);
            }
        }
    }
}
