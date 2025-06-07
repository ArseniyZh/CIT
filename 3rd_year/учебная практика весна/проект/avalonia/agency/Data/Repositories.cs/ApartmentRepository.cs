using agency.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace agency.Data;

public class ApartmentRepository
{
    public List<ApartmentDto> GetAllApartments()
    {
        var apartments = new List<ApartmentDto>();

        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Area, Rooms, Floor FROM Apartments";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            apartments.Add(new ApartmentDto
            {
                Id = reader.GetInt32(0),
                Area = reader.GetDouble(1),
                Rooms = reader.GetInt32(2),
                Floor = reader.GetInt32(3)
            });
        }

        return apartments;
    }
}
