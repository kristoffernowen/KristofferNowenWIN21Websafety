using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using WebSafetyExam2;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// Något i Microsoft.AspNetCore.Authentication.JwtBearer krockar med Swagger. Jag fick ta bort Swagger interface för att
// jwtbearer ska funka

builder.Services.AddDbContext<SqlContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-bz6ufpqwlzmwscqe.us.auth0.com/";
    options.Audience = "WebSafetyExam2";
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>    // Why wont default work!!!!
    {
        policyBuilder.WithOrigins("http://localhost:3000/");
        policyBuilder.WithMethods("GET", "POST"); // Tillåts i vilket fall dock...
        policyBuilder.WithHeaders(HeaderNames.AcceptLanguage, "mandatory-header", HeaderNames.ContentType);
    });
    options.AddPolicy("react", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000");
        policyBuilder.WithMethods("GET", "DELETE");         
        policyBuilder.WithHeaders(HeaderNames.ContentType, "mandatory-header");  
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseSwagger();
// app.UseSwaggerUI();

// app.UseRouting should be above cors
app.UseCors();
// app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
