using Microsoft.EntityFrameworkCore;
using UniBet.Contexts.Betting.Domain.IRepositories;
using UniBet.Contexts.Betting.Application.UseCases;
using UniBet.Contexts.Betting.Infrastructure.Persistance;
using UniBet.Contexts.Betting.Infrastructure.Repositories;
using UniBet.Contexts.Betting.Application.UseCases.GetBet;
using UniBet.Contexts.Betting.Application.UseCases.CreateBet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CloseBetDTO>();
builder.Services.AddScoped<GetBetUseCase>();
builder.Services.AddScoped<CreateBetUseCase>();
builder.Services.AddScoped<IBetRepository, BetRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<BettingDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

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
