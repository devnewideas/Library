// <copyright file="ModelStateExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.RestApi.Extensions
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class is act as an extension class.
    /// </summary>
    public static class ModelStateExtensions
    {
        /// <summary>
        /// This method is used to extends the functionality of an already existing class or interface.
        /// It's used to convert the validation errors into simple strings to return to the client.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }
    }
}
