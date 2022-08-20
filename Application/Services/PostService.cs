using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
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




        public PostDto AddNewPost(CreatePostDto newPost)
        {
            if (string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Post can not have any empty title.");
               
            }

            var post = _mapper.Map<Post>(newPost);
            _postRepository.Add(post);
            return _mapper.Map<PostDto>(post);
        }

        public void UpdatePost(UpdatePostDto updatePost)
        {
            var existingPost = _postRepository.GetById(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost);
            _postRepository.Update(post);

        }

        public void DeletePost(int id)
        {
            var post = _postRepository.GetById(id);
            _postRepository.Delete(post);
        }
    }
}
