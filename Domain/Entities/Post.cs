﻿
using Domain.Common;

namespace Domain.Entities
{
    public class Post : AudiatableEntity
    {
        
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }


        public Post()
        { 
        }

        public Post(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
    }
}
