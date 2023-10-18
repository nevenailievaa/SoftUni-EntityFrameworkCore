using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server =.;Database=MinionsDB;Integrated Security = true");
connection.Open();

using (connection)
{
    Console.Write("Enter villain ID: "); // for clarity, not required
    int villainId = int.Parse(Console.ReadLine());

    GetVillainName(connection, villainId);
    GetMinionsNames(connection, villainId);
}

static void GetMinionsNames(SqlConnection connection, int villainId)
{
    SqlCommand command = GetSqlCommand(connection, "FindMinionsNames", villainId);
    SqlDataReader reader = command.ExecuteReader();

    using (reader)
    {
        int minionsCount = 0;
        while (reader.Read())
        {
            string minionName = (string)reader["Name"];
            int minionAge = (int)reader["Age"];
            Console.WriteLine($"{++minionsCount}. {minionName} {minionAge}");
        }
    }
}

static void GetVillainName(SqlConnection connection, int villainId)
{
    SqlCommand command = GetSqlCommand(connection, "FindVillainName", villainId);
    string villainName = (string)command.ExecuteScalar();
    if (villainName == null)
        Console.WriteLine($"No villain with ID {villainId} exists in the database.");
    else
        Console.WriteLine($"Villain: {villainName}");
}

static SqlCommand GetSqlCommand(SqlConnection connection, string fileName, int villainId)
{
    string query = File.ReadAllText($@"../../{fileName}.sql");
    SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@villainId", villainId);
    return command;
}