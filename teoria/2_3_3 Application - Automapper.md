1. Nale�y doda� do Apilkacji Automappera za pomoc� ManageNuGetPackages ( Automapper by Jim Bogard)
2. Doda� do warstwy Aplikacji nowy folder Mappings w ktorej umieszczamy klas� AutoMapperCofig
3. Metoda Initialize ma za zadanie zwr�ci� implementacj� interfejsu IMapper. W konstruktorze
   za pomoc� wyra�enia lambda konfigurujemy automapera.
4. Do konstruktora klasy PostService z Services nale�y doda� drugi parametr IMapper mapper, oraz 
doda� pole prywatne automapera i utworzy� w�asno�� o typie IMapper  w konstruktorze

5. Metoda GetPostById - Wywo�a�  metod� Map z interfejsu IMapper - Typ zwr�cony PostDto, argument  metody zmienna post

6. Metoda GetAllPost - Wywo�a� metod� Map  interfejsu IMapper - Typ zwr�cony IEnumerable od <PostDto>
, a argument -  posts
7. Pozosta�a kwestia przekazania interfejs�w do konstruktora (konkretnych implementacji tych interfejs�w)
Mo�na tego dokona� za pomoc� kontenera IoC i wstrzykiwania zale�no�ci




8. Przej�� do Klasy Statrup.cs lub program.cs (wy�sze wersje) w projekcie WebApi
W metodzie ConfigureServices za pomoc� wstrzykiwania zale�no�ci okre�lamy jaka konkretna implementacja ma zosta� wyko�ystana w przypadku konkretnego interfejsu,
Jakie implementacje chcemy wstrzykn��. 

a) PostRepository

b) PostService

oraz

c) konfiguracj� automappera

8.1 U�ywamy metody AddScoped - kt�ra zapewni �e implementacja interfejsu b�dzie  pojedy�cza per ca�e ��danie http
{
	services.AddScoped<IPostRepository, PostRepository>();
}
Dz�ki temu framework ASP.net Core  b�dzie wiedzia� �e je�li gdziekolwiek na wej�ciu np.w parametrze konstruktora
dotanie interfejs IPostRepository to automatycznie przypisze implementacje klasy PostRepository. 

Podobnie 
{
	services.AddScoped<IPostService, PostService>();
}

 8.2 Metoda AddSingleton zapewni nam �e implementacja interfejsu  b�dzie tworzona tylko jeden raz na samym pocz�tku
 jako argument przekazujemy instancj� konfiguracji automappera. 

 {
	 services.AddSingleton(AutoMapperConfig.Initialize());
 }

 Framework Asp.Net Core b�dzie wiedzia� �e je�li gdziekolwiek  na wej�ciu np w parametrze kostruktora dostanie 
 interfejs IMapper to wstrzyknie implementacj� pochodz�c� z klasy AutoMapperConfig.
