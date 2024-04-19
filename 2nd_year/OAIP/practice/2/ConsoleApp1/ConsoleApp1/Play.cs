using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Play
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Date { get; set; }

        public Play(int number, string title, string director, string date)
        {
            Number = number;
            Title = title;
            Director = director;
            Date = date;
        }

        public void Display()
        {
            Console.WriteLine($"Номер: {Number}, Название: {Title}, Режиссёр: {Director}, Дата: {Date}");
        }
    }
}
