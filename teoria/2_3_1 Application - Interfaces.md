1.1 Doda� folder Interfaces w  warstwie aplikacji
1.2 Doda� interfejs IPostService definiuj�cy sygnatury metod odpowiedzialnych za pobieranie wszystkich post�w lub posta o okre�lonej sygnaturze.
Interfejsy metody serwisu b�d� umieszczone w Aplikaction -> Interfaces.
Metody serwisu nie mog� zwraca� modeli domenowych.Metody serwisu b�d� docelowo wywo�ywane w projekcie WebApi , kt�ry nie powinien nic wiedzie� o Encjach znajduj�cych si� w warstwie domenowej.
Nie mo�na doprowadzi� do sytuacji aby modele domenowe wyciek�y z warstwy domeny do warstwy prezentacji.
Modele domenowe powinny  by� enkapsulowane w samej domenenie i odpowiednio zmapowane przez aplikacj� , kt�ra zmapuje je na podobny model- ale zawieraj�cy taki podzbi�r danych kt�ry powinien- mo�e  by� zwr�cowny  .

Trzeba stworzy� osobne klasy kt�re b�d� przesy�ane z Aplikacji prosto do WebAPI. 
Takie klasy nazywamy DTO

1.3 W warstwie aplikacji dodajemy nowy folder Dto

1.4 Dodajemy now� klas� PostDto

Tam powinny znale�� si� dane kt�re powinny zosta� zwr�cone do WebAPI

1.5 W warstwie Application w folderze  Interfaces nale�y podmieni� Post na PostDto .
Wtedy interfessy metod i metody GetAllPost() i GetById b�dzi� korzysta�y z obiekt�w z PostDto.


