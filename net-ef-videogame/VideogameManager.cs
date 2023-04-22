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
            Console.WriteLine("\nCaricamento in corso..\n");
            using (VideogameContext db = new VideogameContext())
            {
                db.Add(newVideogame);
                db.SaveChanges();
            }
        }

        public static Videogame? RicercaPerId(long id)
        {
            Console.WriteLine("\nCaricamento in corso..\n");

            Videogame videogameSearched;

            using (VideogameContext db = new VideogameContext())
            {
                videogameSearched = db.Videogame.Where(videogame => videogame.Id == id).First();
            }

            return videogameSearched;

        }

        public static List<Videogame>? RicercaPerNome(string name)
        {
            Console.WriteLine("\nCaricamento in corso..\n");

            List<Videogame> videogames = new List<Videogame>();
            using (VideogameContext db = new VideogameContext())
            {
               videogames = db.Videogame.Where(videogame => videogame.Name.Contains(name)).ToList();
            }
            return videogames;
             
        }
        public static void CancellaVideogioco(long id)
        {
            Console.WriteLine("\nCaricamento in corso..\n");

            using (VideogameContext db = new VideogameContext())
            {
                Videogame videogame = db.Videogame.Where(videogame => videogame.Id == id).First();
                db.Remove(videogame);
                db.SaveChanges();
            }
        }

        public static void NuovaSoftwareHouse(SoftwareHouse newSoftwareHouse)
        {
            Console.WriteLine("\nCaricamento in corso..\n");

            using (VideogameContext db = new VideogameContext())
            {
                db.Add(newSoftwareHouse);
                db.SaveChanges();
            }
        }

        public static List<SoftwareHouse>? GetSoftwareHouseList() 
        {
            Console.WriteLine("\nCaricamento in corso..\n");

            List<SoftwareHouse> softwareHouses = new List<SoftwareHouse>();
            using (VideogameContext db = new VideogameContext())
            {
                softwareHouses = db.SoftwareHouse.OrderBy(softwareHouse => softwareHouse.Id).ToList();
            }

            return softwareHouses;
        }

        public static List<Videogame>? GetSoftwareHouseVideogames(long id)
        {
            Console.WriteLine("\nCaricamento in corso..\n");

            List<Videogame> videogames = new List<Videogame>();
            using (VideogameContext db = new VideogameContext())
            {
                videogames = db.SoftwareHouse.Where(softwareHouse => softwareHouse.Id == id).SelectMany(softwareHouse => softwareHouse.Videogames).ToList();
            }

            return videogames;
        }

    }
}
