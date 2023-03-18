using Identity.Clients;
using Identity.Factories;
using Identity.Services;
using Refit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();  

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void ConfigureServices(IServiceCollection services)
{
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddControllers();
    services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    builder.Services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.EnableAnnotations();
        c.SwaggerDoc("v1", new() { Title = "Identity", Version = "v1" });
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    });

    builder.Services.AddRefitClient<IAgifyClient>()
        .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.agify.io/"));
    builder.Services.AddRefitClient<IGenderizeClient>()
        .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.genderize.io/"));
    builder.Services.AddRefitClient<INationalizeClient>()
        .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.nationalize.io/"));

    builder.Services.AddScoped<IAgeBracketFactory, AgeBracketFactory>();
    builder.Services.AddScoped<IIdentityService, IdentityService>();
}