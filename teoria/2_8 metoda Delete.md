Usuwanie zaspobu metoda DELETE.
Implementacja metody serwisu i akcji kontrolera s�u��ce do usuwania posta o podanym identyfikatorze.

1. W interfejsie IPostSservice dodajemy sygnatur�  metody  DeletePost 

{
	void DeletePost(int id);

}

2. 
Przej�� do  klasy PostService , zaimplementowa� metod� DeletePost
Do zmiennej lokalnej post przypisa� referencj�  do posta pobranego za pomoc� metody GetById(id)

{
	var post = _postRepository.GetById(id);
}

3 Wywo�a� metod� Delete z repozytorium.

{
	_postRepository.Delete(post);
}

4. Nat�pnie przej�� do akcji kontrolera.
    
    w akcji kontrolera usuwamy post za pomoc� metody serwisu DeletePost o okre�lonym w parametrze id.
    zwracamy kod 204  no content

    Doda� do akcji delete  atrybut [HttpDelete("{id}")] .informuj�c framework � akcja delete odpowiada
    metodzie HttpDelete.
    Je�li zostanie wys�ane ��danie Http typu delete pod adres Api/post/id to  wywo�a si� metoda delete z klasy post controller.
    Na koniec opis swaggera.

        [SwaggerOperation(Summary = "Delete a specific post")]
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _postService.DeletePost(id);
            return NoContent();
            // zwracamy kod odpowiedzi 204 no conntent
        }

