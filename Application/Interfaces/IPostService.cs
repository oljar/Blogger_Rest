using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{/// <summary>
/// interfejs definiuje sygnatury metod odpowiedzialnych za pobieranie wszytkich postów oraz posta o podanym identyfikatorze
/// </summary>
    public interface IPostService
    {   /// <summary>
    /// Interfejs odpowiedzialny za metodę pobierania wszystkich postów
    /// </summary>
    /// <returns></returns>
        IEnumerable<PostDto> GetAllPosts();// podmiana parametru Post na  PostDto

        /// <summary>
        /// Interfejs odpowiedzialny za metode pobierania postu o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        PostDto GetPostById(int id); // Podmiana typu z Post na PostDto



        PostDto AddNewPost(CreatePostDto post); //  Sygnatura funkcji dodania nowego posta 

        
    }
}
