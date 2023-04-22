namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Cosa vuoi fare?\n");
                    Console.WriteLine($"1) Inserire un videogioco\n" +
                        $"2) Ricercare un videogioco per ID\n" +
                        $"3) Ricercare un videogioco per nome\n" +
                        $"4) Eliminare un videogioco\n" +
                        $"5) Inserisci una nuova software house\n" +
                        $"6) Esci");

                    ConsoleKey tastoUtente = Console.ReadKey(true).Key;

                    switch (tastoUtente)
                    {
                        case ConsoleKey.D1:

                            Console.WriteLine("Inserisci il nome del videogioco:");
                            string name = Console.ReadLine();

                            Console.WriteLine("Inserisci la descrizione del videogioco:");
                            string overview = Console.ReadLine();

                            Console.WriteLine("Inserisci la data di rilascio del videogioco:");
                            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

                            List <SoftwareHouse> softwareHouseList = VideogameManager.GetSoftwareHouseList();

                            Console.WriteLine("Scegli una software house:");


                            foreach(SoftwareHouse softwareHouse in softwareHouseList)
                            {
                                Console.WriteLine($"{softwareHouse.Id}) {softwareHouse.Name}");
                            }

                            long shId = long.Parse(Console.ReadLine());

                            Videogame newVideogame = new Videogame(name, overview, releaseDate, shId);

                            VideogameManager.InserisciVideogame(newVideogame);

                            break;

                        case ConsoleKey.D2:

                            Console.WriteLine("Inserisci l'id per cercare un videogioco:");
                            long id = long.Parse(Console.ReadLine());

                            Videogame videogame = VideogameManager.RicercaPerId(id);
                            Console.WriteLine(videogame.Name);

                            break;

                        case ConsoleKey.D3:

                            Console.WriteLine("Inserisci il nome per cercare un videogioco:");
                            string nome = Console.ReadLine();

                            List<Videogame> videogameList = VideogameManager.RicercaPerNome(nome);

                            foreach (Videogame videogameSearched in videogameList)
                            {
                                Console.WriteLine(videogameSearched.Name);
                            }

                            break;

                        case ConsoleKey.D4:

                            Console.WriteLine("Inserisci l'id del videogioco da cancellare:");
                            long idVideogame = long.Parse(Console.ReadLine());

                            VideogameManager.CancellaVideogioco(idVideogame);

                            break;

                        case ConsoleKey.D5:
                            Console.WriteLine("Inserisci il nome della software house:");
                            string nomeSH = Console.ReadLine();

                            Console.WriteLine("Inserisci la città della software house:");
                            string city = Console.ReadLine();

                            Console.WriteLine("Inserisci la nazione della software house:");
                            string country = Console.ReadLine();

                            SoftwareHouse newSoftwareHouse = new SoftwareHouse(nomeSH, city, country);

                            VideogameManager.NuovaSoftwareHouse(newSoftwareHouse);

                            break;

                        case ConsoleKey.D6:
                            List<SoftwareHouse> softwareHouses = VideogameManager.GetSoftwareHouseList();

                            Console.WriteLine("Scegli una software house:");


                            foreach (SoftwareHouse softwareHouse in softwareHouses)
                            {
                                Console.WriteLine($"{softwareHouse.Id}) {softwareHouse.Name}");
                            }
                   
                            long softwareHouseId = long.Parse(Console.ReadLine());

                            Console.WriteLine($"I videogiochi prodotti da '{softwareHouses[(int)softwareHouseId - 1].Name}' sono i seguenti:");

                           List <Videogame> videogamesSearched = VideogameManager.GetSoftwareHouseVideogames(softwareHouseId);

                            foreach(Videogame videogameSearched in videogamesSearched)
                            {
                                Console.WriteLine($"{videogameSearched.Id}) {videogameSearched.Name}");
                            }

                            break;
                        case ConsoleKey.D7:
                            return;
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