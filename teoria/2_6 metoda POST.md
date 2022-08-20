1.  W interfejsie IPostSerwice dodadaæ sygnaturê AddNewPost odpowiedzialn¹ za dodanoie nowego Posta.
{
	PostDto AddNewPost(PostDto newPost)
}

2. Parametr newPost jest klasy PostDto . Klasa ta posiada odentyfikator który nadawany jest po 
	stronie serwera, a nie klienta. 
3. Nale¿y utworzyc detykowane DTO do tworzenia nowego posta który bêdzie posiada³ tytu³ oraz treœæ. 

4. Dodaæ now¹ klasê do foldertu DTO CreateDto z w³aœciwoœciami Title i Content. Nie dodajemy w³aœciwoœci Id

5. W sygnaturze metody AddNewPost zmieniæ typ parametru na CreatePostDto

6. Przejœæ do konfiguracji Automapera . Uworzyæ  mapê dla typu   CreatePostDto i zmapowaæ na typ Post. 


{
	 public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDto>(); //  wczeœniejsze mapowanie

                cfg.CreateMap<CreatePostDto, Post>();
            
            
            })
            .CreateMapper();
}

7.Zaimplementowaæ brakuj¹c¹ metodê AddNewPost z interfejsu  IPostService  w PostServices

{
    public PostDto AddNewPost(CreatePostDto newPost)
}

Do zmiennej post przypisaæ odpowiednio zmapowany obiekt NewPost na Post
{ 
    var post = _mapper.Map<Post>(newPost);
}
Nastêpnie wywo³aæ metodê Add z repozytorium

{
    _postRepository.Add(post);
}

Zwróæiæ zmapowany obiekt Post na PostDto

Teraz mo¿na przejœæ do implwmwntacji akcji kontrolera




Metoda AddNewPost ma tak wygl¹daæ.

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



 8.  W kontrolerze  PostController dodaæ metode Create 

 {
    IActionResult Create ( CreatePostDto newPost)
 }

Dodaæ obiekt newPost za poœrednictwem metody  AddNewPost do serwisu (obiektu) _postService klasy PostService
uzyskanego po  wstrzykniêciu zale¿noœci. 
{
     var post = _postService.AddNewPost(newPost);
}

9 . Nastêpnie zwracamy kod odpowiedzi 201 (Created) przesy³aj¹c link do nowo utworzonego zasobu i 
przesy³amy nowo dodany obiekt. 

{
    return Created($"api/posts/{post.Id}", post);
}

10. Dodaæ do Akcji Create atrybut [HttpPost] informuj¹c framework ¿e akcja  Create  odpowiada
metodzie typu Post.
Jeœli zostanie wys³ane ¿¹danie Http typu Post pod adres api/Post  to wywo³a siê metoda Create z klasy PostsController.

11. Dodaæ opis do Swaggera

{
      [SwaggerOperation(Summary = "Create a new post")]
        [HttpPost]
        public IActionResult Create (CreatePostDto newPost)
        {
            var post = _postService.AddNewPost(newPost);
            return Created($"api/posts/{post.Id}", post);
        }

}

