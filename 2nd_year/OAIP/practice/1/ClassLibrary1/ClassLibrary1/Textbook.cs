using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Textbook : Book
    {
        public string Subject { get; set; }
        public string GradeLevel { get; set; }

        public Textbook(
            string title, 
            string author, 
            string publisher, 
            int year, 
            string subject, 
            string gradeLevel
            )
            : base(title, author, publisher, year)
        {
            Subject = subject;
            GradeLevel = gradeLevel;
        }

        public new void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Предмет: {Subject}, Класс: {GradeLevel}");
        }

        public new void SetPrice(decimal newPrice)
        {
            base.SetPrice(newPrice);
        }

        public void UpdateSubject(string newSubject)
        {
            Subject = newSubject;
        }

        public void UpdateGradeLevel(string newLevel)
        {
            GradeLevel = newLevel;
        }

        public new void GetInfo()
        {
            Console.WriteLine("Скрыт");
        }

        public void AdditionalInfo()
        {
            Console.WriteLine("Скрыт");
        }
    }

}
