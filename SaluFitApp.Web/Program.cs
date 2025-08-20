using SaluFitApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// <-- Aquí registras mocks en lugar de DbContext -->
builder.Services.AddSingleton<FakePacienteService, FakePacienteService>();
builder.Services.AddSingleton<FakeCitaService, FakeCitaService>();
builder.Services.AddScoped<FakeNotaService>(); //Según ChatGPT es Scoped porqué con Singleton hay peligro de que las instancias se compartan entre ususarios y unos vean los datos de los otros

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Dashboard/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");


app.Run();
