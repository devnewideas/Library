// <copyright file="InvalidModelResponseFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.RestApi.Extensions
{
    using Library.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public static class InvalidModelResponseFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors);

            return new BadRequestObjectResult(response);
        }

    }
}
