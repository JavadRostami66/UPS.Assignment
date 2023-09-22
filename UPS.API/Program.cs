using UPS.Domain;
using UPS.Repository.Common;
using Microsoft.EntityFrameworkCore;
using UPS.API.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using UPS.Repository.Repositories.Employee;
using UPS.Service.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<EmployeeContext>();
builder.Services.AddDbContext<EmployeeContext>
(o => o.UseInMemoryDatabase("EmployeeDb"));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
//options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);

builder.Services
    .AddMvc(a => { a.EnableEndpointRouting = false; })
    .SetCompatibilityVersion(CompatibilityVersion.Latest);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Employee API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                }
            },
            new List < string > ()
        }
    });
});


//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
//    {
//        Title = "Employee API",
//        Version = "V1"
//    });
//    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    //{
//    //    Scheme = "Bearer",
//    //    BearerFormat = "JWT",
//    //    In = ParameterLocation.Header,
//    //    Name = "Authorization",
//    //    Description = "Bearer Authentication with JWT Token",
//    //    Type = SecuritySchemeType.Http
//    //});
//    //c.AddSecurityRequirement(new OpenApiSecurityRequirement {
//    //    {
//    //        new OpenApiSecurityScheme {
//    //            Reference = new OpenApiReference {
//    //                Id = "Bearer",
//    //                    Type = ReferenceType.SecurityScheme
//    //            }
//    //        },
//    //        new List < string > ()
//    //    }
//    //});
//});

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:7178",
        ValidAudience = "http://localhost:7178",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("javad"))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseMvc();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger/ui";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API(v1)");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
