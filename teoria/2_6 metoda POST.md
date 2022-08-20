1.  W interfejsie IPostSerwice dodada� sygnatur� AddNewPost odpowiedzialn� za dodanoie nowego Posta.
{
	PostDto AddNewPost(PostDto newPost)
}

2. Parametr newPost jest klasy PostDto . Klasa ta posiada odentyfikator kt�ry nadawany jest po 
	stronie serwera, a nie klienta. 
3. Nale�y utworzyc detykowane DTO do tworzenia nowego posta kt�ry b�dzie posiada� tytu� oraz tre��. 

4. Doda� now� klas� do foldertu DTO CreateDto z w�a�ciwo�ciami Title i Content. Nie dodajemy w�a�ciwo�ci Id

5. W sygnaturze metody AddNewPost zmieni� typ parametru na CreatePostDto

6. Przej�� do konfiguracji Automapera . Uworzy�  map� dla typu   CreatePostDto i zmapowa� na typ Post. 


{
	 public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDto>(); //  wcze�niejsze mapowanie

                cfg.CreateMap<CreatePostDto, Post>();
            
            
            })
            .CreateMapper();
}

7.Zaimplementowa� brakuj�c� metod� AddNewPost z interfejsu  IPostService  w PostServices

{
    public PostDto AddNewPost(CreatePostDto newPost)
}

Do zmiennej post przypisa� odpowiednio zmapowany obiekt NewPost na Post
{ 
    var post = _mapper.Map<Post>(newPost);
}
Nast�pnie wywo�a� metod� Add z repozytorium

{
    _postRepository.Add(post);
}

Zwr��i� zmapowany obiekt Post na PostDto

Teraz mo�na przej�� do implwmwntacji akcji kontrolera




Metoda AddNewPost ma tak wygl�da�.

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



 8.  W kontrolerze  PostController doda� metode Create 

 {
    IActionResult Create ( CreatePostDto newPost)
 }

Doda� obiekt newPost za po�rednictwem metody  AddNewPost do serwisu (obiektu) _postService klasy PostService
uzyskanego po  wstrzykni�ciu zale�no�ci. 
{
     var post = _postService.AddNewPost(newPost);
}

9 . Nast�pnie zwracamy kod odpowiedzi 201 (Created) przesy�aj�c link do nowo utworzonego zasobu i 
przesy�amy nowo dodany obiekt. 

{
    return Created($"api/posts/{post.Id}", post);
}

10. Doda� do Akcji Create atrybut [HttpPost] informuj�c framework �e akcja  Create  odpowiada
metodzie typu Post.
Je�li zostanie wys�ane ��danie Http typu Post pod adres api/Post  to wywo�a si� metoda Create z klasy PostsController.

11. Doda� opis do Swaggera

{
      [SwaggerOperation(Summary = "Create a new post")]
        [HttpPost]
        public IActionResult Create (CreatePostDto newPost)
        {
            var post = _postService.AddNewPost(newPost);
            return Created($"api/posts/{post.Id}", post);
        }

}

