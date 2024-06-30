// using CountryAPI.Controller.Interface;
// using CountryAPI.Interface;
// using CountryAPI.Model;
// using CountryAPI.Repository;
// using CountryAPI.Services;
//

using CountryAPI.Controller;
using CountryAPI.Controller.Interface;
using CountryAPI.Interface;
using CountryAPI.Model;
using CountryAPI.Repository;
using CountryAPI.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Country API", Version = "v1" });
});
builder.Services.AddSingleton<DapperContext>(); 
builder.Services.AddControllers();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<BaseRepository>();
builder.Services.AddHttpClient<CountryService>();
// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.PropertyNamingPolicy = null;
// });
//
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    options.RoutePrefix = string.Empty;
});
app.MapControllers();
app.Run();






