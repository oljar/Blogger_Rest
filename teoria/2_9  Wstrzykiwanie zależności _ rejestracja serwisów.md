1. W projekcie WebApi dodaÊ nowy folder o nazwie installers
DodaÊ nowy interfejs IInstaller. DodaÊ sygnaturÍ metody InstallServices. Metoda przyjmuje dwa parametry:
IServiceCollectrion services oraz IConfiguration Configuration - czyli ma  dostÍp do tych samych obiektÛw
do ktÛrych ma dostÍp IConfuguration z klasy Startup. 

{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration Configuration);
    }
}
2. NastÍpnie dodajemy klasÍ o nazwie MvcInstaller- do ktÛrej dodajemy implementacjÍ IInstaller.

Do metody InstallServices przenosimy rejestracjÍ serwisÛw zwiπzanych z aplikacjπ i infrastrukturπ.
( Z klasy Startup)

3 UtworzyÊ klasÍ MvcInstaller i zaimplementowaÊ do niej interfejs IInstaller

W ciele funkcji  InstallServices wstawiÊ services.AddSwaggerGen ( ) z klasy Startup.

4. NastÍpnie dodaÊ klasÍ InstallerExtensions ktÛra bÍdzie odpowiada≥a za prawid≥owπ instalacjÍ serwisÛw 
zdefiniowanπ w odeÍbnych klasach.  

Klasa ta ma za zadanie wyszukaÊ klasy z instalatorami  i utworzyÊ ich instancjÍ. 

 {
     public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
            {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
            typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

        installers.ForEach(installer => installer.InstallServices(services, configuration));
            }
    }
 }
 5. PrzejúÊ do metody SonfigureServices i wywo≥aÊ metodÍ rozszerzajπcπ InstallServicesInAssembly jako argument przekazujπc konfiguracjÍ Configuration
 
 {
     ervices.InstallServicesInAssembly(Configuration);
 }

 Po uruchomieniu program odszuka≥ utworzone dwie klasy instalatorÛw (debug - installers) i dokona rejestracji serwisÛw przez
 uruchomienie metod InsatallServices  zaimplementowanych w tych klasach. 

 6. SPOS”B ABY KAèDY PROJEKT MIA£ SWOJ• KLAS  DependencyInjection.


 6.1 UtworzyÊ klasÍ publicznπ i statycznπ DependencyInjection w projekcie Application
    a w niej metodÍ AddApplication  publicznπ, statycznπ  zwracajπcπ typ IServiceCollection
, przenieúÊ rejestracjÍ serwisÛw z warstwy aplikacji.


{
    public static class DependencyInjection

    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {

            /*
            DzÍki temu framework ASP.net Core  bÍdzie wiedzia≥ øe jeúli gdziekolwiek na wejúciu np.w parametrze konstruktora
            dotanie interfejs IPostService  to automatycznie przypisze implementacje klasy PostService. 
           Zostanie stworzona referencja - odniesienie
            */

            services.AddScoped<IPostService, PostService>();



            /* 
           Metoda AddSingleton zapewni nam øe implementacja interfejsu  bÍdzie tworzona tylko jeden raz na samym poczπtku
           jako argument przekazujemy instancjÍ konfiguracji automappera. 
           Framework Asp.Net Core bÍdzie wiedzia≥ øe jeúli gdziekolwiek  na wejúciu np w parametrze kostruktora dostanie 
           interfejs IMapper to wstrzyknie implementacjÍ pochodzπcπ z klasy AutoMapperConfig.
           */

            services.AddSingleton(AutoMapperConfig.Initialize());

            return services;
        }
    }
}

Podobnie w klasie Infrastructure 

{
    public static class DependencyInjection
    {
        public static IServiceCollection  AddInfrastructure(this IServiceCollection services)
        {

            /*
            DzÍki temu framework ASP.net Core  bÍdzie wiedzia≥ øe jeúli gdziekolwiek na wejúciu np.w parametrze konstruktora
            dotanie interfejs IPostRepository to automatycznie przypisze implementacje klasy PostRepository. 
            Zostanie stworzona referencja - odniesienie       */

            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    
            
    }

    W MvcInstaller umieúciÊ wywo≥ania
    {
        
            services.AddApplication();
            services.AddInfrastructure();

    }
