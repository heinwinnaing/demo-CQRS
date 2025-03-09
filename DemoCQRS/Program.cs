using DemoCQRS.Commands.CreateUser;
using DemoCQRS.Commands.DeleteUser;
using DemoCQRS.Commands.UpdateUser;
using DemoCQRS.Handlers;
using DemoCQRS.Persistence;
using DemoCQRS.Queries.GetUserById;
using DemoCQRS.Queries.GetUserList;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<DemoDbContext>(options =>
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    string connectionString = builder.Configuration.GetConnectionString("demo_db")!;
    options.UseNpgsql(connectionString);
}, 100);

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

#region #fluent-validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateUserCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteUserByIdCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetUserListQueryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetUserByIdQueryValidator>();
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

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
app.UseExceptionHandler();
app.Run();
