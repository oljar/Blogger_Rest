***Uproszczenie konfiguracji AutoMappera -mapowania obiektów DTO***
	Zostanie przeniesione tworzenie map bezpoœrednio do klasy DTO

	Usun¹æ klasê AutoMapperConfig.cs
	i dodaæ interfejs IMap.cs


{

    public interface IMap
    {
        void Mapping(Profile profile);
    }

}

 Nastêpnie zaimplementowaæ ten interfejs  do klas Dto
  

 2.Zaimplementowaæ IMap do PostDto jak poni¿ej
    
   {

       public void Mapping(Profile profile)
            {
                profile.CreateMap<Post, PostDto>();
            }
   }


   3. Zaimplementowaæ IMap  do  CreatePostDto 
   Zdefiniowaæ odpowiednie mapowanie

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

   5. Teraz w folderze mappings dodaæ klasê MappingProfile która odpowiada za poprawne wywo³anie zdefinowanych mapowañ.

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

6.  W Application zainstalowaæ bibliotekê AutomapperExtensionMicrosoftDependencyInjection
W Application , w DependencyInjection dodaæ w AddAplication . 


{
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
}
