using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RIS_Api.Extensions;
using RIS_Api.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Add CORS Policies to Service
// CORS
string allowOriginsText = builder.Configuration["CORS:AllowOrigins"];
string[] allowOrigins = allowOriginsText.Split(",", StringSplitOptions.RemoveEmptyEntries);
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "LaroApiCorsPolicy",
        builder =>
            builder
                .AllowAnyHeader()
                .WithOrigins(allowOrigins)
                .WithMethods(
                    HttpMethod.Get.Method,
                    HttpMethod.Post.Method,
                    HttpMethod.Delete.Method,
                    HttpMethod.Options.Method
                )
                .AllowCredentials()
    );

    options.AddPolicy(
        "LaroHubCorsPolicy",
        builder => builder.AllowAnyHeader().WithOrigins(allowOrigins).AllowAnyMethod()
    );
});
#endregion

var connectionString =
    builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringSettings>();

#region Service Set Connection Strings
// Service Set Connection Strings
builder.Services.Configure<ConnectionStringSettings>(options =>
{
    options.Default = connectionString.Default;
    options.eBaoLSStaging = connectionString.eBaoLSStaging;

});


#endregion

var urlConfig =
    builder.Configuration.GetSection("ParameterConfig").Get<ParameterConfig>();
var whereConfig =
    builder.Configuration.GetSection("WhereConfig").Get<WhereConfig>();

#region Service Set Connection Strings
// Service Set Connection Strings
builder.Services.Configure<ParameterConfig>(options =>
{
    options.apiAuthenToken = urlConfig.apiAuthenToken;
    options.AppSecretKey = urlConfig.AppSecretKey;
    options.APPID = urlConfig.APPID;

});

builder.Services.Configure<WhereConfig>(options =>
{
    options.userNotIn = whereConfig.userNotIn;

});

#endregion


// Add services to the container.
builder.Services.InjectServicesCollection();
builder.Services.AddHttpContextAccessor();
// builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

// Use Cores Before Set Static Files
app.UseCors("LaroApiCorsPolicy");
app.Run();
