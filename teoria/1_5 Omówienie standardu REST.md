***Standard REST**

REST -styl architektury definiujący zbiór zasad i dobrych praktych dotyczących projektowania API 
REpresentation State Transfer.



***Zasady API***

1) Zunifikowany interfejs (ustandaryzowana komunikacja między  klienta a serwerem)
    dotyczy prawidłowego wykorzystania metod HTTP GET, POST ,PUT , DELETE czy format wymiany danych Json. 
    Dostęp do każdego zasobu jest realizowany w ten sam sposób. Przy każdym zapytaniu powinien zwracany być ten sam format danych.
    Metody HTTP powinny definiować to co otrzymamy z serwera.  

2) Infrastruktura klient-serwer 
   Separacja po stronie klienta i serwera. Serwer może wysłać same dane, ale to klient zdecyduje jak zostana te dane zaprezentowane . 
   Klient nie ma prawa wpływac na to jak działa serwer - czyli interfej WEB API.

3) Bezstanowość - Każde zapytanie musi posiadać komplet informacji koniecznych do jego prawidłowego zakończenia. Każdy request musi
   posiadać koplet informacji koniecznych do wykonania zapytania .
4) Cash - Interfejs api powinien wspierać API w celu zwiększenia wydajności. Każda operacja powinna być oznaczona jako cashable bądz nocashable
5) Architektura warstwowa - Klient wysyłający zapytanie powinien dostać odpowiedż bez koniecności posiadania wiedzy co się dzieje po stronie serwera. 