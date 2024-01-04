using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HealthCare.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/"); // Secures the root folder, requiring authorization by default
});
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<FeedbackService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<BookingService>();

// Configure Auth0 Authentication
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "Auth0";
    })
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // Set to your login path
        options.LogoutPath = "/logout"; // Set to your logout path
    })
    .AddOpenIdConnect("Auth0", options =>
    {
        // Set the authority to your Auth0 domain
        options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";

        // Configure the Auth0 Client ID and Client Secret
        options.ClientId = builder.Configuration["Auth0:ClientId"];
        options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];

        // Set response type to code
        options.ResponseType = "code";

        // Configure the scope
        options.Scope.Clear();
        options.Scope.Add("openid");

        // Set the callback path, so Auth0 will call back to http://localhost:3000/callback
        // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard 
        options.CallbackPath = new PathString("/callback");

        // Configure the Claims Issuer to be Auth0
        options.ClaimsIssuer = "Auth0";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // First, set up routing

app.UseAuthentication(); // Then, set up authentication
app.UseAuthorization(); // Then, set up authorization

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
