using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using pruebaTecnicaEdynamicsLog.Aplication.Middleware;
using pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers;
using pruebaTecnicaEdynamicsLog.Domain.Entities.Productos;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;
using pruebaTecnicaEdynamicsLog.Extenciones;
using pruebaTecnicaEdynamicsLog.Infrastructure.Servicios;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContextOrgsYUsers>(options => options.UseSqlServer(
   builder.Configuration.GetConnectionString("OrgsYUsersConectionString")
    ));
builder.Services.AddDbContext<DbContextProductos>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("productosDefaultConectionString")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISeguridadService, SeguridadService>();
builder.Services.AddScoped<ICurrentTenantService, CurrentTenantService>();
builder.Services.AddAndMigrateTenantDatabases(builder.Configuration);

builder.Services.AddTransient<IOrganizacionService, OrganizacionService>();
builder.Services.AddTransient<IProductService, ProductoService>();




var llave = Encoding.ASCII.GetBytes("estaEsLaLlavePrivadaDelServidorYDebeSerMuyLargaYNopuedeEstarQuemadaEnElCodigo");//esta llave debe estar asegurada enlas variables de entorno
builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(d =>
{
    d.RequireHttpsMetadata = false;
    d.SaveToken = true;
    d.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(llave),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
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
app.UseMiddleware<TenantResolver>();

app.MapControllers();

app.Run();
