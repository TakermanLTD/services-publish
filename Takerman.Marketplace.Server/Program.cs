using Takerman.Marketplace.Server.Middleware;
using Takerman.Marketplace.Services.Configuration;
using Takerman.Marketplace.Services.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

var config = new PlatformsConfig();
var platformsSection = builder.Configuration.GetSection(nameof(PlatformsConfig));
platformsSection.Bind(config);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.Configure<PlatformsConfig>(platformsSection);
builder.Services.AddTransient<IPublishService, PublishService>();
builder.Services.AddHttpClient<AlobgService>();

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
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