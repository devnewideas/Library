// <copyright file="RequestMapperProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Mapper
{
    using AutoMapper;
    using Library.Models;
    using System;

    /// <summary>
    /// The class inherits Profile, a class type that AutoMapper uses to check how our mappings will work.
    /// </summary>
    public class RequestMapperProfile : Profile
    {
        /// <summary>
        /// On the constructor, we create a map between the Reader model class and the ReaderResource class
        /// </summary>
        public RequestMapperProfile()
        {
            CreateMap<Reader, ReaderResource>();
        }
    }
}
