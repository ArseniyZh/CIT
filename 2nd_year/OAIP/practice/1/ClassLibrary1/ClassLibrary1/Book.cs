using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        private decimal price;

        public Book(string title, string author, string publisher, int year)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Year = year;
        }

        public void DisplayInfo()
        {
            Console.WriteLine(
                $"Названик: {Title}, " +
                $"Автор: {Author}, " +
                $"Издатель: {Publisher}, " +
                $"Год: {Year}, " +
                $"Цена: {price:C}"
                );
        }

        public void UpdateYear(int newYear)
        {
            Year = newYear;
        }

        public void SetPrice(decimal newPrice)
        {
            price = newPrice;
        }

        public decimal GetPrice()
        {
            return price;
        }
    }

}
