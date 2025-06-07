using agency.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace agency.Data;

public class AgentRepository
{
    public List<AgentDto> GetAllAgents()
    {
        var agents = new List<AgentDto>();

        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Agents";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            agents.Add(new AgentDto
            {
                Id = reader.GetInt32(0),
                LastName = reader.GetString(1),
                FirstName = reader.GetString(2),
                MiddleName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                Password = reader.IsDBNull(4) ? "" : reader.GetString(4),
                CommissionRate = reader.IsDBNull(5) ? 0 : reader.GetDouble(5)
            });
        }

        return agents;
    }

    public void AddAgent(AgentDto agent)
    {
        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        """
        INSERT INTO Agents (LastName, FirstName, MiddleName, Password, CommissionRate)
        VALUES ($lastName, $firstName, $middleName, $password, $commissionRate)
        """;

        command.Parameters.AddWithValue("$lastName", agent.LastName);
        command.Parameters.AddWithValue("$firstName", agent.FirstName);
        command.Parameters.AddWithValue("$middleName", agent.MiddleName);
        command.Parameters.AddWithValue("$password", agent.Password);
        command.Parameters.AddWithValue("$commissionRate", agent.CommissionRate);

        command.ExecuteNonQuery();
    }

    public void UpdateAgent(AgentDto agent)
    {
        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        """
        UPDATE Agents
        SET LastName = $lastName,
            FirstName = $firstName,
            MiddleName = $middleName,
            Password = $password,
            CommissionRate = $commissionRate
        WHERE Id = $id
        """;

        command.Parameters.AddWithValue("$id", agent.Id);
        command.Parameters.AddWithValue("$lastName", agent.LastName);
        command.Parameters.AddWithValue("$firstName", agent.FirstName);
        command.Parameters.AddWithValue("$middleName", agent.MiddleName);
        command.Parameters.AddWithValue("$password", agent.Password);
        command.Parameters.AddWithValue("$commissionRate", agent.CommissionRate);

        command.ExecuteNonQuery();
    }

    public void DeleteAgent(int id)
    {
        using var connection = Database.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Agents WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }
}
