***Aktualizacja zasobu - metoda Put***
1.  W interfejsie IPostService doda� sygnatur� metody UpdatePost odpowiedzialn� za zaktualizowanie posta.
    {
        {
	        void UpdatePost();
        }
    }

2.  W folderze Dto doda� now� klas� UpdatePostDto
    Nie b�dzie mo�na zaktualizowa� tytu�u - tylko tre��
    
    {
        public class UpdatePostDto
    
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }
    }

3. W  sygnaturze metody UpdatePost doda�  parametr UpdatePostDto updatePost
     {  
        {   
             void UpdatePost(UpdatePostDto updatePost);
        }
     }
4. Przej��  do konfiguracji Automapera. 

Utwo�y� map� dla UpdatePostDto i zmaowa� ten typ na Post
    {
        {
            cfg.CreateMap<UpdatePostDto, Post>();
        }
    }
5. Przej��  do klasy PostService i implementowa� metod� UpdatePost
W tej metodzie utworzy� zmienn� lokan� existingPost i przypisa� refernecj�  do posta pobranego 
za pomoc� metody GetById(updatePost.id);
Nast�pnie mapujemy zaktualizowany posty na istniej�cy post w rezultacie otrzymuj�c post z zaktualizowanymi 
w�a�ciwo�ciami. Dzi�ki czemu otrzymujemy now� warto�� content nie trac�c istniej�cej warto�ci Title.
Nast�pnie wywo�ujemy metod� Update z repozytoruim.

    {
          public void UpdatePost(UpdatePostDto updatePost)
            {
                var existingPost = _postRepository.GetById(updatePost.Id);
                var post = _mapper.Map(updatePost, existingPost);
                _postRepository.Update(post);

            }
    }

6. Przej�� do kontrolera -  PostController

    wywo�ujemy metod� UpdatePost z serwisu _postService
   
    {
          [SwaggerOperation(Summary ="Update a existing post")]
            [HttpPut]
            public IActionResult Update (UpdatePostDto updatePost)
                {
                    _postService.UpdatePost(updatePost);
                    return NoContent();
                    //kod odpowiedzi 204

                }
    }
