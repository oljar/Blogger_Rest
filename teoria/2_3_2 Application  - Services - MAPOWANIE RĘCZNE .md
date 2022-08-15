1.1 W warstwie apikacji dodaæ kolejny folder o nazwie Services
1.2 W Folderze Services dodaæ klasê PostService
1.3 W Post Service zaimplementowaæ interfejs IPostService

W IPostRepository s¹ zadeklarowane metody gdzie parametrem jest Post
W IPostSerwices s¹ zadeklartowane metody gdzie parametrem jest PostDto .
Natomiat PostService ma za zadanie zmapowanie obiektów Post na PostDto

Dla GetPostById()
Pobieramy obiekt typu Post wywo³uj¹c metodê Get_By_Id() z repozytorum  i przypisujemy go do lokalne zmiennej post.
Nastêpnie zwracamy post w postaci Dto.

Dla GetAllPosts()
Pobieramy wszystkie posty wywo³uj¹c GetAllPost() z repozytorium i zwracan¹ wartoœæ przypisujemy do lokalnej zmiennej
lokalnej zmienne posts. Zwracamy przy pomocy LINQ i Select kolekcjê obiektów typu PostDto.


Jest to rêczne mapowanie modelu domenowego do Dto co jest bardzo uci¹¿liwe.

