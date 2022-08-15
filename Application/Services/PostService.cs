using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;   // dodać pole prywatne
       
        public PostService(IPostRepository postRepository, IMapper mapper)  //należy dodać drugi parametr IMapper
        { 
            _postRepository = postRepository;
            _mapper = mapper;       //  tworzymy pole w kostruktorze o typie IMapper


        }
        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
       
        }

        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
            return _mapper.Map<PostDto>(post); 
            // wywołuję metodę Map z interfejsu IMapper - Typ zwrócony PostDto, argument  metody zmienna post


        }
    }
}
