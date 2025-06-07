using agency.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace agency.Data;

public class ClientRepository
{
    public List<ClientDto> GetAllClients()
    {
        var clients = new List<ClientDto>();

        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Clients";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            clients.Add(new ClientDto
            {
                Id = reader.GetInt32(0),
                LastName = reader.GetString(1),
                FirstName = reader.GetString(2),
                MiddleName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                Password = reader.IsDBNull(4) ? "" : reader.GetString(4),
                Phone = reader.IsDBNull(5) ? "" : reader.GetString(5),
                Email = reader.IsDBNull(6) ? "" : reader.GetString(6)
            });
        }

        return clients;
    }

    public void AddClient(ClientDto client)
    {
        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        """
        INSERT INTO Clients (LastName, FirstName, MiddleName, Password, Phone, Email)
        VALUES ($lastName, $firstName, $middleName, $password, $phone, $email)
        """;

        command.Parameters.AddWithValue("$lastName", client.LastName);
        command.Parameters.AddWithValue("$firstName", client.FirstName);
        command.Parameters.AddWithValue("$middleName", client.MiddleName);
        command.Parameters.AddWithValue("$password", client.Password);
        command.Parameters.AddWithValue("$phone", client.Phone);
        command.Parameters.AddWithValue("$email", client.Email);

        command.ExecuteNonQuery();
    }

    public void UpdateClient(ClientDto client)
    {
        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        """
        UPDATE Clients
        SET LastName = $lastName,
            FirstName = $firstName,
            MiddleName = $middleName,
            Password = $password,
            Phone = $phone,
            Email = $email
        WHERE Id = $id
        """;

        command.Parameters.AddWithValue("$id", client.Id);
        command.Parameters.AddWithValue("$lastName", client.LastName);
        command.Parameters.AddWithValue("$firstName", client.FirstName);
        command.Parameters.AddWithValue("$middleName", client.MiddleName);
        command.Parameters.AddWithValue("$password", client.Password);
        command.Parameters.AddWithValue("$phone", client.Phone);
        command.Parameters.AddWithValue("$email", client.Email);

        command.ExecuteNonQuery();
    }

    public void DeleteClient(int id)
    {
        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Clients WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }
}
