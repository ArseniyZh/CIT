using agency.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace agency.Data;

public class DealRepository
{
    public List<DealDto> GetAllDeals()
    {
        var deals = new List<DealDto>();

        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Title FROM Deals";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            deals.Add(new DealDto
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1)
            });
        }

        return deals;
    }
}
