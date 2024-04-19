using ConsoleApp1;

Theatre theatre = new Theatre();
bool exit = false;

while (!exit)
{
    string menu = "1) Добавить новую постановку\n" +
                  "2) Удалить последнюю постановку\n" +
                  "3) Показать все постановки\n" +
                  "4) Показать количество постановок\n" +
                  "5) Удалить все поставноки\n" +
                  "0) Выйти\n";

    Console.Write($"{menu}\nВведите вариант выбора: ");

    string input = Console.ReadLine();
    Console.Write($"\n");
    switch (input)
    {
        case "1":
            Console.Write("Номер постановки: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.Write("Вы ввели некорректное название!\n");
                break;
            }
            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Постановщик: ");
            string director = Console.ReadLine();
            Console.Write("Дата: ");
            string date = Console.ReadLine();
            theatre.AddPlay(new Play(number, title, director, date));
            break;
        case "2":
            theatre.DeleteLastPlay();
            break;
        case "3":
            theatre.DisplayAll();
            break;
        case "4":
            theatre.ShowCount();
            break;
        case "5":
            theatre.Clear();
            break;
        case "0":
            exit = true;
            break;
        default:
            Console.WriteLine("Неверный вариант, попробуйте еще раз.\n");
            break;
    }
    Console.Write($"\n");
}
