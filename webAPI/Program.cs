using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddDbContext<_216775882_MyStoreDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString
    ("Data Source=srv2\\pupils;Initial Catalog=216775882_MyStoreDB;Integrated Security=True;Trust Server Certificate=True")),ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
