***Aktualizacja zasobu - metoda Put***
1.  W interfejsie IPostService dodaæ sygnaturê metody UpdatePost odpowiedzialn¹ za zaktualizowanie posta.
    {
        {
	        void UpdatePost();
        }
    }

2.  W folderze Dto dodaæ now¹ klasê UpdatePostDto
    Nie bêdzie mo¿na zaktualizowaæ tytu³u - tylko treœæ
    
    {
        public class UpdatePostDto
    
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }
    }

3. W  sygnaturze metody UpdatePost dodaæ  parametr UpdatePostDto updatePost
     {  
        {   
             void UpdatePost(UpdatePostDto updatePost);
        }
     }
4. Przejœæ  do konfiguracji Automapera. 

Utwo¿yæ mapê dla UpdatePostDto i zmaowaæ ten typ na Post
    {
        {
            cfg.CreateMap<UpdatePostDto, Post>();
        }
    }
5. Przejœæ  do klasy PostService i implementowaæ metodê UpdatePost
W tej metodzie utworzyæ zmienn¹ lokan¹ existingPost i przypisaæ refernecjê  do posta pobranego 
za pomoc¹ metody GetById(updatePost.id);
Nastêpnie mapujemy zaktualizowany posty na istniej¹cy post w rezultacie otrzymuj¹c post z zaktualizowanymi 
w³aœciwoœciami. Dziêki czemu otrzymujemy now¹ wartoœæ content nie trac¹c istniej¹cej wartoœci Title.
Nastêpnie wywo³ujemy metodê Update z repozytoruim.

    {
          public void UpdatePost(UpdatePostDto updatePost)
            {
                var existingPost = _postRepository.GetById(updatePost.Id);
                var post = _mapper.Map(updatePost, existingPost);
                _postRepository.Update(post);

            }
    }

6. Przejœæ do kontrolera -  PostController

    wywo³ujemy metodê UpdatePost z serwisu _postService
   
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
