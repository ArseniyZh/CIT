using agency.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace agency.Data;

public class HouseRepository
{
    public List<HouseDto> GetAllHouses()
    {
        var houses = new List<HouseDto>();

        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Floors, Area FROM Houses";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            houses.Add(new HouseDto
            {
                Id = reader.GetInt32(0),
                Floors = reader.GetInt32(1),
                Area = reader.GetDouble(2)
            });
        }

        return houses;
    }
}
