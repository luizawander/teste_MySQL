using MySql.Data.MySqlClient;
using System;
using Microsoft.Extensions.Configuration; // Adicione esta linha


class Program
{
    static void Main()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string connectionString = configuration.GetConnectionString("DefaultConnection");

        using MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        string sqlQuery = "SELECT nome_Cliente, email_Cliente FROM cliente";
        using MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

         using MySqlDataReader reader = cmd.ExecuteReader();
        Console.WriteLine("Conexão bem-sucedida!");
        // Processar os resultados
         while (reader.Read())
        {
        string nome = reader.GetString("nome_Cliente");
        string email = reader.GetString("email_Cliente"); // Correção aqui

         Console.WriteLine($"Nome: {nome}, email: {email}");
         }
    }
}