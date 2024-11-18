using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Data;
using SsttekAcademyHomeWorkApi.Middlewares;
using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Repositories;
using SsttekAcademyHomeWorkApi.Models.Repositories.Books;
using SsttekAcademyHomeWorkApi.Models.Repositories.Users;
using SsttekAcademyHomeWorkApi.Models.Services.Accounts;
using SsttekAcademyHomeWorkApi.Models.Services.Auth;
using SsttekAcademyHomeWorkApi.Models.Services.Books;
using SsttekAcademyHomeWorkApi.Models.Services.Products;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SsttekAcademyHomeWorkApi.Models.Services.Roles;
using SsttekAcademyHomeWorkApi.Models.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(x =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgreSql");
    x.UseNpgsql(connectionString);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;      
        options.Password.RequireLowercase = true; 
        options.Password.RequireUppercase = true; 
        options.Password.RequireNonAlphanumeric = false;  
        options.Password.RequiredLength = 6; 
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// JWT ayarlarını yapılandırması
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettings);

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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
        };
    });


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddKeyedTransient<IProductService, ProductService>("default");
builder.Services.AddKeyedTransient<IProductService, SpecialProductService>("special");
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // UnitOfWork için DI kaydı
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // GenericRepository için DI kaydı
builder.Services.AddScoped<IBookRepository, BookRepositoryWithPostgreSql>(); // BookRepository için DI kaydı
builder.Services.AddScoped<IBookService, BookService>(); // BookService için DI kaydı
builder.Services.AddScoped<IAccountService, AccountService>(); // AccountService için DI kaydı
builder.Services.AddScoped<IAuthService, AuthService>(); // AccountService için DI kaydı
builder.Services.AddScoped<IUserRepository, UserRepository>(); // UserRepository için DI kaydı
builder.Services.AddScoped<IUserService, UserService>(); // UserService için DI kaydı
builder.Services.AddScoped<IRoleService, RoleService>(); // RoleService için DI kaydı

//Model doğrulama hataları için
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
            Type = "https://yourdomain.com/model-validation-error",
            Title = "Doğrulama hatası.",
            Status = StatusCodes.Status400BadRequest,
            Detail = "Lütfen gönderdiğiniz verileri kontrol edin.",
            Instance = context.HttpContext.Request.Path
        };

        return new BadRequestObjectResult(problemDetails)
        {
            ContentTypes = { "application/problem+json" }
        };
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Bearer Token ile yetkilendirme.\r\n\r\n" +
                      "Token'ı 'Bearer {token}' formatında giriniz. Örneğin: 'Bearer eyJhbGciOi...'"
    });

    options.OperationFilter<AuthorizeCheckOperationFilter>();
    options.EnableAnnotations();
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await AppDbInitialize.InitializeRoles(serviceProvider);
    await AppDbInitialize.InitializeUser(serviceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
