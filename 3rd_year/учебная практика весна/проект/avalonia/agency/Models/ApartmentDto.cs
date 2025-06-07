namespace agency.Models;

public class ApartmentDto
{
    public int Id { get; set; }            // Код квартиры
    public double Area { get; set; }       // Площадь
    public int Rooms { get; set; }         // Количество комнат
    public int Floor { get; set; }         // Этаж
}
