using Serilog;
using Book_Store.DBContext;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.middleware;
using Book_Store.Repostory;
using Book_Store.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
   

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddTransient<IUserRepostry, UserRepostory>();
builder.Services.AddTransient<IBookRepostory, BookRepostory>();
builder.Services.AddTransient<ICategoryRepostory,CategoryReposory>();
builder.Services.AddTransient<IAutherRepostory, AutherRepostory>();
builder.Services.AddTransient<IUserBookRepostory, UserBookRepostory>();
builder.Services.AddTransient<IAutherServices,AutherServices>();
builder.Services.AddTransient<IBookServices,BookServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<IUserBookServices, UserBookServices>();
builder.Services.AddTransient<IUserServices, UserServices>();


builder.Host.UseSerilog((context, configuration) =>
     configuration.ReadFrom.Configuration(context.Configuration));

builder.Logging.AddSerilog();


var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();
builder.Services.AddRazorPages();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseSerilogRequestLogging();

app.UseMiddleware<TimeBlock>();
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
