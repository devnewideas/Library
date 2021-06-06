// <copyright file="BaseResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Models
{
    /// <summary>
    /// This class is used to handle the baseresponse.
    /// </summary>
    public abstract class BaseResponse
    {
        /// <summary>
        /// This property will tell whether requests were completed successfully.
        /// </summary>
        public bool Success { get; protected set; }

        /// <summary>
        /// This property will have the error message if something fails.
        /// </summary>
        public string Message { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
