using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Quiz.Business.Interfaces;
using Quiz.Business.Services;
using Quiz.Data.Contexts;
using Quiz.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

// Register Business Layer Services
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();

// Register Data Layer Services
builder.Services.AddScoped<QuestionRepository>();
builder.Services.AddScoped<ParticipantRepository>();

var app = builder.Build();

app.UseCors(options => 
options.WithOrigins("http://localhost:3000")
.AllowAnyMethod()
.AllowAnyHeader());

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath="/Images"
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
