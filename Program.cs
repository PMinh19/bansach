using BanSach.Components;
using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;
using BanSach.Components.Data;
using Microsoft.Extensions.DependencyInjection;
using BanSach.Components.Services;
using BanSach.Components.IService;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMudServices();
builder.Services.AddScoped <IItemManagement, ItemManagement>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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

app.UseAuthorization();

app.MapRazorPages(); // Ánh xạ Razor Pages

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
