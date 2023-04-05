using Microsoft.EntityFrameworkCore;
using MVCproject.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // core uygulamalar�nda mvc mimarisi kullanabilmek i�in uygulamada controller ve view yap�lanmalar�n�n  eklemesi gerekir
                                            //bununi�in �ncelikle bu servis uygulamaya ekleiyor ./servisler uygulama i�erisinde kullan�lacak olan s�n�f ve k�t�phanelerdir)
builder.Services.AddDbContext<ToDoContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnectionString"))); //database servisini kullanabilmek i�in eklememzi gereken srvis.



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//ara katmanlar� ara yaz�l�mlar buradad�r burada �a��r�r�z.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();// routing mvc pipelininda gelen istei�in rotas�n� yani hangi iste�in nereye y�nlendirilece�ini belirler
                 // burada gelen iste�in rotas� middlleware yani ara katmanlar sayesinde belirlenir.

app.UseAuthorization();


// burada istek yap�ld���nda izlenecek olan temel default rotay� belirliyor.default olan rota �emam�z  
//istekler bu �emaya uygun bir �ekilde yap�lmal�d�r.hangi kontroller�n hangi action� tetiklenecek belirlenmi� oluyor.  
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomeView}/{id?}");


//app.MapGet("/", () =>
//{
//    return "cfsdsd";
//});

app.Run();
