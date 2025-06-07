using agency.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace agency.Data;

public class LandRepository
{
    public List<LandDto> GetAllLands()
    {
        var lands = new List<LandDto>();

        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Area FROM Lands";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            lands.Add(new LandDto
            {
                Id = reader.GetInt32(0),
                Area = reader.GetInt32(1)
            });
        }

        return lands;
    }
}
