using Microsoft.EntityFrameworkCore;
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

            using(VideogameContext db = new VideogameContext())
            {
                db.Add(newVideogame);
                db.SaveChanges();
            }
        }

        public static Videogame? RicercaPerId(long id)
        {

            Videogame videogameSearched;

            using (VideogameContext db = new VideogameContext())
            {
                videogameSearched = db.Videogame.Where(videogame => videogame.Id == id).First();
            }

            return videogameSearched;

        }

        public static List<Videogame>? RicercaPerNome(string name)
        {
            List <Videogame> videogames = new List<Videogame>();
            using (VideogameContext db = new VideogameContext())
            {
               videogames = db.Videogame.Where(videogame => videogame.Name.Contains(name)).ToList();
            }
            return videogames;
             
        }
        public static void CancellaVideogioco(long id)
        {
            using (VideogameContext db = new VideogameContext())
            {
                Videogame videogame = db.Videogame.Where(videogame => videogame.Id == id).First();
                db.Remove(videogame);
                db.SaveChanges();
            }
        }
    }
}
