using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string for SQL Server Express with default database
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

        
        // Query to fetch all rows from Test1 table
        string query = "SELECT * FROM Test1";

        try
        {
            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the command and get a data reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if the reader has any rows
                        if (reader.HasRows)
                        {
                            // Read and output each row
                            while (reader.Read())
                            {
                                // Example output: adapt to your table structure
                                Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}, Data: {reader["Data"]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found in the Test1 table.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Output any errors
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
