using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class UserManager : Manager
    {
        public void create(
            string name,
            string surname,
            string dateOfBirth,
            string email,
            string phoneNumber,
            string rangeOfScience,
            string dateOfFirstPost,
            string login,
            string password
        )
        {
            using (var context = new UserContext())
            {
                var user = new User {
                    Name = name,
                    Surname = surname,
                    DateOfBirth = DateTime.Parse(dateOfBirth),
                    Email = email,
                    PhoneNumber = phoneNumber,
                    RangeOfScience = rangeOfScience,
                    DateOfFirstPost = DateTime.Parse(dateOfFirstPost),
                    Login = login,
                    Password = this.hashedString(password)
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public User get(Dictionary<string, object> criteria)
        {
            using (var context = new UserContext())
            {
                // Начинаем с всех пользователей
                IQueryable<User> query = context.Users;

                // Динамически строим запрос на основе критериев
                foreach (var criterion in criteria)
                {
                    var parameter = Expression.Parameter(typeof(User), "user");
                    var property = Expression.Property(parameter, criterion.Key);
                    var constant = Expression.Constant(criterion.Value);
                    var equals = Expression.Equal(property, constant);
                    var lambda = Expression.Lambda<Func<User, bool>>(equals, parameter);

                    query = query.Where(lambda);
                }

                // Выполняем запрос и возвращаем результат
                return query.FirstOrDefault(); // Возвращает первый найденный объект или null, если ничего не найдено
            }
        }
    }
}
