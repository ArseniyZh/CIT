using agency.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace agency.Data;

public class DistrictRepository
{
    public List<DistrictDto> GetAllDistricts()
    {
        var districts = new List<DistrictDto>();

        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Name, Area FROM Districts";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            districts.Add(new DistrictDto
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Area = reader.GetString(2)
            });
        }

        return districts;
    }
}
