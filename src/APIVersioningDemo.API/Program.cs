using Asp.Versioning;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(option =>
{
	option.AssumeDefaultVersionWhenUnspecified = true;
	option.DefaultApiVersion = new ApiVersion(1,0);
	option.ReportApiVersions = true;
	option.ApiVersionReader = ApiVersionReader.Combine(
			new QueryStringApiVersionReader("api-version"),
			new HeaderApiVersionReader("X-Version"),
			new MediaTypeApiVersionReader("ver"));
}).AddApiExplorer(option =>
{
	option.GroupNameFormat = "'v'VVV";
	option.SubstituteApiVersionInUrl = true; 
});

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
