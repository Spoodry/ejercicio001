using System;
using MySql.Data.MySqlClient;

namespace Ejercicio001
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0) {
                switch(int.Parse(args[0])) {
                    case 0:
                        System.Console.WriteLine("Conexión");
                        String conexion = "datasource=127.0.0.1;port=3306;username=root;password=mypass;database=mvc";

                        String query = "SELECT * FROM alumnos";

                        MySqlConnection databaseConnection = new MySqlConnection(conexion);
                        MySqlCommand command = new MySqlCommand(query, databaseConnection);
                        command.CommandTimeout = 60;
                        
                        MySqlDataReader reader;

                        try {
                            databaseConnection.Open();
                            reader = command.ExecuteReader();

                            if(reader.HasRows) {
                                while(reader.Read()) {
                                    System.Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
                                }
                            } else {
                                Console.WriteLine("No se encontraron datos.");
                            }

                            databaseConnection.Close();

                        } catch(Exception e) {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    default:
                        System.Console.WriteLine("Opción no válida");
                        break;
                }

            } else {
                Console.WriteLine("Hello World! ");
            }
        }
    }
}
