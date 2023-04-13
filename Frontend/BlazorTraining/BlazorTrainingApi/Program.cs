using R_APIStartUp;

var builder = WebApplication.CreateBuilder(args);

builder.R_RegisterServices(startup =>
{
    startup.R_DisableAuthentication();
});

var app = builder.Build();

app.R_SetupMiddleware();

app.UseStaticFiles();

app.Run();
