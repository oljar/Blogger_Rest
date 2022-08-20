Usuwanie zaspobu metoda DELETE.
Implementacja metody serwisu i akcji kontrolera s³u¿¹ce do usuwania posta o podanym identyfikatorze.

1. W interfejsie IPostSservice dodajemy sygnaturê  metody  DeletePost 

{
	void DeletePost(int id);

}

2. 
Przejœæ do  klasy PostService , zaimplementowaæ metodê DeletePost
Do zmiennej lokalnej post przypisaæ referencjê  do posta pobranego za pomoc¹ metody GetById(id)

{
	var post = _postRepository.GetById(id);
}

3 Wywo³aæ metodê Delete z repozytorium.

{
	_postRepository.Delete(post);
}

4. Natêpnie przejœæ do akcji kontrolera.
    
    w akcji kontrolera usuwamy post za pomoc¹ metody serwisu DeletePost o okreœlonym w parametrze id.
    zwracamy kod 204  no content

    Dodaæ do akcji delete  atrybut [HttpDelete("{id}")] .informuj¹c framework ¿ akcja delete odpowiada
    metodzie HttpDelete.
    Jeœli zostanie wys³ane ¿¹danie Http typu delete pod adres Api/post/id to  wywo³a siê metoda delete z klasy post controller.
    Na koniec opis swaggera.

        [SwaggerOperation(Summary = "Delete a specific post")]
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _postService.DeletePost(id);
            return NoContent();
            // zwracamy kod odpowiedzi 204 no conntent
        }

