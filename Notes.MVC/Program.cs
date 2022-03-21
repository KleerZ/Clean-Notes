using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Notes.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddUnobtrusiveAjax();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.Authority = "https://localhost:44366";
        options.RequireHttpsMetadata = false;
        options.ClientId = "clean-notes";
        options.SaveTokens = true;
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.Scope.Add("openid");
        options.Scope.Add("profile");
    });

builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Notes.Ide.Cooke";
    config.LoginPath = "http://localhost:44339/signin-oidc";
    config.LogoutPath = "http://localhost:44339/signout-oidc";
});

builder.Services.AddCors(p =>
{
    p.AddPolicy("AllowAll", c =>
    {
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseUnobtrusiveAjax();

app.UseRouting(); 

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var context = serviceProvider.GetRequiredService<NoteDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception e)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "An error occurred while app initialization");
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .RequireAuthorization();

app.Run();