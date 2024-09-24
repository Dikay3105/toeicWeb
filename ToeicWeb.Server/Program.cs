using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToeicWeb.Server.AuthService.Data;
using ToeicWeb.Server.AuthService.Interfaces;
using ToeicWeb.Server.AuthService.Models;
using ToeicWeb.Server.AuthService.Repositories;
using ToeicWeb.Server.AuthService.Repository;
using ToeicWeb.Server.ExamService.Data;
using ToeicWeb.Server.ExamService.Interfaces;
using ToeicWeb.Server.ExamService.Repository;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var secretKey = configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
var allowSpecificOrigins = "_allowSpecificOrigins";


// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        //tự cấp token
                        ValidateIssuer = false,
                        ValidateAudience = false,

                        ValidAudience = builder.Configuration["JWT:ValidAudience"],
                        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                        //ký vào token
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                        ClockSkew = TimeSpan.Zero
                    };
                });

// Configure different DB contexts for each service
builder.Services.AddDbContext<ExamDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ExamServiceConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("UserServiceConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                      });
});


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(allowSpecificOrigins);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();

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
