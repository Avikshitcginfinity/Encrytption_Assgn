using Microsoft.Data.Sqlite;

var connectionString = "Data Source=..\\encryption.db";
using var connection = new SqliteConnection(connectionString);
connection.Open();

using var tablesCommand = connection.CreateCommand();
tablesCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name";
using var tableReader = tablesCommand.ExecuteReader();
Console.WriteLine("Tables:");
while (tableReader.Read())
{
    Console.WriteLine(tableReader.GetString(0));
}

tableReader.Close();
Console.WriteLine();
Console.WriteLine("Users:");

using var usersCommand = connection.CreateCommand();
usersCommand.CommandText = "SELECT Id, Name, Email, Password FROM Users";
using var userReader = usersCommand.ExecuteReader();
while (userReader.Read())
{
    Console.WriteLine($"Id={userReader.GetInt32(0)}; Name={userReader.GetString(1)}; Email={userReader.GetString(2)}; Password={userReader.GetString(3)}");
}
