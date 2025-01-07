//Завдання 4
//Необхідно написати вебзастосунок, який надаватиме можливість
//маніпулювати даними, які зв'язані з авторами та їхніми книгами.
//Автор має такі атрибути:
//● Прізвище(текст, обов'язкове).
//● Ім'я (текст, обов'язкове).
//● По батькові(текст, необов'язкове).
//● Дата народження (дата, обов'язкова).
//● Список книг.
//Книга має такі атрибути:
//● Назва(текст, обов'язкова).
//● Кількість сторінок(число, обов'язкове).
//● Жанр(текст, обов'язковий, зі списку допустимих значень).

//3

//Потрібно реалізувати можливість додавати, видаляти та редагувати
//авторів.Необхідно реалізувати можливість додавати, видаляти та
//редагувати книги.
//На всіх формах має бути реалізована валідація.
//Користувацький інтерфейс має бути інтуїтивно зрозумілим.
using Library.Models;
using Library.Repository;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddControllers();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



            var app = builder.Build();


            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Author}/{action=Index}");

            app.Run();
        }
    }
}
