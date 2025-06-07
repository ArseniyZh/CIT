namespace agency.Models;

public class ClientDto
{
    public int Id { get; set; }                 // Код клиента
    public string LastName { get; set; } = "";  // Фамилия
    public string FirstName { get; set; } = ""; // Имя
    public string MiddleName { get; set; } = ""; // Отчество
    public string Password { get; set; } = "";  // Пароль
    public string Phone { get; set; } = "";     // Номер телефона
    public string Email { get; set; } = "";     // Почта
}
