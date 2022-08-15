*** Model aplikacji  z ARCHITEKTURĄ WARSTWOWĄ - inaczej czystą architekturą . ( cebuli )***

1. Domain - Warstwa domenowa - definiuje sie modele domenowe
2. Application - Warstawa aplikacji - implementacja logiki biznesowej - przetwarzanie, zapisywanie, przesyłanie danych do klienta
	Posiada referencje tylko do warstwy domenowej
3. Infrastructure - Warstwa infrastruktury - określa zestaw frameworków , elementów oprogramowania , które wykorzystywane są w aplikacji
	silnik bazodanowy, konfiguracja kontekstu połączenia z bazą danych, konwertery danych  również
	repozytoria - abstrakcja dostępu do danch  która określa jak przetwarzać model bazowanowy.
	Posiada referencje tylko do warstwy aplikacji
4. Presentaton - Warstwa Prezentacji - zawiera kontrolery odpowiedzialne za wykonanie poszczególnych 
	operacji. - WEB API.
	Posiada referencje do warstwy infrastruktury i aplikacji. 

