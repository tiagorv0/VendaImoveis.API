using Microsoft.EntityFrameworkCore;
using VendaImoveis.API.Configuration;
using VendaImoveis.API.Filters;
using VendaImoveis.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opts =>
{
    opts.Filters.Add<ApplicationExceptionFilter>();
});

builder.Services.ResolveDependencies(builder.Configuration);
builder.Services.AddIdentityAndJwtConfiguration(builder.Configuration);
builder.Services.AddSwagger();

builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
