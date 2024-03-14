using System.Text;
using System.Reflection;
using Amg_Ingressos_aqui_notificacao_api.Consts;
using Amg_Ingressos_aqui_notificacao_api.Infra;
using Amg_Ingressos_aqui_notificacao_api.Infra.Interfaces;
using Amg_Ingressos_aqui_notificacao_api.Model;
using Amg_Ingressos_aqui_notificacao_api.Repository;
using Amg_Ingressos_aqui_notificacao_api.Repository.Interfaces;
using Amg_Ingressos_aqui_notificacao_api.Services;
using Amg_Ingressos_aqui_notificacao_api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Template Api",
        Description = "Template de api para testes",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.Configure<NotificationDatabaseSettings>(
    builder.Configuration.GetSection("NotificationDatabase"));
builder.Services.Configure<ServicesSettings>(
    builder.Configuration.GetSection("ServicesSettings"));

builder.Services.Configure<MvcOptions>(options =>
{
    options.ModelMetadataDetailsProviders.Add(
        new SystemTextJsonValidationMetadataProvider());
});

// injecao de dependencia
//services
builder.Services.AddScoped<INotificationService, NotificationService>();
//repository
builder.Services.AddScoped<ICrudRepository<Notification>, CrudRepository<Notification>>();
//infra
builder.Services.AddScoped<IDbConnection, DbConnection>();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();
app.UseStaticFiles(); // Certifique-se de ter essa linha
app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<NotificationExceptionHandlerMiddleaware>();
app.Run();
