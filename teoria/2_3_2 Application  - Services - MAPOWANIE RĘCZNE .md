1.1 W warstwie apikacji doda� kolejny folder o nazwie Services
1.2 W Folderze Services doda� klas� PostService
1.3 W Post Service zaimplementowa� interfejs IPostService

W IPostRepository s� zadeklarowane metody gdzie parametrem jest Post
W IPostSerwices s� zadeklartowane metody gdzie parametrem jest PostDto .
Natomiat PostService ma za zadanie zmapowanie obiekt�w Post na PostDto

Dla GetPostById()
Pobieramy obiekt typu Post wywo�uj�c metod� Get_By_Id() z repozytorum  i przypisujemy go do lokalne zmiennej post.
Nast�pnie zwracamy post w postaci Dto.

Dla GetAllPosts()
Pobieramy wszystkie posty wywo�uj�c GetAllPost() z repozytorium i zwracan� warto�� przypisujemy do lokalnej zmiennej
lokalnej zmienne posts. Zwracamy przy pomocy LINQ i Select kolekcj� obiekt�w typu PostDto.


Jest to r�czne mapowanie modelu domenowego do Dto co jest bardzo uci��liwe.

