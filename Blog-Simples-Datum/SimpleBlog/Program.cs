using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure.Persistence;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Infrastructure.Services;
using SimpleBlog.Infrastructure.Repositorios;
using SimpleBlog.Infrastructure.Hubs;
using FluentAssertions.Common;


var builder = WebApplication.CreateBuilder(args);

// Registrar o IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Adiciona o SignalR ao contêiner de dependências
builder.Services.AddSignalR();

// Configuração do DbContext
builder.Services.AddDbContext<SimpleBlogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro dos serviços e repositórios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ITokenService,  TokenService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Outros serviços
builder.Services.AddControllers();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetIsOriginAllowed(_ => true); // Permite todas as origens
    });
});

// Criação do aplicativo
var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowAll");

// Configura o pipeline de middleware
app.UseRouting();

// Garantir que as migrações do banco de dados sejam aplicadas (opcional)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SimpleBlogDbContext>();
    dbContext.Database.Migrate();
}

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<NotificationHub>("/notifications");
app.Run();
