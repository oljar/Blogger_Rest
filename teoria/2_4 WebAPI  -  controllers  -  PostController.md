1. Usunć klasy WeatherForcast i WeatherForcastController
2.  W projekcie WebAPI w klasie Controllers dodać nową klasę kontrolera szablon API controller Empty
Nazwa  PostController 
3. Akcja Get() zwraca wynik w postaci JSON

Należy dodać do akcji Get() atrybut [HttpGet] informując że akcja get odpowiada metodzie HttpGet.

4. Akcja Get z parametrem Id


Należy dodać do akcji Get(id) atrybut [HttpGet("(id)")] wskazując jako argument id