using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Domain.Interfaces
{
    public  interface IPostRepository
    {
        
        /// <summary>
        /// Metoda odpowiedzialna za pobieranie wszystkich postów
        /// </summary>
        /// <returns></returns>
        IEnumerable<Post> GetAll(); 
        
        
        /// <summary>
        /// Metoda odpowiedzialna za pobranie posta o podanym identyfikatorze id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        Post GetById (int id);


        /// <summary>
        /// Metoda odpowiedzialna za dodanie nowego posta
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>

        Post Add(Post post);


        /// <summary>
        /// Metoda odpowiedzialna za edycję posta
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        void Update(Post post);

        /// <summary>
        /// Metoda odpowiedzialna za usnnięcie
        /// </summary>
        /// <param name="post"></param>
        void Delete(Post post);

        
    }
    
}
