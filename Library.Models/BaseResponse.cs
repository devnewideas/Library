// <copyright file="BaseResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    /// <summary>
    /// This class is used to handle the baseresponse.
    /// </summary>
    public abstract class BaseResponse<T>
    {
        /// <summary>
        /// This property will tell whether requests were completed successfully.
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// This property will have the error message if something fails.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// pass the resource dynamically at runtime.
        /// </summary>
        public T Resource { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        protected BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        protected BaseResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}
