using R_APIStartUp;

var loBuilder = WebApplication.CreateBuilder(args);
loBuilder
    .R_RegisterServices(builder =>
    {
        builder.R_DisableAuthentication();
        //builder.R_DisableSwagger();
        //builder.R_DisableGlobalException();
        // builder.R_DisableContext();
        // builder.R_DisableDatabase();
    })
    .Build()
    .R_SetupMiddleware()
    .Run();