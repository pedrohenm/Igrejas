using Infrastructure.Extensoes;
using WebAPIS.Configuracoes;
using WebAPIS.Extensoes.IServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ConfigServices
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.IncluirPostgreSqlServico(builder.Configuration);
builder.Services.IncluirConfiguracaoIdentityServico(builder.Configuration);

//INTERFACE E REPOSITORIO
//builder.Services.AddSingleton()
builder.Services.IncluirV1Servicos();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var urlDev = "";
//var urlHML = "";
//var urlPROD = "";

//app.UseCors(p => p.WithOrigins(urlDev, urlHML, urlPROD));

var devClient = "http://localhost:4200";
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();
