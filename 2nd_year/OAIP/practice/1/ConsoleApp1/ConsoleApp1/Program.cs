using ClassLibrary1;

class Program
{
    static void Main(string[] args)
    {
        // Создание объекта Book
        Book myBook = new Book("1984", "George Orwell", "Secker & Warburg", 1949);
        myBook.SetPrice(9.99m);
        myBook.DisplayInfo();

        // Создание объекта Textbook
        Textbook myTextbook = new Textbook(
            "Mathematics for Machine Learning",
            "Marc Peter Deisenroth",
            "Cambridge University Press",
            2020,
            "Machine Learning",
            "University"
        );
        myTextbook.SetPrice(39.99m);
        myTextbook.DisplayInfo();
        myTextbook.UpdateSubject("Advanced Machine Learning");
        myTextbook.UpdateGradeLevel("Postgraduate");
        myTextbook.DisplayInfo();

        // Демонстрация скрытого метода и дополнительной информации
        myTextbook.GetInfo();
        myTextbook.AdditionalInfo();
    }
}
