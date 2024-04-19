using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Utils
    {
        public static List<int> GenerateRandomList(int n)
        {
            Random random = new Random(); // Создаем экземпляр генератора случайных чисел
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(random.Next(0, 100)); // Генерируем случайное число от 0 до 99
            }

            return list;
        }
    }
}
