using Microsoft.EntityFrameworkCore;
using MVCproject.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // core uygulamalarýnda mvc mimarisi kullanabilmek için uygulamada controller ve view yapýlanmalarýnýn  eklemesi gerekir
                                            //bununiçin öncelikle bu servis uygulamaya ekleiyor ./servisler uygulama içerisinde kullanýlacak olan sýnýf ve kütüphanelerdir)
builder.Services.AddDbContext<ToDoContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnectionString"))); //database servisini kullanabilmek için eklememzi gereken srvis.



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//ara katmanlarý ara yazýlýmlar buradadýr burada çaðýrýrýz.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();// routing mvc pipelininda gelen isteiðin rotasýný yani hangi isteðin nereye yönlendirileceðini belirler
                 // burada gelen isteðin rotasý middlleware yani ara katmanlar sayesinde belirlenir.

app.UseAuthorization();


// burada istek yapýldýðýnda izlenecek olan temel default rotayý belirliyor.default olan rota þemamýz  
//istekler bu þemaya uygun bir þekilde yapýlmalýdýr.hangi kontrollerýn hangi actioný tetiklenecek belirlenmiþ oluyor.  
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomeView}/{id?}");


//app.MapGet("/", () =>
//{
//    return "cfsdsd";
//});

app.Run();
