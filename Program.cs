using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AppDbContext>();

builder.Services.AddScoped<IRepositoryCard, RepositoryCard>();
builder.Services.AddScoped<IRepositoryPatient, RepositoryPatient>();
builder.Services.AddScoped<IRepositoryVaccine, RepositoryVaccine>();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();