using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class VideogameManager
    {
        public static void InserisciVideogame(Videogame newVideogame)
        {
            string strConnessione = "Server=localhost;Database=adonet-db-videogame;Trusted_Connection=True;";

            using(VideogameContext db = new VideogameContext())
            {
                db.Add(newVideogame);
                db.SaveChanges();
            }
        }

        public static Videogame? RicercaPerId(long id)
        {
            string strConnessione = "Server=localhost;Database=adonet-db-videogame;Trusted_Connection=True;";

            using (SqlConnection connessione = new SqlConnection(strConnessione))
            {
                try
                {
                    connessione.Open();
                    Console.WriteLine("Connection Opened!");
                    string query = "SELECT * FROM videogames WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(query, connessione);
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string nome = (string)reader["name"];
                        string overview = (string)reader["overview"];
                        DateTime releaseDate = (DateTime)reader["release_date"];
                        long softwareHouse = (long)reader["software_house_id"];

                        //return new Videogame(nome, overview, releaseDate, softwareHouse);
                        return null;
                    }
                    return null;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public static List<Videogame>? RicercaPerNome(string name)
        {
            string strConnessione = "Server=localhost;Database=adonet-db-videogame;Trusted_Connection=True;";

            using (SqlConnection connessione = new SqlConnection(strConnessione))
            {
                try
                {
                    connessione.Open();
                    Console.WriteLine("Connection Opened!");
                    string query = "SELECT * FROM videogames WHERE name like '%' + @name + '%'";

                    SqlCommand cmd = new SqlCommand(query, connessione);
                    cmd.Parameters.Add(new SqlParameter("@name", name));

                    Videogame newVideogame;
                    List<Videogame> videogameList = new List<Videogame>();
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        while (reader.Read())
                        {

                            string nome = (string)reader["name"];
                            string overview = (string)reader["overview"];
                            DateTime releaseDate = (DateTime)reader["release_date"];
                            long softwareHouse = (long)reader["software_house_id"];

                            //newVideogame = new Videogame(nome, overview, releaseDate, softwareHouse);
                            //videogameList.Add(newVideogame);

                        }
                    }

                    return videogameList;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public static void CancellaVideogioco(long id)
        {
            string strConnessione = "Server=localhost;Database=adonet-db-videogame;Trusted_Connection=True;";

            using (SqlConnection connessione = new SqlConnection(strConnessione))
            {
                try
                {
                    connessione.Open();
                    Console.WriteLine("Connection Opened!");
                    string query = "DELETE FROM videogames WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(query, connessione);
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    int videogameRaw = cmd.ExecuteNonQuery();
                    if (videogameRaw == 1)
                    {
                        Console.WriteLine("Dato Eliminato!");
                    }
                    else
                    {
                        Console.WriteLine("Dato non eliminato!");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }
    }
}
