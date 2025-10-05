using Movies.Api.DTOs;
using Movies.Api.Endpoints;
using Movies.Api.Data;

var builder = WebApplication.CreateBuilder(args);
var conn = builder.Configuration.GetConnectionString("ConnString");

builder.Services.AddSqlite<MoviesContext>(conn);

var app = builder.Build();

app.MapGet("/", () => "Hello Jovid!");
await app.MigrateDbAsync();
app.MapMoviesEndpoints();
app.MapGenresEndpoints();
app.Run();
