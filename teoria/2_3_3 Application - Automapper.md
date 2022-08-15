1. Nale¿y dodaæ do Apilkacji Automappera za pomoc¹ ManageNuGetPackages ( Automapper by Jim Bogard)
2. Dodaæ do warstwy Aplikacji nowy folder Mappings w ktorej umieszczamy klasê AutoMapperCofig
3. Metoda Initialize ma za zadanie zwróciæ implementacjê interfejsu IMapper. W konstruktorze
   za pomoc¹ wyra¿enia lambda konfigurujemy automapera.
4. Do konstruktora klasy PostService z Services nale¿y dodaæ drugi parametr IMapper mapper, oraz 
dodaæ pole prywatne automapera i utworzyæ w³asnoœæ o typie IMapper  w konstruktorze

5. Metoda GetPostById - Wywo³aæ  metodê Map z interfejsu IMapper - Typ zwrócony PostDto, argument  metody zmienna post

6. Metoda GetAllPost - Wywo³aæ metodê Map  interfejsu IMapper - Typ zwrócony IEnumerable od <PostDto>
, a argument -  posts
7. Pozosta³a kwestia przekazania interfejsów do konstruktora (konkretnych implementacji tych interfejsów)
Mo¿na tego dokonaæ za pomoc¹ kontenera IoC i wstrzykiwania zale¿noœci




8. Przejœæ do Klasy Statrup.cs lub program.cs (wy¿sze wersje) w projekcie WebApi
W metodzie ConfigureServices za pomoc¹ wstrzykiwania zale¿noœci okreœlamy jaka konkretna implementacja ma zostaæ wyko¿ystana w przypadku konkretnego interfejsu,
Jakie implementacje chcemy wstrzykn¹æ. 

a) PostRepository

b) PostService

oraz

c) konfiguracjê automappera

8.1 U¿ywamy metody AddScoped - która zapewni ¿e implementacja interfejsu bêdzie  pojedyñcza per ca³e ¿¹danie http
{
	services.AddScoped<IPostRepository, PostRepository>();
}
Dzêki temu framework ASP.net Core  bêdzie wiedzia³ ¿e jeœli gdziekolwiek na wejœciu np.w parametrze konstruktora
dotanie interfejs IPostRepository to automatycznie przypisze implementacje klasy PostRepository. 

Podobnie 
{
	services.AddScoped<IPostService, PostService>();
}

 8.2 Metoda AddSingleton zapewni nam ¿e implementacja interfejsu  bêdzie tworzona tylko jeden raz na samym pocz¹tku
 jako argument przekazujemy instancjê konfiguracji automappera. 

 {
	 services.AddSingleton(AutoMapperConfig.Initialize());
 }

 Framework Asp.Net Core bêdzie wiedzia³ ¿e jeœli gdziekolwiek  na wejœciu np w parametrze kostruktora dostanie 
 interfejs IMapper to wstrzyknie implementacjê pochodz¹c¹ z klasy AutoMapperConfig.
