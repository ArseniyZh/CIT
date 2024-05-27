using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab3.Models;

namespace lab3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Ex1(string var_a, string var_b)
    {
        // Логика обмена значениями
        string temp = var_a;
        var_a = var_b;
        var_b = temp;

        // Передать измененные данные обратно в представление
        ViewBag.VarA = var_a;
        ViewBag.VarB = var_b;

        return View();
    }

    public IActionResult Ex2(string sentence1, string sentence2)
    {
        if (sentence1 != null & sentence2 != null)
        {
            int countN = CountN(sentence1) + CountN(sentence2);
            ViewBag.CountN = countN;
        }
        return View();
    }

    private int CountN(string sentence)
    {
        return sentence.Count(c => c == 'н' || c == 'Н');
    }


    public IActionResult Ex3()
    {
        int[,] matrix = new int[9, 9];
        Random rand = new Random();
        double[] averages = new double[9];

        // Заполняем матрицу случайными числами и считаем среднее четных чисел для каждой строки
        for (int i = 0; i < 9; i++)
        {
            int sum = 0;
            int count = 0;
            for (int j = 0; j < 9; j++)
            {
                matrix[i, j] = rand.Next(10, 31); // Случайные числа от 10 до 30
                if (matrix[i, j] % 2 == 0)
                {
                    sum += matrix[i, j];
                    count++;
                }
            }
            averages[i] = count > 0 ? (double)sum / count : 0;
        }

        ViewBag.Matrix = matrix;
        ViewBag.Averages = averages;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

