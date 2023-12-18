using Bredex1.service;
using Bredex1.service.utility;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ClientService, ClientService>();
    builder.Services.AddSingleton<ClientInputChecker, ClientInputChecker>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


