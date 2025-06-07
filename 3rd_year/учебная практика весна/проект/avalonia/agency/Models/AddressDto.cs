namespace agency.Models;

public class AddressDto
{
    public int Id { get; set; }              // Код объекта
    public string City { get; set; } = "";   // Город
    public string Street { get; set; } = ""; // Улица
    public string House { get; set; } = "";  // Дом
    public string Building { get; set; } = ""; // Корпус
}
