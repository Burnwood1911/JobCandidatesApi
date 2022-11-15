using JobCandidatesApi.Services;
using JobCandidatesApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ICSVService, CSVService>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
