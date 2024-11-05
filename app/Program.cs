using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MudBlazor.Services;
using urfit_presence.Components;
using urfit_presence.Components.Account;
using urfit_presence.Data;
using MudExtensions.Services;
using urfit_presence;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();
builder.Services.AddMudExtensions();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Add configuration
builder.Configuration.AddUserSecrets<Program>();

// Add connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<ApplicationDbInitializer>();


// Add identity and authentication
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
       {
           options.DefaultScheme = IdentityConstants.ApplicationScheme;
           options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
       })
       .AddIdentityCookies();

builder.Services
       .AddIdentityCore<ApplicationUser>(options => 
                                             options.SignIn.RequireConfirmedAccount = false
                                         
                                         )
       .AddRoles<IdentityRole>()
       .AddEntityFrameworkStores<ApplicationDbContext>()
       .AddSignInManager()
       .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

// Add email service
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();


// Add informer connection
builder.Services.AddHttpClient();

builder.Services.Configure<InformerApiOptions>(builder.Configuration.GetSection("InformerApi"));
var informerApiOptions = builder.Configuration.GetSection("InformerApi").Get<InformerApiOptions>();
builder.Services.AddSingleton<IFlurlClientCache>(sp => new FlurlClientCache()
                                                     .Add("InformerApi"
                                                          , informerApiOptions.BaseUrl
                                                          , c => c.WithHeaders(new
                                                                               {
                                                                                   Apikey = informerApiOptions.ApiKey, 
                                                                                   Securitycode = informerApiOptions.SecurityCode
                                                                               })));

builder.Services.AddScoped<SubscriptionService>();
// Build the app
var app = builder.Build();

// Initialize the application

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    var applicationDbInitializer =  scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>();
    await applicationDbInitializer.SeedUsersAndRolesAsync();

    var subscriptionService = scope.ServiceProvider.GetRequiredService<SubscriptionService>();
    await subscriptionService.SyncSubscriptionsToUsers();
}

// Run the application
app.Run();