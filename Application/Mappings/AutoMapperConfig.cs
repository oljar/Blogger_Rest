using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
     public static class AutoMapperConfig
    {   /// <summary>
    /// Metoda Initialize ma za zadanie zwrócić implementację interfejsu IMapper. W konstruktorze
    /// za pomocą wyrażenia lambda konfigurujemy automapera.
    /// </summary>
    /// <returns></returns>
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDto>();

                cfg.CreateMap<CreatePostDto, Post>();
            
            
            })
            .CreateMapper();


    }
}
