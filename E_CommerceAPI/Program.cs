using E_Commerce.Application;
using E_Commerce.Application.Common.Interfacses;
using E_Commerce.Infrastructure;
using E_Commerce.Presentation.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ApplicationDbContext>(
//    option => option.UseSqlServer(connectionString)
//);
//var ConnectionString = builder.Configuration.GetConnectionString("default") ?? throw new NullReferenceException("Connection String Not found");
//var companyConnectionString = builder.Configuration.GetConnectionString("company") ?? throw new NullReferenceException("Connection String Not found");
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
#region web Di Contanier
builder.Services.AddScoped<IUser, CurrentUser>();
builder.Services.AddHttpContextAccessor();
#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
