using Bredex1.service;
using Bredex1.service.utility;
using Bredex1.src.repository;
using Bredex1.src.service;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<EFInMemoryDBAccess>();
    
    builder.Services.AddScoped<AuthorizationService, AuthorizationService>();
    builder.Services.AddScoped<PositionService, PositionService>();
    builder.Services.AddScoped<ClientService, ClientService>();
    builder.Services.AddScoped<ClientInputChecker, ClientInputChecker>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


