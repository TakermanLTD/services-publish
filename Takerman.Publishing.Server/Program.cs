using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Slack.Models;
using Serilog.Sinks.Slack;
using System.Reflection;
using System.Security.Claims;
using Takerman.Mail;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Initialization;
using Takerman.Publishing.Server.Middleware;
using Takerman.Publishing.Services.Services;
using Takerman.Publishing.Services.Services.Abstraction;

var builder = WebApplication.CreateBuilder(args);
var dataAssembly = "Takerman.Publishing.Data";
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Slack(new SlackSinkOptions
    {
        WebHookUrl = "https://hooks.slack.com/services/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",
        CustomIcon = ":postal_horn:",
        Period = TimeSpan.FromSeconds(10),
        ShowDefaultAttachments = false,
        ShowExceptionAttachments = true,
        MinimumLogEventLevel = LogEventLevel.Error,
        PropertyDenyList = ["Level", "SourceContext"]
    })
    .CreateLogger();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
            .WithOrigins("https://localhost:5175")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

builder.Host.UseSerilog(Log.Logger);
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DefaultContext>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(dataAssembly));
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});
builder.Services.AddTransient<DbContext, DefaultContext>();
builder.Services.AddTransient<IPlatformsService, PlatformsService>();
builder.Services.AddTransient<IPlatformLinksService, PlatformLinksService>();
builder.Services.AddTransient<IPlatformPostTypesService, PlatformPostTypesService>();
builder.Services.AddTransient<IPlatformSecretsService, PlatformSecretsService>();
builder.Services.AddTransient<IProjectSecretsService, ProjectSecretsService>();
builder.Services.AddTransient<IPostsService, PostsService>();
builder.Services.AddTransient<IPostTypesService, PostTypesService>();
builder.Services.AddTransient<IProjectsService, ProjectsService>();
builder.Services.AddTransient<IContextInitializer, ContextInitializer>();
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddAutoMapper(Assembly.Load(dataAssembly));
builder.Services.Configure<RabbitMqConfig>(builder.Configuration.GetSection(nameof(RabbitMqConfig)));
builder.Services.AddHttpClient();
var domain = $"https://{builder.Configuration["Auth0:Domain"]}/";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.Authority = domain;
    options.Audience = builder.Configuration["Auth0:Audience"];
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = ClaimTypes.NameIdentifier
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
});

builder.Services.AddControllers();
builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

using var scope = app.Services.CreateAsyncScope();
await scope.ServiceProvider.GetRequiredService<IContextInitializer>().InitializeAsync();

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseCors("AllowSpecificOrigin");
app.Use(async (context, next) =>
{
    // context.Response.Headers.Add("Content-Security-Policy", "default-src 'self';");
    context.Response.Headers.TryAdd("Cache-Control", "no-cache, no-store, must-revalidate");
    context.Response.Headers.TryAdd("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");
    context.Response.Headers.TryAdd("Referrer-Policy", "no-referrer");
    context.Response.Headers.TryAdd("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
    context.Response.Headers.TryAdd("X-Developed-By", "Takerman Ltd");
    context.Response.Headers.TryAdd("X-Content-Type-Options", "nosniff");
    context.Response.Headers.TryAdd("X-Frame-Options", "DENY");
    context.Response.Headers.TryAdd("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.TryAdd("X-Permitted-Cross-Domain-Policies", "none");
    context.Response.Headers.TryAdd("X-Powered-By", "Takerman");
    await next();
});
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();