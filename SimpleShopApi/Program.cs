using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using SimpleShopApi;
using SimpleShopApi.Validators;
using System;
using System.Reflection;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddDbContext<ProductsDbContext>(connection =>
        connection.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection")));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddControllers().AddFluentValidation(x => {
        x.RegisterValidatorsFromAssemblyContaining<Program>();
    });

    builder.Services.AddScoped<ErrorHandlingMiddleware>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<IAccountService, AccoundService>();
    builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    builder.Services.AddValidatorsFromAssemblyContaining<UserRegisterDtoValidator>();
    builder.Services.AddTransient<DataSeeder>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seeds();
    }


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ErrorHandlingMiddleware>();


    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}