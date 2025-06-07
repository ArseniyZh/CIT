using agency.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace agency.Data;

public class AddressRepository
{
    public List<AddressDto> GetAllAddresses()
    {
        var addresses = new List<AddressDto>();

        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, City, Street, House, Building FROM Addresses";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            addresses.Add(new AddressDto
            {
                Id = reader.GetInt32(0),
                City = reader.GetString(1),
                Street = reader.GetString(2),
                House = reader.GetString(3),
                Building = reader.IsDBNull(4) ? "" : reader.GetString(4)
            });
        }

        return addresses;
    }
}
