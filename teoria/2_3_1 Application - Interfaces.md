1.1 Dodaæ folder Interfaces w  warstwie aplikacji
1.2 Dodaæ interfejs IPostService definiuj¹cy sygnatury metod odpowiedzialnych za pobieranie wszystkich postów lub posta o okreœlonej sygnaturze.
Interfejsy metody serwisu bêd¹ umieszczone w Aplikaction -> Interfaces.
Metody serwisu nie mog¹ zwracaæ modeli domenowych.Metody serwisu bêd¹ docelowo wywo³ywane w projekcie WebApi , który nie powinien nic wiedzieæ o Encjach znajduj¹cych siê w warstwie domenowej.
Nie mo¿na doprowadziæ do sytuacji aby modele domenowe wyciek³y z warstwy domeny do warstwy prezentacji.
Modele domenowe powinny  byæ enkapsulowane w samej domenenie i odpowiednio zmapowane przez aplikacjê , która zmapuje je na podobny model- ale zawieraj¹cy taki podzbiór danych który powinien- mo¿e  byæ zwrócowny  .

Trzeba stworzyæ osobne klasy które bêd¹ przesy³ane z Aplikacji prosto do WebAPI. 
Takie klasy nazywamy DTO

1.3 W warstwie aplikacji dodajemy nowy folder Dto

1.4 Dodajemy now¹ klasê PostDto

Tam powinny znaleœæ siê dane które powinny zostaæ zwrócone do WebAPI

1.5 W warstwie Application w folderze  Interfaces nale¿y podmieniæ Post na PostDto .
Wtedy interfessy metod i metody GetAllPost() i GetById bêdzi¹ korzysta³y z obiektów z PostDto.


