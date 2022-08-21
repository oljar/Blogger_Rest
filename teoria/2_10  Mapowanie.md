***Uproszczenie konfiguracji AutoMappera -mapowania obiekt�w DTO***
	Zostanie przeniesione tworzenie map bezpo�rednio do klasy DTO

	Usun�� klas� AutoMapperConfig.cs
	i doda� interfejs IMap.cs


{

    public interface IMap
    {
        void Mapping(Profile profile);
    }

}

 Nast�pnie zaimplementowa� ten interfejs  do klas Dto
  

 2.Zaimplementowa� IMap do PostDto jak poni�ej
    
   {

       public void Mapping(Profile profile)
            {
                profile.CreateMap<Post, PostDto>();
            }
   }


   3. Zaimplementowa� IMap  do  CreatePostDto 
   Zdefiniowa� odpowiednie mapowanie

   {
        public void Mapping(Profile profile)
            {
                profile.CreateMap<CreatePostDto, Post>();
            }
   }

   4. Podobnie implementujemy w UpdatePostDto 
   
   {
           public void Mapping(Profile profile)
                {
                    profile.CreateMap<CreatePostDto, Post>();
                }
   }

   5. Teraz w folderze mappings doda� klas� MappingProfile kt�ra odpowiada za poprawne wywo�anie zdefinowanych mapowa�.

   {
    public class MappingProfile :Profile

    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(x =>
               typeof(IMap).IsAssignableFrom(x) && !x.IsInterface).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}

6.  W Application zainstalowa� bibliotek� AutomapperExtensionMicrosoftDependencyInjection
W Application , w DependencyInjection doda� w AddAplication . 


{
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
}
