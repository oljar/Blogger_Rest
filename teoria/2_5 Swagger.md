1. Nale¿y zainstalowaæ  Swashbuckle.AspNETCORE z managera NUGET do projektu WebApi
2. Do pliku Startup.cs do  metody  konfiguracji serwisów  - public void ConfigureServices(IServiceCollection services) 
    dodaæ :
{
    services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
                });
}

3. Do metody configure dodaæ
{

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "WebAPI v1");
                });
}

4.Dla VS 2022 W w³aœciwoœciach porojektu WebAPI -properties    w DEBUG  general klikn¹æ  - open debug lunch profiles .
    W IIS Exeress jest URL adreses of the web page to navigate to.
    wpisaæ - swagger

    https://didourebai.medium.com/add-swagger-to-asp-net-core-3-0-web-api-874cb265854c

5.Za pomoc¹ NuGet zainstalowaæ  Swashbuckle.AspNETCORE.Annotations

Dodaæ Swagger operation do bezparametrowej akcji Get w  kontolerze PostCotroller


{
  [SwaggerOperation(Summary = "Retrives a specific post by unique id")]
        [HttpGet]
}

oraz 
{
     [SwaggerOperation(Summary = "Retrives a specific post by uniquw id")]
        [HttpGet("{id}")]
}

W Startup w³¹czyæ mechanizm adnotacji: c.EnableAnnotations();

{
    services.AddSwaggerGen(c =>
                {
                    c.EnableAnnotations();
                    c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
                });

}

