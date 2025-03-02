using WebAppServer.DAOs.MSSDAOs;
using WebAppServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region creando el contexto
builder.Services.AddSingleton<AlumnoMSSDAO>();
builder.Services.AddSingleton<UsuarioMSSDAO>();
builder.Services.AddSingleton<UsuarioRoleMSSDAO>();
builder.Services.AddSingleton<AlumnoService>();
builder.Services.AddSingleton<UsuarioService>();
builder.Services.AddSingleton<RolesService>();
#endregion
#region configuraci�n de restapi y swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion
#region identidad
builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.Cookie.Name = "Cookie_authenticacion";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(1);
    });

builder.Services.AddAuthorization();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "Cookie_session";
});

builder.Services.AddDataProtection();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

#region habilitando middleware adicionales
app.UseAuthentication(); //middleware para la autenticaci�n
app.UseAuthorization();  //middleware para la autorizaci�n
app.UseSession();        //middleware para la sesi�n
#endregion

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
