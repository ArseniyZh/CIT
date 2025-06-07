namespace agency.Models;

public class AgentDto
{
    public int Id { get; set; }                 // Код агента
    public string LastName { get; set; } = "";  // Фамилия
    public string FirstName { get; set; } = ""; // Имя
    public string MiddleName { get; set; } = ""; // Отчество
    public string Password { get; set; } = "";  // Пароль
    public double CommissionRate { get; set; }  // Процент
}

