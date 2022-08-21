1. W projekcie WebApi doda� nowy folder o nazwie installers
Doda� nowy interfejs IInstaller. Doda� sygnatur� metody InstallServices. Metoda przyjmuje dwa parametry:
IServiceCollectrion services oraz IConfiguration Configuration - czyli ma  dost�p do tych samych obiekt�w
do kt�rych ma dost�p IConfuguration z klasy Startup. 

{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration Configuration);
    }
}
2. Nast�pnie dodajemy klas� o nazwie MvcInstaller- do kt�rej dodajemy implementacj� IInstaller.

Do metody InstallServices przenosimy rejestracj� serwis�w zwi�zanych z aplikacj� i infrastruktur�.
( Z klasy Startup)

3 Utworzy� klas� MvcInstaller i zaimplementowa� do niej interfejs IInstaller

W ciele funkcji  InstallServices wstawi� services.AddSwaggerGen ( ) z klasy Startup.

4. Nast�pnie doda� klas� InstallerExtensions kt�ra b�dzie odpowiada�a za prawid�ow� instalacj� serwis�w 
zdefiniowan� w ode�bnych klasach.  

Klasa ta ma za zadanie wyszuka� klasy z instalatorami  i utworzy� ich instancj�. 

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
 5. Przej�� do metody SonfigureServices i wywo�a� metod� rozszerzaj�c� InstallServicesInAssembly jako argument przekazuj�c konfiguracj� Configuration
 
 {
     ervices.InstallServicesInAssembly(Configuration);
 }

 Po uruchomieniu program odszuka� utworzone dwie klasy instalator�w (debug - installers) i dokona rejestracji serwis�w przez
 uruchomienie metod InsatallServices  zaimplementowanych w tych klasach. 

 6. SPOS�B ABY KA�DY PROJEKT MIA� SWOJ� KLAS� DependencyInjection.


 6.1 Utworzy� klas� publiczn� i statyczn� DependencyInjection w projekcie Application
    a w niej metod� AddApplication  publiczn�, statyczn�  zwracaj�c� typ IServiceCollection
, przenie�� rejestracj� serwis�w z warstwy aplikacji.


{
    public static class DependencyInjection

    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {

            /*
            Dz�ki temu framework ASP.net Core  b�dzie wiedzia� �e je�li gdziekolwiek na wej�ciu np.w parametrze konstruktora
            dotanie interfejs IPostService  to automatycznie przypisze implementacje klasy PostService. 
           Zostanie stworzona referencja - odniesienie
            */

            services.AddScoped<IPostService, PostService>();



            /* 
           Metoda AddSingleton zapewni nam �e implementacja interfejsu  b�dzie tworzona tylko jeden raz na samym pocz�tku
           jako argument przekazujemy instancj� konfiguracji automappera. 
           Framework Asp.Net Core b�dzie wiedzia� �e je�li gdziekolwiek  na wej�ciu np w parametrze kostruktora dostanie 
           interfejs IMapper to wstrzyknie implementacj� pochodz�c� z klasy AutoMapperConfig.
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
            Dz�ki temu framework ASP.net Core  b�dzie wiedzia� �e je�li gdziekolwiek na wej�ciu np.w parametrze konstruktora
            dotanie interfejs IPostRepository to automatycznie przypisze implementacje klasy PostRepository. 
            Zostanie stworzona referencja - odniesienie       */

            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    
            
    }

    W MvcInstaller umie�ci� wywo�ania
    {
        
            services.AddApplication();
            services.AddInfrastructure();

    }
