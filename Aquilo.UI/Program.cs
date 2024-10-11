using Aquilo.UI.Components;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder
    .Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory(cb =>
    {
        // Rejestracja us³ugi PluginProvider w Autofac
        cb.RegisterType<Aquilo.UI.PluginProvider>()
          .AsSelf()
          .InstancePerLifetimeScope(); // Zakres zale¿noœci (tutaj scoped)

        foreach (var file in Directory.GetFiles(
            AppDomain.CurrentDomain.BaseDirectory,
            "*plugin*.dll",
            SearchOption.TopDirectoryOnly))
        {
            var assembly = Assembly.LoadFrom(file);
            cb.RegisterAssemblyModules(assembly);
        }
    }))
    .ConfigureServices(services => services.AddAutofac());

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
