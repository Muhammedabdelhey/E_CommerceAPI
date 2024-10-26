using E_Commerce.Application;
using E_Commerce.Application.Common.Interfaces;
using E_Commerce.Infrastructure;
using E_Commerce.Presentation;
using E_Commerce.Presentation.Extensions;
using E_Commerce.Presentation.Services;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUser, CurrentUser>();

#region register Project Layers

builder.Services.AddApplication(builder.Configuration);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddPresentation();
#endregion

#region AddJwtAuthentication
builder.Services.AddJwtAuthentication();
#endregion

#region Add Authorization
builder.Services.AddPolicies();
#endregion

builder.Services.AddControllers()
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
           options.JsonSerializerOptions.WriteIndented = true;
       }); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Disable automatic model validation like null in commands
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// this will take your custom exception handler and use to handle all exceptions 

app.UseExceptionHandler(options => { });

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
