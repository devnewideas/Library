// <copyright file="ResponseMapperProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Mapper
{
    using AutoMapper;
    using Library.Models;

    /// <summary>
    /// The class inherits Profile, a class type that AutoMapper uses to check how our mappings will work.
    /// </summary>
    public class ResponseMapperProfile : Profile
    {
        /// <summary>
        /// On the constructor, we create a map between the SaveReaderResource model class and the Reader class.
        /// </summary>
        public ResponseMapperProfile()
        {
            CreateMap<SaveReaderResource, Reader>();
        }
    }
}
