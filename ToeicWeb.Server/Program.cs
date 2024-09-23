using Microsoft.EntityFrameworkCore;
using ToeicWeb.Server.AuthService.Data;
using ToeicWeb.Server.AuthService.Services;
using ToeicWeb.Server.ExamService.Data;
using ToeicWeb.Server.ExamService.Repository.QuestionRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure different DB contexts for each service
builder.Services.AddDbContext<ExamDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ExamServiceConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("UserServiceConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// Authorization should be between UseRouting and UseEndpoints
app.UseAuthorization();

// Map controllers for both services
app.MapWhen(context => context.Request.Path.StartsWithSegments("/exam"), appBuilder =>
{
    appBuilder.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
});

app.MapWhen(context => context.Request.Path.StartsWithSegments("/user"), appBuilder =>
{
    appBuilder.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
});

app.Run();
