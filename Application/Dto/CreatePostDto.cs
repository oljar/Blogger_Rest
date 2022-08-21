using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public  class CreatePostDto : IMap

    {
        public string Title { get; set; }

        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostDto, Post>();
        }
    }
}
